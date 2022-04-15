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
		�˴��Ĳ�˸�Ϊ�˵�� v1 x v2 => v1 * v2
		^^!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!^^
		������Ԫ���Ĳ�˸���ˣ�����ǲ�ˣ���ô��ת������������ǵ�ˣ�
		��ת�������Ҽ��㣬���ԣ������в��ʹ�õ��ǵ�ˣ�������ת�Ĵ�������
		^^!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!^^
		���:
		q1q2 = [w1 v1][w1 v2]
		 = [w1 (x1 y1 z1)][w1 (x1 y1 z1)]
		 = [w1*w2-v1*v2		w1*v2 + w2*v1 + v1 x v2]
		��Ϊ���:
		q1q2 = [w1 v1][w1 v2]
		 = [w1 (x1 y1 z1)][w1 (x1 y1 z1)]
		 = [w1*w2-v1*v2		w1*v2 + w2*v1 + v1 * v2]
	*/
	Quaternion operator*(const Quaternion & a) const;
	Quaternion &operator*=(const Quaternion & a);
	//����ת����õ���Ԫ��
	void fromRotationMatrix(const RotationMatrix &m);
	//��ŷ���ǵõ���Ԫ��
	void setToRotateObjectToInertial(const EulerAngles &orientation);
	void setToRotateInertialToObject(const EulerAngles &orientation);
	void normalize();
};
/*
	��Ԫ�����
*/
extern float dotProduct(const Quaternion & a, const Quaternion & b);
extern const Quaternion kQuaternionIdentity;
//����
extern Quaternion conjugate(const Quaternion & q);
//����
extern Quaternion pow(const Quaternion & q, float exponent);

extern Quaternion slerp(const Quaternion &q0, const Quaternion &q1, float t);