#include "Vector3.h"
#include "Matrix4x3.h"
#include <assert.h>
Matrix4x3 operator *(const Matrix4x3 &a, const Matrix4x3 &b) 
{
	Matrix4x3 v;
	v.m11 = a.m11*b.m11 + a.m12*b.m21 + a.m13*b.m31;
	v.m12 = a.m11*b.m12 + a.m12*b.m22 + a.m13*b.m32;
	v.m13 = a.m11*b.m13 + a.m12*b.m23 + a.m13*b.m33;
	v.m21 = a.m21*b.m11 + a.m22*b.m21 + a.m23*b.m31;
	v.m22 = a.m21*b.m12 + a.m22*b.m22 + a.m23*b.m32;
	v.m23 = a.m21*b.m13 + a.m22*b.m23 + a.m23*b.m33;
	v.m31 = a.m31*b.m11 + a.m32*b.m21 + a.m33*b.m31;
	v.m32 = a.m31*b.m12 + a.m32*b.m22 + a.m33*b.m32;
	v.m33 = a.m31*b.m13 + a.m32*b.m23 + a.m33*b.m33;

	v.tx = a.tx * b.m11 + a.ty * b.m21 + a.tz * b.m31 + b.tx;
	v.ty = a.tx * b.m12 + a.ty * b.m22 + a.tz * b.m32 + b.ty;
	v.tz = a.tx * b.m13 + a.ty * b.m23 + a.tz * b.m33 + b.tz;
	return v;
}
Matrix4x3 operator *(const Matrix4x3 &m, const float v)
{
	Matrix4x3 M;
	M.m11 = m.m11*v;
	M.m12 = m.m12*v;
	M.m13 = m.m13*v;
	M.m21 = m.m21*v;
	M.m22 = m.m22*v;
	M.m23 = m.m23*v;
	M.m31 = m.m31*v;
	M.m32 = m.m32*v;
	M.m33 = m.m33*v;
	M.tx = m.tx * v;
	M.ty = m.ty * v;
	M.tz = m.tz * v;
	return M;
}

Vector3 operator *(const Vector3 &v, const Matrix4x3 &m)
{
	return Vector3(
		v.x * m.m11 + v.y * m.m21 + v.z * m.m31,
		v.x * m.m12 + v.y * m.m22 + v.z * m.m32,
		v.x * m.m13 + v.y * m.m23 + v.z * m.m33
	);
}

Vector3& operator *=(Vector3 &v, const Matrix4x3 &m)
{
	v = v * m;
	return v;
}

Matrix4x3& operator *=(Matrix4x3 &a, const Matrix4x3 &b)
{
	a = a * b;
	return a;
}

/*
axis 旋转轴 1：x轴 2:y轴 3:z轴
*/
void Matrix4x3::setRotate(int axis, float theta)
{
	float s, c;
	//sinCos(&s, &c, theta);
	sinCos(s, c, theta);
	if (axis == 1)
	{
		m11 = 1;	m12 = 0;	m13 = 0;
		m21 = 0;	m22 = c;	m23 = s;
		m31 = 0;	m32 = -s;	m33 = c;
	}
	else if(axis == 2)
	{
		m11 = c;	m12 = 0;	m13 = -s;
		m21 = 0;	m22 = 1;	m23 = 0;
		m31 = s;	m32 = 0;	m33 = c;
	}
	else if(axis == 3)
	{
		m11 = c;	m12 = s;	m13 = 0;
		m21 = -s;	m22 = c;	m23 = 0;
		m31 = 0;	m32 = 0;	m33 = 1;
	}
	tx = ty = tz = 0;
}

void Matrix4x3::setScale(const float kx, const float ky, const float kz)
{
	m11 = kx;	m12 = 0;	m13 = 0;
	m21 = 0;	m22 = ky;	m23 = 0;
	m31 = 0;	m32 = 0;	m33 = kz;
	tx = ty = tz = 0;
}

void Matrix4x3::setScale(const Vector3 & scale)
{
	m11 = scale.x;	m12 = 0;	m13 = 0;
	m21 = 0;	m22 = scale.y;	m23 = 0;
	m31 = 0;	m32 = 0;	m33 = scale.z;
	tx = ty = tz = 0;
}

