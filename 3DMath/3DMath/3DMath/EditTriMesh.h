#pragma once
#include "Vector3.h"
class EditTriMesh
{
public:
	//顶点类
	class Vertex
	{
	public:
		Vertex() { setDefaults(); }
		void setDefaults();
		//顶点
		Vector3 p;
		//纹理坐标
		float u, v;
		//顶点法向量
		Vector3 normal;
	};
	//三角形类
	class Tri
	{
	public:
		Tri() { setDefaults(); }
		void setDefaults();
		struct Vert
		{
			//只保存顶点的索引
			int index;
			float u, v;
		};
		Vert v[3];
		//法向量
		Vector3 normal;
	};

	EditTriMesh();
	~EditTriMesh();

	Vertex & vertex(int vertexIndex);
	const Vertex & vertex(int vertexIndex) const;
	Tri&tri(int triIndex);
	int vertexCount() const { return vCount; }
	const Tri&tri(int triIndex) const;
	int triCount() const { return tCount; }
	void construct();
	void empty();
	//增加顶点
	int addVertex();
	int addVertex(const Vertex &v);
	void setVertexCount(int vc);
	//增加三角形
	int addTri();
	int addTri(const Tri &t);
	void setTriCount(int tc);
	//计算一个三角形的法向量
	void computeOneTriNormal(Tri & t);
	void computeOneTriNormal(int triIndex);
	void computeAllTriNormal();
	//计算顶点的法向量(顶点周围三角形的法向量之和)
	void computeAllVertexNormal();

private:
	int vAlloc;
	int vCount;
	Vertex *vList;
	int tAlloc;
	int tCount;
	Tri * tList;
};
