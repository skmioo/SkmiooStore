#pragma once
#include "Vector3.h"
class RotationMatrix;
class EulerAngles;
class Quaternion
{
public:
	float w, x, y, z;

	void identity() { w = 1; x = y =z = 0;  }

	void setToRotateAboutX(float theta);
	void setToRotateAboutY(float theta);
	void setToRotateAboutZ(float theta);
	void setToRotateAboutZ(const Vector3 &axis, float theta);

	float getRotationAngle() const;
	Vector3 getRotationAxis() const;
	/*
		此处的叉乘改为了点乘 v1 x v2 => v1 * v2
		^^!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!^^
		关于四元数的叉乘跟点乘，如果是叉乘，那么旋转从右往左，如果是点乘，
		旋转从左往右计算，所以，代码中叉乘使用的是点乘，方便旋转的从左往右
		^^!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!^^
		叉乘:
		q1q2 = [w1 v1][w1 v2]
		 = [w1 (x1 y1 z1)][w1 (x1 y1 z1)]
		 = [w1*w2-v1*v2		w1*v2 + w2*v1 + v1 x v2]
		改为点乘:
		q1q2 = [w1 v1][w1 v2]
		 = [w1 (x1 y1 z1)][w1 (x1 y1 z1)]
		 = [w1*w2-v1*v2		w1*v2 + w2*v1 + v1 * v2]
	*/
	Quaternion operator*(const Quaternion & a) const;
	Quaternion &operator*=(const Quaternion & a);
	//从旋转矩阵得到四元数
	void fromRotationMatrix(const RotationMatrix &m);
	//从欧拉角得到四元数
	void setToRotateObjectToInertial(const EulerAngles &orientation);
	void setToRotateInertialToObject(const EulerAngles &orientation);
	void normalize();
};
/*
	四元数点乘
*/
extern float dotProduct(const Quaternion & a, const Quaternion & b);
extern const Quaternion kQuaternionIdentity;
//共轭
extern Quaternion conjugate(const Quaternion & q);
//求幂
extern Quaternion pow(const Quaternion & q, float exponent);

extern Quaternion slerp(const Quaternion &q0, const Quaternion &q1, float t);