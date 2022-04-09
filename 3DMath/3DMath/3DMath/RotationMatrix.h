#pragma once
/*
	旋转矩阵
	世界坐标系-> 惯性坐标系(位移)	-> 物体坐标系(旋转)
*/
#include "Vector3.h"
class RotationMatrix
{

public:
	float m11, m12, m13;
	float m21, m22, m23;
	float m31, m32, m33;

	//单位矩阵
	void identity();

	//从惯性坐标系转换为物体坐标系
	Vector3 inertialToObject(const Vector3 &v) const;
	//从物体坐标系转换为惯性坐标系
	Vector3 objectToInertial(const Vector3 &v) const;
};
