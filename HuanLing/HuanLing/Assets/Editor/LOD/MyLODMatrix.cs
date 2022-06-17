#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
public class MyLODMatrix
{

	private double[] m_Datas = new double[16];

	public double this[int index]
	{
		get {
			return m_Datas[index];
		}
		set {
			m_Datas[index] = value;
		}
	}

	public MyLODMatrix()
	{
	}

	public MyLODMatrix(double c)
	{
		for (int n = 0; n < 16; n++)
		{
			m_Datas[n] = c;
		}
	}

	/// <summary>
	/// P plane Ax + By + Cz + D = 0
	/// </summary>
	/// <param name="p"></param>
	public MyLODMatrix(float[] p)
	{
		double a = p[0];
		double b = p[1];
		double c = p[2];
		double d = p[3];

		m_Datas[0] = a * a;
		m_Datas[1] = a * b;
		m_Datas[2] = a * c;
		m_Datas[3] = a * d;

		m_Datas[4] = a * b;
		m_Datas[5] = b * b;
		m_Datas[6] = b * c;
		m_Datas[7] = b * d;

		m_Datas[8] = a * c;
		m_Datas[9] = b * c;
		m_Datas[10] = c * c;
		m_Datas[11] = c * d;

		m_Datas[12] = a * d;
		m_Datas[13] = b * d;
		m_Datas[14] = c * d;
		m_Datas[15] = d * d;
	}

	///三阶行列式
	public double det(int a11, int a12, int a13, int a21, int a22, int a23, int a31, int a32, int a33)
	{
		double det = m_Datas[a11] * m_Datas[a22] * m_Datas[a33] + m_Datas[a13] * m_Datas[a21] * m_Datas[a32] + m_Datas[a12] * m_Datas[a23] * m_Datas[a31]
			- m_Datas[a13] * m_Datas[a22] * m_Datas[a31] - m_Datas[a11] * m_Datas[a23] * m_Datas[a32] - m_Datas[a12] * m_Datas[a21] * m_Datas[a33];
		return det;
	}

	public static MyLODMatrix operator +(MyLODMatrix a, MyLODMatrix b)
	{
		MyLODMatrix mRet = new MyLODMatrix();
		mRet[0] = a[0] + b[0];
		mRet[1] = a[1] + b[1];
		mRet[2] = a[2] + b[2];
		mRet[3] = a[3] + b[3];

		mRet[4] = a[4] + b[4];
		mRet[5] = a[5] + b[5];
		mRet[6] = a[6] + b[6];
		mRet[7] = a[7] + b[7];

		mRet[8] = a[8] + b[8];
		mRet[9] = a[9] + b[9];
		mRet[10] = a[10] + b[10];
		mRet[11] = a[11] + b[11];

		mRet[12] = a[12] + b[12];
		mRet[13] = a[13] + b[13];
		mRet[14] = a[14] + b[14];
		mRet[15] = a[15] + b[15];
		return mRet;
	}
}
#endif