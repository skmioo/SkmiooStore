//#define DEBUG_CHECK
#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MyLODSimplify
{
	struct Face
	{
		//面的三个顶点index
		public int[] _VertexIdxs;
		public float[] _Plane;
		/// <summary>
		/// 
		///https://blog.csdn.net/id145/article/details/100096873
		//所以可以设方程为A(x - x1) + B(y - y1) + C(z - z1) = 0 (点法式) (也可设为过另外两个点)
		//核心代码：
		//在此之前写好录入三个三维点的代码，然后就是处理待定系数，如下：
		//A = (y2 - y1)*(z3 - z1) - (z2 -z1)*(y3 - y1);
		//B = (x3 - x1)*(z2 - z1) - (x2 - x1)*(z3 - z1);
		//C = (x2 - x1)*(y3 - y1) - (x3 - x1)*(y2 - y1);
		//即得过P1，P2，P3的平面方程
		//方程也可写为    Ax + By + Cz + D = 0 (一般式) 其中D = -(A * x1 + B * y1 + C * z1)
		/// </summary>
		/// <param name="verts"></param>
		/// <param name="nV0"></param>
		/// <param name="nV1"></param>
		/// <param name="nV2"></param>
		public void init(Vector3[] verts, int nV0, int nV1, int nV2)
		{
			float a, b, c, M;
			Vector3 v0 = verts[nV0];
			Vector3 v1 = verts[nV1];
			Vector3 v2 = verts[nV2];
			a = (v1.y - v0.y) * (v2.z - v0.z) - (v1.z - v0.z) * (v2.y - v0.y);
			b = (v1.z - v0.z) * (v2.x - v0.x) - (v1.x - v0.x) * (v2.z - v0.z);
			c = (v1.x - v0.x) * (v2.y - v0.y) - (v1.y - v0.y) * (v2.x - v0.x);
			M = Mathf.Sqrt(a * a + b * b + c * c);
			a /= M; b /= M; c /= M;
			if (_VertexIdxs == null || _VertexIdxs.Length != 3)
			{
				_VertexIdxs = new int[3];
			}
			_VertexIdxs[0] = nV0;
			_VertexIdxs[1] = nV1;
			_VertexIdxs[2] = nV2;
			if (_Plane == null || _Plane.Length != 4)
			{
				_Plane = new float[4];
			}
			_Plane[0] = a;
			_Plane[1] = b;
			_Plane[2] = c;
			_Plane[3] = -1 * (a * v0.x + b * v0.y + c * v0.z);
		}
	}

	/// <summary>
	/// 记录一个边的俩个点跟优化后的点
	/// </summary>
	struct VSplit
	{
		public Vector3 _v1;
		public Vector3 _v2;
		public Vector3 _vf;
	}

	public enum VertAttribute
	{
		UV0 = 1 << 0,
		UV1 = 1 << 1,
		Normal = 1 << 2
	}

	/// <summary>
	/// 俩点构成的一条边
	/// 此处就是表示三角形的边
	/// </summary>
	struct VertPair
	{
		public VertPair(int nIdx1, int nIdx2)
		{
			if (nIdx1 < nIdx2)
			{
				m_nIdxMin = nIdx1;
				m_nIdxMax = nIdx2;
			}
			else
			{
				m_nIdxMax = nIdx1;
				m_nIdxMin = nIdx2;
			}
		}
		public int m_nIdxMin;
		public int m_nIdxMax;
	}

	class PairComparer : IEqualityComparer<VertPair>
	{
		public bool Equals(VertPair p1, VertPair p2)
		{
			if (p1.m_nIdxMin == p2.m_nIdxMin && p1.m_nIdxMax == p2.m_nIdxMax)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public int GetHashCode(VertPair obj)
		{
			int nCode = obj.m_nIdxMax ^ obj.m_nIdxMin;
			return nCode.GetHashCode();
		}
	}

	class VertexData
	{
		public Vector3 m_Position;
		public Vector2 m_UV0;
		public Vector2 m_UV1;
		public MyLODMatrix m_Martix = new MyLODMatrix(0);
		//一个顶点所在的区域
		public List<int> m_ZoneMeshIdxs = new List<int>();
		//设置顶点所在的区域可能存在多个区域
		public void addZoneMeshIdx(int nZM)
		{
			int nIdx = m_ZoneMeshIdxs.FindIndex(c => c == nZM);
			if (nIdx == -1)
			{
				m_ZoneMeshIdxs.Add(nZM);
			}
		}
		//获取俩个点共有的区域
		public static int getShareZoneMeshIdx(VertexData vd1, VertexData vd2)
		{
			List<int> zmiShare = new List<int>();
			for (int n1 = 0; n1 < vd1.m_ZoneMeshIdxs.Count; n1++)
			{
				int nZMIdx = vd1.m_ZoneMeshIdxs[n1];
				int n2 = vd2.m_ZoneMeshIdxs.FindIndex(c => c == nZMIdx);
				if (n2 != -1)
				{
					zmiShare.Add(nZMIdx);
				}
			}
			if (zmiShare.Count != 1)
			{
				throw new System.ArithmeticException("Multi share zmi!");
			}
			return zmiShare[0];
		}
	}

	class ZoneMesh
	{
		//insert快，读取慢 这个区域所有的面
		public LinkedList<Face> m_Faces = new LinkedList<Face>();
		//add插入在最后，读取快，但insert慢
		public List<VertPair> m_OutEdges = new List<VertPair>();

		//判断这个边是否靠近区域边缘的边
		public bool isPointsInOutEdges(int nV1, int nV2)
		{
			bool bIn = false;
			for (int nOE = 0; nOE < m_OutEdges.Count; nOE++)
			{
				var vp = m_OutEdges[nOE];
				if (vp.m_nIdxMin == nV1 || vp.m_nIdxMax == nV2 || vp.m_nIdxMin == nV2 || vp.m_nIdxMax == nV1)
				{
					bIn = true;
					break;
				}
			}
			return bIn;
		}


		public bool isPointInOutEdges(int nV)
		{
			bool bIn = false;
			for (int nOE = 0; nOE < m_OutEdges.Count; nOE++)
			{
				var vp = m_OutEdges[nOE];
				if (vp.m_nIdxMin == nV || vp.m_nIdxMax == nV)
				{
					bIn = true;
					break;
				}
			}
			return bIn;
		}

	}

	class TmpVertData
	{
		public List<int> m_TriIdxs = new List<int>();
	}


	/// <summary>
	/// 一条边附近的三角形
	///  mesh.triangles[ m_TriIdxs[i] * 3 + 0]
	///  mesh.triangles[ m_TriIdxs[i] * 3 + 1]
	///  mesh.triangles[ m_TriIdxs[i] * 3 + 2]
	///  构成的三角形
	///  共计m_TriIdxs.Length个三角形
	/// </summary>
	class TmpEdgeData
	{
		public List<int> m_TriIdxs = new List<int>();
	}

	/// <summary>
	/// 每个三角形所在区域
	/// </summary>
	class TmpTriData
	{
		public int m_ZoneIdx = -1;
		public bool m_bInQueue = false;
	}


	Dictionary<int, VertexData> m_VertexDatas = new Dictionary<int, VertexData>();

	LinkedList<VSplit> m_VSplits = new LinkedList<VSplit>();
	//每个区域所包含的所有面
	List<ZoneMesh> m_ZoneMeshs = new List<ZoneMesh>();
	//计算每个边与其相连的面构成的三角形偏差幅度
	Dictionary<VertPair, double> m_Errors = new Dictionary<VertPair, double>(new PairComparer());
	//查看该mesh是否有position uv uv1属性
	int m_VertAttribute = 0;

	public Mesh GenLOD(Mesh meshOri, int nTargetFace)
	{
		Fill(meshOri);
		init();
		contract(nTargetFace);
		Mesh meshRet = genMesh();
		return meshRet;
	}

	Bounds m_Bounds;

	VertPair[] make3Edge(int nV0, int nV1, int nV2)
	{
		VertPair[] edges = new VertPair[3];
		edges[0] = new VertPair(nV0, nV1);
		edges[1] = new VertPair(nV1, nV2);
		edges[2] = new VertPair(nV2, nV0);
		return edges;
	}

	void enQueue(Queue<int> queue, List<TmpTriData> triData, int nTri)
	{
		var tmpTD = triData[nTri];
		if (tmpTD.m_ZoneIdx < 0 && !tmpTD.m_bInQueue)
		{
			queue.Enqueue(nTri);
			tmpTD.m_bInQueue = true;
		}
	}

	public void Fill(Mesh mesh)
	{
		m_Errors.Clear();
		m_VertexDatas.Clear();
		m_ZoneMeshs.Clear();
		m_Bounds = mesh.bounds;
		m_VertAttribute = 0;

		if (mesh.uv != null && mesh.uv.Length > 0)
		{
			m_VertAttribute |= (int)VertAttribute.UV0;
		}

		if (mesh.uv2 != null && mesh.uv2.Length > 0)
		{
			m_VertAttribute |= (int)VertAttribute.UV1;
		}

		if (mesh.normals != null && mesh.normals.Length > 0)
		{
			m_VertAttribute |= (int)VertAttribute.Normal;
		}

		List<TmpVertData> tmpVertDatas = new List<TmpVertData>();
		//每条边对应的三角形
		Dictionary<VertPair, TmpEdgeData> tmpEdgeDatas = new Dictionary<VertPair, TmpEdgeData>(new PairComparer());

		// 每个三角形所在区域
		List<TmpTriData> tmpTriDatas = new List<TmpTriData>();

		int nVertCount = mesh.vertexCount;
		int nTriCount = mesh.triangles.Length / 3;

		for (int nTri = 0; nTri < nTriCount; nTri++)
		{
			tmpTriDatas.Add(new TmpTriData());
#if DEBUG_CHECK
			int nV0 = mesh.triangles[nTri * 3 + 0];
			int nV1 = mesh.triangles[nTri * 3 + 1];
			int nV2 = mesh.triangles[nTri * 3 + 2];
			if (checkVertIdx(nV0) && checkVertIdx(nV1) && checkVertIdx(nV2))
			{
				int n = 0;
			}
#endif
		}

		for (int nTri = 0; nTri < nTriCount; nTri++)
		{
			int nV0 = mesh.triangles[nTri * 3 + 0];
			int nV1 = mesh.triangles[nTri * 3 + 1];
			int nV2 = mesh.triangles[nTri * 3 + 2];
			var edges = make3Edge(nV0, nV1, nV2);
			foreach (var e in edges)
			{
				TmpEdgeData ted = null;
				if (!tmpEdgeDatas.TryGetValue(e, out ted))
				{
					ted = new TmpEdgeData();
					tmpEdgeDatas.Add(e, ted);
				}
				ted.m_TriIdxs.Add(nTri);
			}
		}

		Queue<int> trisToProcess = new Queue<int>();
		int nZoneCount = 0;

		for (int nTri = 0; nTri < nTriCount; nTri++)
		{
			var triData = tmpTriDatas[nTri];
			if (triData.m_ZoneIdx < 0)
			{
				enQueue(trisToProcess, tmpTriDatas, nTri);
				while (trisToProcess.Count > 0)
				{
					int nTriToProcess = trisToProcess.Dequeue();
					var tmpTriData = tmpTriDatas[nTriToProcess];
					if (tmpTriData.m_ZoneIdx < 0)
					{
						tmpTriData.m_ZoneIdx = nZoneCount;
					}
					int nVert0 = mesh.triangles[nTriToProcess * 3 + 0];
					int nVert1 = mesh.triangles[nTriToProcess * 3 + 1];
					int nVert2 = mesh.triangles[nTriToProcess * 3 + 2];

					var edges = make3Edge(nVert0, nVert1, nVert2);

					foreach (var e in edges)
					{
						TmpEdgeData ted = null;
						if (tmpEdgeDatas.TryGetValue(e, out ted))
						{
							foreach (var nTriWithE in ted.m_TriIdxs)
							{
								enQueue(trisToProcess, tmpTriDatas, nTriWithE);
							}
						}
						else
						{
							throw new System.ArithmeticException("Can't find a edge!");
						}
					}
				}
				nZoneCount++;
			}
		}


		foreach (var ted in tmpEdgeDatas)
		{
			int idxLastZone = -1;
			foreach (var nTri in ted.Value.m_TriIdxs)
			{
				var tmpTri = tmpTriDatas[nTri];
				if (idxLastZone >= 0)
				{
					if (tmpTri.m_ZoneIdx != idxLastZone)
					{
						throw new System.ArithmeticException("One Edge In MultiZone!");
					}
				}
				idxLastZone = tmpTri.m_ZoneIdx;
			}
		}


		//设置顶点数据的m_Position m_UV0 m_UV1
		for (int nV = 0; nV < mesh.vertexCount; nV++)
		{
			var v3 = mesh.vertices[nV];
			VertexData vdNew = new VertexData();
			vdNew.m_Position = v3;
			if (checkVertAttribute(m_VertAttribute, VertAttribute.UV0))
			{
				vdNew.m_UV0 = mesh.uv[nV];
			}
			if (checkVertAttribute(m_VertAttribute, VertAttribute.UV1))
			{
				vdNew.m_UV1 = mesh.uv2[nV];
			}
			m_VertexDatas[nV] = vdNew;
		}


		for (int nZone = 0; nZone < nZoneCount; nZone++)
		{
			ZoneMesh zmNew = new ZoneMesh();
			for (int nTri = 0; nTri < tmpTriDatas.Count; nTri++)
			{
				var tmpTD = tmpTriDatas[nTri];
				if (tmpTD.m_ZoneIdx == nZone)
				{
					Face faceNew = new Face();
					int vi0 = mesh.triangles[3 * nTri + 0];
					int vi1 = mesh.triangles[3 * nTri + 1];
					int vi2 = mesh.triangles[3 * nTri + 2];
					faceNew.init(mesh.vertices, vi0, vi1, vi2);
					zmNew.m_Faces.AddLast(faceNew);
					VertexData vd0 = null;
					m_VertexDatas.TryGetValue(vi0, out vd0);
					vd0.addZoneMeshIdx(nZone);
					VertexData vd1 = null;
					m_VertexDatas.TryGetValue(vi1, out vd1);
					vd1.addZoneMeshIdx(nZone);
					VertexData vd2 = null;
					m_VertexDatas.TryGetValue(vi2, out vd2);
					vd2.addZoneMeshIdx(nZone);
				}
			}
			m_ZoneMeshs.Add(zmNew);
		}

		FindOutEdge();
	}



#if DEBUG_CHECK
	readonly static int[] c_Idx1s = new int[] { 43, 345, 407 };
	readonly static int[] c_Idx2s = new int[] { 152, 401 };
	//readonly static int[] c_VertIdxs = new int[] { 90,237,32,320,342};
	//readonly static int[] c_VertIdxs = new int[] { 136, 398,59, 32, 320, 342 };
	readonly static int[] c_VertIdxs = new int[] { 237, 398, 59, 32, 320, 342 };
	bool checkVertIdx(int nV)
	{
		foreach (var vc in c_VertIdxs)
		{
			if (vc == nV)
			{
				return true;
			}
		}
		return false;
	}
#endif


	public void FindOutEdge()
	{
		foreach (var zm in m_ZoneMeshs)
		{
			Dictionary<VertPair, int> edgeCounters = new Dictionary<VertPair, int>(new PairComparer());
			foreach (var face in zm.m_Faces)
			{
				for (int nV = 0; nV < 3; nV++)
				{
					//取余因为取第三个顶点时,下一个顶点取第一个
					int nVNext = (nV + 1) % 3;
					int viThis = face._VertexIdxs[nV];
					int viNext = face._VertexIdxs[nVNext];
					VertPair edge = new VertPair(viThis, viNext);

#if DEBUG_CHECK
                        List<VertPair> edgesCheck = new List<VertPair>();
                        for(int n1=0;n1<c_Idx1s.Length;n1++)
                        {
                            for(int n2=0;n2<c_Idx2s.Length;n2++)
                            {
                                var edgeCheck = new VertPair(c_Idx1s[n1], c_Idx2s[n2]);
                                edgesCheck.Add(edgeCheck);
                            }
                        }

                        foreach(var e in edgesCheck)
                        {
                            if(e.m_nIdxMin==edge.m_nIdxMin && e.m_nIdxMax==edge.m_nIdxMax)
                            {
                                break;
                            }
                        }
#endif

					if (edgeCounters.ContainsKey(edge))
					{
						edgeCounters[edge]++;
					}
					else
					{
						edgeCounters[edge] = 1;
					}
				}
			}
			zm.m_OutEdges.Clear();
			foreach (var kv in edgeCounters)
			{
				if (kv.Value == 1)
				{
					zm.m_OutEdges.Add(kv.Key);
				}
			}
		}
	}

	/// <summary>
	/// 返回所有区域的所有边
	/// </summary>
	/// <returns></returns>
	public List<Vector3> GetOutEdgeSegments()
	{
		List<Vector3> edgePoints = new List<Vector3>();
		foreach (var zm in m_ZoneMeshs)
		{
			foreach (var vertPair in zm.m_OutEdges)
			{
				Vector3 v0 = m_VertexDatas[vertPair.m_nIdxMin].m_Position;
				Vector3 v1 = m_VertexDatas[vertPair.m_nIdxMax].m_Position;
				edgePoints.Add(v0);
				edgePoints.Add(v1);
			}
		}
		return edgePoints;
	}

	/// <summary>
	/// 生成所有区域的Mesh集合
	/// </summary>
	/// <returns></returns>
	public List<Mesh> OutputZoneMesh()
	{
		List<Mesh> listMeshes = new List<Mesh>();

		int nVertCount = m_VertexDatas.Count;
		Vector3[] verts = new Vector3[nVertCount];
		Vector2[] uv0s = new Vector2[nVertCount];
		Vector2[] uv1s = new Vector2[nVertCount];

		foreach (var kv in m_VertexDatas)
		{
			int nV = kv.Key;
			var vd = kv.Value;
			verts[nV] = vd.m_Position;
			uv0s[nV] = vd.m_UV0;
			uv1s[nV] = vd.m_UV1;
		}

		foreach (var zm in m_ZoneMeshs)
		{
			//每个区域的Mesh信息赋值
			Mesh meshNew = new Mesh();
			meshNew.vertices = verts;
			meshNew.uv = uv0s;
			meshNew.uv2 = uv1s;
			List<int> listTris = new List<int>();
			foreach (var face in zm.m_Faces)
			{
				listTris.Add(face._VertexIdxs[0]);
				listTris.Add(face._VertexIdxs[1]);
				listTris.Add(face._VertexIdxs[2]);
			}
			meshNew.triangles = listTris.ToArray();
			listMeshes.Add(meshNew);
		}
		return listMeshes;
	}


	void init()
	{
		foreach (var zm in m_ZoneMeshs)
		{
			foreach (var face in zm.m_Faces)
			{
				foreach (var nV in face._VertexIdxs)
				{
					var qAdd = new MyLODMatrix(face._Plane);
					var vd = m_VertexDatas[nV];
					vd.m_Martix += qAdd;
				}
			}
		}
	}

	/// <summary>
	/// v构成的矩阵
	/// v.x*v.x	v.x*v.y	v.x*v.z	0
	/// v.y*v.x	v.y*b.y	v.y*v.z	0
	/// v.z*v.x	v.z*b.y	v.z*v.z	0
	/// 0		0		0		1
	/// 
	/// 相乘
	///q[0] * v.x*v.x + q[1] * v.y*v.x * q[2] *  v.z*v.x
	///
	/// </summary>
	/// <param name="q"></param>
	/// <param name="v"></param>
	/// <returns></returns>
	double vertexError(MyLODMatrix q, Vector3 v)
	{
		return q[0] * v.x * v.x
			+ 2 * q[1] * v.x * v.y
			+ 2 * q[2] * v.x * v.z
			+ 2 * q[3] * v.x
			+ q[5] * v.y * v.y
			+ 2 * q[6] * v.y * v.z
			+ 2 * q[7] * v.y
			+ q[10] * v.z * v.z
			+ 2 * q[11] * v.z
			+ q[15];
	}

	double calculateError(int nV1, int nV2, ref Vector3 vf)
	{
		double fMinError = int.MaxValue;

		MyLODMatrix qBar;
		MyLODMatrix qDelta;

		VertexData vd1 = null;
		VertexData vd2 = null;

		m_VertexDatas.TryGetValue(nV1, out vd1);
		m_VertexDatas.TryGetValue(nV2, out vd2);
		if (vd1 == null || vd2 == null)
		{
			throw new System.ArgumentException("Can't find vertex datas");
		}

		qBar = vd1.m_Martix + vd2.m_Martix;

		if (qBar[1] != qBar[4] || qBar[2] != qBar[8] || qBar[6] != qBar[9] || qBar[3] != qBar[12] || qBar[7] != qBar[13] || qBar[11] != qBar[14])
		{
			throw new System.ArgumentException("Q Bar is not symmetric!");
		}

		qDelta = new MyLODMatrix();

		qDelta[0] = qBar[0];
		qDelta[1] = qBar[1];
		qDelta[2] = qBar[2];
		qDelta[3] = qBar[3];

		qDelta[4] = qBar[4];
		qDelta[5] = qBar[5];
		qDelta[6] = qBar[6];
		qDelta[7] = qBar[7];

		qDelta[8] = qBar[8];
		qDelta[9] = qBar[9];
		qDelta[10] = qBar[10];
		qDelta[11] = qBar[11];

		qDelta[12] = 0;
		qDelta[13] = 0;
		qDelta[14] = 0;
		qDelta[15] = 1;

		double det = qDelta.det(0, 1, 2, 4, 5, 6, 8, 9, 10);
		if (det != 0)
		{
			vf.x = (float)(-1 / det * qDelta.det(1, 2, 3, 5, 6, 7, 9, 10, 11));
			vf.y = (float)(1 / det * qDelta.det(0, 2, 3, 4, 6, 7, 8, 10, 11));
			vf.z = (float)(-1 / det * qDelta.det(0, 1, 3, 4, 5, 7, 8, 9, 11));
			fMinError = vertexError(qBar, vf);
		}
		else
		{
			Vector3 v1 = vd1.m_Position;
			Vector3 v2 = vd2.m_Position;
			Vector3 vMid = (v1 + v2) * 0.5f;
			double fError1 = vertexError(qBar, v1);
			double fError2 = vertexError(qBar, v2);
			double fErrorMid = vertexError(qBar, vMid);

			double dMin1 = fError2 < fErrorMid ? fError2 : fErrorMid;
			fMinError = fError1 < dMin1 ? fError1 : dMin1;

			if (fMinError == fError1)
			{
				vf = v1;
			}
			if (fMinError == fError2)
			{
				vf = v2;
			}
			if (fMinError == fErrorMid)
			{
				vf = vMid;
			}
		}
		return fMinError;
	}

	void selectPair()
	{
		Vector3 vError = new Vector3();
		foreach (var zm in m_ZoneMeshs)
		{
			foreach (var face in zm.m_Faces)
			{
				int nVI0 = face._VertexIdxs[0];
				int nVI1 = face._VertexIdxs[1];
				int nVI2 = face._VertexIdxs[2];
				VertPair[] vps = new VertPair[3];
				vps[0] = new VertPair(nVI0, nVI1);
				vps[1] = new VertPair(nVI1, nVI2);
				vps[2] = new VertPair(nVI2, nVI0);
				foreach (var vp in vps)
				{
					if (!zm.isPointsInOutEdges(vp.m_nIdxMin, vp.m_nIdxMax))
					{
						if (!m_Errors.ContainsKey(vp))
						{
							m_Errors[vp] = calculateError(vp.m_nIdxMin, vp.m_nIdxMax, ref vError);
						}
					}
				}
			}
		}
	}

	int faceCount
	{
		get
		{
			int nFaceCount = 0;
			foreach (var zm in m_ZoneMeshs)
			{
				nFaceCount += zm.m_Faces.Count;
			}
			return nFaceCount;
		}
	}

	//面数合并faceCount->nTargetFace
	public void contract(int nTargetFace)
	{
		selectPair();

		int nV1, nV2;
		VSplit vp = new VSplit();
		Vector3 v3F = new Vector3();
		while (faceCount > nTargetFace)
		{
			if (m_Errors.Count <= 0)
			{
				break;
			}

			double fMinError = int.MaxValue;
			VertPair pairMinError = new VertPair(-1, -1);

			foreach (var error in m_Errors)
			{
				if (error.Value < fMinError)
				{
					fMinError = error.Value;
					pairMinError = error.Key;
				}
			}

			calculateError(pairMinError.m_nIdxMin, pairMinError.m_nIdxMax, ref vp._vf);


			//如果算出的这个点不在包围盒内，抛弃计算下一个点
			if (!m_Bounds.Contains(vp._vf))
			{
				m_Errors.Remove(pairMinError);
				continue;
			}


			VertexData vd1 = null;
			VertexData vd2 = null;

			nV1 = pairMinError.m_nIdxMin;
			nV2 = pairMinError.m_nIdxMax;
			m_VertexDatas.TryGetValue(nV1, out vd1);
			m_VertexDatas.TryGetValue(nV2, out vd2);
			if (vd1 == null || vd2 == null)
			{
				throw new System.ArgumentException("Can't find vertex datas");
			}

#if DEBUG_CHECK
                int nShareZM = VertexData.getShareZoneMeshIdx(vd1, vd2);
                bool bInOE = m_ZoneMeshs[nShareZM].isPointsInOutEdges(nV1, nV2);
#endif

			vp._v1 = vd1.m_Position;
			vp._v2 = vd2.m_Position;

			vd1.m_Position = vp._vf;
			vd1.m_Martix = vd1.m_Martix + vd2.m_Martix;

			int nZoneIdx = VertexData.getShareZoneMeshIdx(vd1, vd2);
			var facesInZM = m_ZoneMeshs[nZoneIdx].m_Faces;
			//把所有与v1 v2相连的三角形去除，仅连接v2的连接v1达到模型简化的效果
			LinkedListNode<Face> llnFace = facesInZM.First;
			while (llnFace != null)
			{
				var llnNext = llnFace.Next;
				for (int n = 0; n < 3; n++)
				{
					if (llnFace.Value._VertexIdxs[n] == nV2)
					{
						if (llnFace.Value._VertexIdxs[0] == nV1 || llnFace.Value._VertexIdxs[1] == nV1 || llnFace.Value._VertexIdxs[2] == nV1)
						{
							facesInZM.Remove(llnFace);
						}
						else
						{
							llnFace.Value._VertexIdxs[n] = nV1;
						}
						llnFace = llnNext;
						break;
					}
				}
				llnFace = llnNext;
			}



			//修正vd1的uv0
			if (checkVertAttribute(m_VertAttribute, VertAttribute.UV0))
			{
				float fLen = (vp._v2 - vp._v1).magnitude;
				float fLerp = 0;
				if (fLen > 0)
				{
					fLerp = (vp._vf - vp._v1).magnitude / fLen;
				}
				vd1.m_UV0 = Vector2.Lerp(vd1.m_UV0, vd2.m_UV0, fLerp);
			}
			//修正vd1的uv1
			if (checkVertAttribute(m_VertAttribute, VertAttribute.UV1))
			{
				float fLen = (vp._v2 - vp._v1).magnitude;
				float fLerp = 0;
				if (fLen > 0)
				{
					fLerp = (vp._vf - vp._v1).magnitude / fLen;
				}
				vd1.m_UV1 = Vector2.Lerp(vd1.m_UV1, vd2.m_UV1, fLerp);
			}

			m_VertexDatas.Remove(nV2);
			List<VertPair> pairsToRemove = new List<VertPair>();

			//m_Errors.Keys存储着所有的边
			var listPairs = new List<VertPair>(m_Errors.Keys);

			foreach (var pair in listPairs)
			{
				if (pair.m_nIdxMin == nV2 && pair.m_nIdxMax != nV1)
				{
					pairsToRemove.Add(pair);
					var pairToZero = new VertPair(Mathf.Min(nV1, pair.m_nIdxMax), Mathf.Max(nV1, pair.m_nIdxMax));
					m_Errors[pairToZero] = 0;
				}
				else if (pair.m_nIdxMax == nV2 && pair.m_nIdxMin != nV1)
				{
					pairsToRemove.Add(pair);
					var pairToZero = new VertPair(Mathf.Min(nV1, pair.m_nIdxMin), Mathf.Max(nV1, pair.m_nIdxMin));
					m_Errors[pairToZero] = 0;
				}
			}

			foreach (var pairToRemove in pairsToRemove)
			{
				m_Errors.Remove(pairToRemove);
			}
			m_Errors.Remove(pairMinError);


			listPairs = new List<VertPair>(m_Errors.Keys);
			foreach (var pair in listPairs)
			{
				if (pair.m_nIdxMin == nV1)
				{
					m_Errors[pair] = calculateError(nV1, pair.m_nIdxMax, ref v3F);
				}
				if (pair.m_nIdxMax == nV1)
				{
					m_Errors[pair] = calculateError(nV1, pair.m_nIdxMin, ref v3F);
				}
			}
		}
	}

	Mesh genMesh()
	{
		Mesh meshRet = new Mesh();
		//顶点id map
		Dictionary<int, int> vertIdxMap = new Dictionary<int, int>();
		Vector3[] arrayVerts = new Vector3[m_VertexDatas.Count];
		Vector2[] arrayUVs = null;
		Vector2[] arrayUV1s = null;
		if (checkVertAttribute(m_VertAttribute, VertAttribute.UV0))
		{
			arrayUVs = new Vector2[m_VertexDatas.Count];
		}
		if (checkVertAttribute(m_VertAttribute, VertAttribute.UV1))
		{
			arrayUV1s = new Vector2[m_VertexDatas.Count];
		}


		var viList = new List<int>(m_VertexDatas.Keys);

		for (int nNewVI = 0; nNewVI < viList.Count; nNewVI++)
		{
			int nVI = viList[nNewVI];
			vertIdxMap[nVI] = nNewVI;
			var vertData = m_VertexDatas[nVI];
			arrayVerts[nNewVI] = vertData.m_Position;
			if (checkVertAttribute(m_VertAttribute, VertAttribute.UV0))
			{
				arrayUVs[nNewVI] = vertData.m_UV0;
			}
			if (checkVertAttribute(m_VertAttribute, VertAttribute.UV1))
			{
				arrayUV1s[nNewVI] = vertData.m_UV1;
			}
		}
		meshRet.vertices = arrayVerts;
		if (checkVertAttribute(m_VertAttribute, VertAttribute.UV0))
		{
			meshRet.uv = arrayUVs;
		}
		if (checkVertAttribute(m_VertAttribute, VertAttribute.UV1))
		{
			meshRet.uv2 = arrayUV1s;
		}

		int[] tris = new int[faceCount * 3];
		int nTri = 0;
		for (int nZM = 0; nZM < m_ZoneMeshs.Count; nZM++)
		{
			var zm = m_ZoneMeshs[nZM];
			var lln = zm.m_Faces.First;
			while (lln != null)
			{
				int nNew0 = vertIdxMap[lln.Value._VertexIdxs[0]];
				int nNew1 = vertIdxMap[lln.Value._VertexIdxs[1]];
				int nNew2 = vertIdxMap[lln.Value._VertexIdxs[2]];

				int nIdx0 = nTri * 3;
				int nIdx1 = nTri * 3 + 1;
				int nIdx2 = nTri * 3 + 2;

				tris[nIdx0] = nNew0;
				tris[nIdx1] = nNew1;
				tris[nIdx2] = nNew2;
				nTri++;
				lln = lln.Next;
			}
		}
		meshRet.triangles = tris;
		return meshRet;
	}

	bool checkVertAttribute(int nKeyDataMask, VertAttribute kdCheck)
	{
		return (nKeyDataMask & (int)kdCheck) > 0;
	}
}

#endif