/*
	比如: 0 0 1 可以表示xy构成的平面
	Nx	Ny	Nz垂直向量构成的平面的投影矩阵:
	1+(0-1)Nx^2	(0-1)NxNy	(0-1)NxNz
	(0-1)NxNy	1+(0-1)Ny^2	(0-1)NyNz
	(0-1)NxNz	(0-1)NzNy	1+(0-1)Nz^2
	n要为单位向量
*/
void Matrix4x3::setProject(const Vector3 & n)
{
	Vector3 v(n);
	v.normalize();
	m11 = 1.0f - v.x * n.x;
	m22 = 1.0f - v.y * v.y;
	m33 = 1.0f - v.z * v.z;

	m12 = m21 = -v.x * v.y;
	m13 = m31 = -v.x * v.z;
	m23 = m32 = -v.y * v.z;
	tx = ty = tz = 0;
}
/*
指定轴镜像(反射)
*/
void Matrix4x3::setReflect(int axis, float k )
{
	if (axis == 1)
	{
		//x = k平面发生镜像
		m11 = -1;	m12 = 0;	m13 = 0;
		m21 = 0;	m22 = 1;	m23 = 0;
		m31 = 0;	m32 = 0;	m33 = 1;
		tx = 2.0f * k;
		ty = 0;
		tz = 0;
	}
	else if (axis == 2)
	{
		//y = k平面发生镜像
		m11 = 1;	m12 = 0;	m13 = 0;
		m21 = 0;	m22 = -1;	m23 = 0;
		m31 = 0;	m32 = 0;	m33 = 1;
		tx = 0;
		ty = 2.0f * k;
		tz = 0;
	}
	else if (axis == 3)
	{
		//Z = k平面发生镜像
		m11 = 1;	m12 = 0;	m13 = 0;
		m21 = 0;	m22 = 1;	m23 = 0;
		m31 = 0;	m32 = 0;	m33 = -1;
		tx = 0;
		ty = 0;
		tz = 2.0f * k;
	}
	
}
/*
	某个平面(以平面垂直向量表示平面)镜像(反射)
	1-2Nx^2		-2NxNy	-2NxNz
	-2NxNy		1-2Ny^2	-2NyNz
	-2NxNz		-2NyNz	1-2Nz^2

*/
void Matrix4x3::setReflect(const Vector3 & reflect)
{
	//单位向量表示平面
	Vector3 n(reflect);
	n.normalize();
	float ax = -2.0f * n.x;
	float ay = -2.0f * n.y;
	float az = -2.0f * n.z;
	m11 = 1 + ax * n.x;
	m22 = 1 + ay * n.y;
	m33 = 1 + az * n.z;
	m12 = m21 = ax * n.y;
	m13 = m31 = az * n.x;
	m23 = m32 = ay * n.z;
	tx = ty = tz = 0;
}

/*
	切变函数
	切变
	切变矩阵
	x方向切变:(用y来切变)
	1	0
	s	1
	y方向切变:(用x来切变)
	1	s
	0	1

	y坐标轴变成s 1,这样图片会倾斜

	xy方向切变(用z来切变)
	1	0	0
	0	1	0
	s	t	1

	xz方向切变(用y来切变)
	1	0	0
	s	1	t
	0	0	1
	0

	yz方向切变(用x来切变)
	1	s	t
	0	1	0
	0	0	1
*/
void Matrix4x3::setShear(int axis, float s, float t)
{
	if (axis == 1)	//用x切变y跟z
	{
		m11 = 1;	m12 = s;	m13 = t;
		m21 = 0;	m22 = 1;	m23 = 0;
		m31 = 0;	m32 = 0;	m33 = 1;
	}
	else if (axis == 2)	//用y去切变x,z
	{
		m11 = 1;	m12 = 0;	m13 = 0;
		m21 = s;	m22 = 1;	m23 = t;
		m31 = 0;	m32 = 0;	m33 = 1;
	}
	else if (axis == 3)//用z去切变x,y
	{
		m11 = 1;	m12 = 0;	m13 = 0;
		m21 = 0;	m22 = 1;	m23 = 0;
		m31 = s;	m32 = t;	m33 = 1;
	}
	tx = ty = tz = 0;
}

