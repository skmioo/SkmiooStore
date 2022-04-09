#include "RotationMatrix.h"
//单位矩阵
void RotationMatrix::identity()
{
	m11 = 1;	m12 = 0;	m13 = 0;
	m21 = 0;	m22 = 1;	m23 = 0;
	m31 = 0;	m32 = 0;	m33 = 1;
}

//从惯性坐标系转换为物体坐标系
Vector3 RotationMatrix::inertialToObject(const Vector3 & v) const
{

	return Vector3();
}

//从物体坐标系转换为惯性坐标系
Vector3 RotationMatrix::objectToInertial(const Vector3 & v) const
{
	return Vector3();
}
