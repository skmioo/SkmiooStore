#include "Vector3.h"
#include "Matrix3x3.h"
Matrix3x3 operator *(const Matrix3x3 &a, const Matrix3x3 &b) 
{
	Matrix3x3 v;
	v.m11 = a.m11*b.m11 + a.m12*b.m21 + a.m13*b.m31;
	v.m12 = a.m11*b.m12 + a.m12*b.m22 + a.m13*b.m32;
	v.m13 = a.m11*b.m13 + a.m12*b.m23 + a.m13*b.m33;
	v.m21 = a.m21*b.m11 + a.m22*b.m21 + a.m23*b.m31;
	v.m22 = a.m21*b.m12 + a.m22*b.m22 + a.m23*b.m32;
	v.m23 = a.m21*b.m13 + a.m22*b.m23 + a.m23*b.m33;
	v.m31 = a.m31*b.m11 + a.m32*b.m21 + a.m33*b.m31;
	v.m32 = a.m31*b.m12 + a.m32*b.m22 + a.m33*b.m32;
	v.m33 = a.m31*b.m13 + a.m32*b.m23 + a.m33*b.m33;
	return v;
}

Vector3 operator *(const Vector3 &v, const Matrix3x3 &m)
{
	return Vector3(
		v.x * m.m11 + v.y * m.m21 + v.z * m.m31,
		v.x * m.m12 + v.y * m.m22 + v.z * m.m32,
		v.x * m.m13 + v.y * m.m23 + v.z * m.m33
	);
}

Vector3& operator *=(Vector3 &v, const Matrix3x3 &m)
{
	v = v * m;
	return v;
}

Matrix3x3& operator *=(Matrix3x3 &a, const Matrix3x3 &b)
{
	a = a * b;
	return a;
}

/*
axis 旋转轴 1：x轴 2:y轴 3:z轴
*/
void Matrix3x3::setRotate(int axis, float theta)
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
}

void Matrix3x3::setScale(const float kx, const float ky, const float kz)
{
	m11 = kx;	m12 = 0;	m13 = 0;
	m21 = 0;	m22 = ky;	m23 = 0;
	m31 = 0;	m32 = 0;	m33 = kz;
}

void Matrix3x3::setScale(const Vector3 & scale)
{
	m11 = scale.x;	m12 = 0;	m13 = 0;
	m21 = 0;	m22 = scale.y;	m23 = 0;
	m31 = 0;	m32 = 0;	m33 = scale.z;
}

/*
	比如: 0 0 1 可以表示xy构成的平面
	Nx	Ny	Nz垂直向量构成的平面的投影矩阵:
	1+(0-1)Nx^2	(0-1)NxNy	(0-1)NxNz
	(0-1)NxNy	1+(0-1)Ny^2	(0-1)NyNz
	(0-1)NxNz	(0-1)NzNy	1+(0-1)Nz^2
	n要为单位向量
*/
void Matrix3x3::setProject(const Vector3 & n)
{
	Vector3 v(n);
	v.normalize();
	m11 = 1.0f - v.x * n.x;
	m22 = 1.0f - v.y * v.y;
	m33 = 1.0f - v.z * v.z;

	m12 = m21 = -v.x * v.y;
	m13 = m31 = -v.x * v.z;
	m23 = m32 = -v.y * v.z;

}