/*
	矩阵行列式的值
	矩阵是行列式(是一个标量)
	|M|	= |m11	m12| = m11*m22 - m12*m21
		  |m21	m22|
	只有方阵才有行列式
	|M|	= |m11	m12	 m13| =  m11*m22*m33 + m12*m23*m31 + m21*m32*m13
		  |m21	m22	 m23|   -m13*m22*m31 - m11*m23*m32 - m33*m12*m21
		  |m31	m32	 m33|
						  =  m11(m22*m33 - m23*m32)
							+m12(m23*m31 - m21*m33)
							+m13(m21*m32 - m22*m31)
*/
float determinant(const Matrix4x3 &m)
{
	return m.m11*(m.m22*m.m33 - m.m23 * m.m32)
		 + m.m12*(m.m23*m.m31 - m.m21 * m.m33)
		 + m.m13*(m.m21*m.m32 - m.m22 * m.m31);
}

//矩阵的转置
Matrix4x3 transpose(const Matrix4x3 &m)
{
	Matrix4x3 M;
	M.m11 = m.m11;
	M.m12 = m.m21;
	M.m13 = m.m31;

	M.m21 = m.m12;
	M.m22 = m.m22;
	M.m23 = m.m32;
	
	M.m31 = m.m13;
	M.m32 = m.m23;
	M.m33 = m.m33;
	return M;
}

/*
	矩阵的逆
	标准伴随矩阵(adjM)的计算
	M	=	-4		-3		3
			0		2		-2
			1		4		-1
	代数余子式矩阵
	c{11} = +|m22 m23| = 2*-1 -(-2) * 4 = -2+8 = 6;			c{12} = -|m21 m23| = -(0*(-1) - (-2)*1 )= -(2) = -2;
			 |m32 m33|								 	 			 |m31 m33|
	c{21} = -|m12 m13| = -((-3)*(-1) - (3)*4 )= -(-9) = 9;  c{22} = +|m11 m13| = -4*(-1) - 1*3 = 1
			 |m32 m33|												 |m31 m33|

adjM	=	C{11}	C{12}	C{13} T(转置)
			C{21}	C{22}	C{23}
			C{31}	C{32}	C{33}

		=	6		-2		-2	T(转置)
			9		1		13
			0		-8		-8

		=   6		9		0
			-2		1		-8
			-2		13		-8
|M| = -24;
(M-1)(矩阵的逆) = (adjM)(标准伴随矩阵) / |M|(矩阵行列式的模)
			   = (adjM)(标准伴随矩阵)  * -1/24
			   = -1/24	-3/8	0
				 1/12	-1/24	1/3
				 1/12	-13/24	1/3
*/
Matrix4x3 inverse(const Matrix4x3 & m)
{
	//矩阵的行列式的模
	float det = determinant(m);
	assert(fabs(det) > 0.00001f);
	float oneOverDet = 1.0f / det;
	//伴随矩阵的计算
	Matrix4x3 adjM;
	adjM.m11 =  (m.m22*m.m33 - m.m23*m.m32);  adjM.m12 = -(m.m21*m.m33 - m.m23*m.m31); adjM.m13 =  (m.m21*m.m32 - m.m22*m.m31);
	adjM.m21 = -(m.m12*m.m33 - m.m13*m.m32);  adjM.m22 =  (m.m11*m.m33 - m.m13*m.m31); adjM.m23 = -(m.m11*m.m32 - m.m12*m.m31);
	adjM.m31 =  (m.m12*m.m23 - m.m13*m.m22);  adjM.m32 = -(m.m11*m.m23 - m.m13*m.m21); adjM.m33 =  (m.m11*m.m22 - m.m12*m.m21);

	Matrix4x3 adjMT = transpose(adjM);
	return  adjMT * oneOverDet;
}

/*平移*/
void Matrix4x3::zeroTranslation()
{
	tx = ty = tx = 0.0f;
}
void Matrix4x3::setTranslation(const Vector3 & t)
{
	tx = t.x;
	ty = t.y;
	tz = t.z;
}
void Matrix4x3::setUpTranslation(const Vector3 & t)
{
	m11 = 1;	m12 = 0;	m13 = 0;
	m21 = 0;	m22 = 1;	m23 = 0;
	m31 = 0;	m32 = 0;	m33 = 1;
	tx = t.x;	ty = t.y;	tz = t.z;
}

Vector3 getTranslation(const Matrix4x3 & m)
{
	return Vector3(m.tx, m.ty, m.tz);
}
