#pragma once
/*
	��ת����
	��������ϵ-> ��������ϵ(λ��)	-> ��������ϵ(��ת)
*/
#include "Vector3.h"
class Quaternion;
class EulerAngles;
class RotationMatrix
{

public:
	float m11, m12, m13;
	float m21, m22, m23;
	float m31, m32, m33;


	//��λ����
	void identity();

	void setup(const EulerAngles &orientation);

	//�ӹ�������ϵת��Ϊ��������ϵ 
	Vector3 inertialToObject(const Vector3 &v) const;
	//����������ϵת��Ϊ��������ϵ
	Vector3 objectToInertial(const Vector3 &v) const;
	//�ӹ��Ե��������Ԫ���õ�����
	void fromInerialToObjectQuaternion(const Quaternion &q);
	//�����嵽���Ե���Ԫ���õ�����
	void fromObjectToInerialQuaternion(const Quaternion &q);
};