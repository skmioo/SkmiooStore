#pragma once
#include "RotationMatrix.h"
#include "Matrix4x3.h"
class Quaternion;
class EulerAngles
{
public:
	//��Y����ת heading
	float yaw;
	//��x����ת 
	float pitch;
	//��z����ת Bank
	float roll;
	EulerAngles() {}
	EulerAngles(float y,float p,float r):yaw(y),pitch(p),roll(r) {}

	void canonize();

	void fromObjectToWorldMatrix(const Matrix4x3 &m);
	void fromWorldToObjectMatrix(const Matrix4x3 &m);
	void fromRotationMatrix(const RotationMatrix &m);
	void fromObjectToInertialQuaternion(const Quaternion &q);
	void fromInertialToObjectQuaternion(const Quaternion &q);
};

