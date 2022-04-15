#pragma once
#include "RotationMatrix.h"
#include "Matrix4x3.h"
class Quaternion;
class EulerAngles
{
public:
	//ÈÆYÖáÐý×ª heading
	float yaw;
	//ÈÆxÖáÐý×ª 
	float pitch;
	//ÈÆzÖáÐý×ª Bank
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

