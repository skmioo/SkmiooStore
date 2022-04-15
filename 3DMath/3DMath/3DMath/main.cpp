#include <iostream>
#include "Vector3.h"
#include "main.h"
#include "Matrix4x3.h"
#include "MathUtil.h"
#include "EulerAngles.h"
#include "RotationMatrix.h"
#include "Line3D.h"
#include "EditTriMesh.h"
using namespace std;

//�Ƿ�Ϊ͹�����
bool isConvex(int n, const Vector3 vl[])
{
	float angleSum = 0;
	for (int i = 0; i < n; i++)
	{
		Vector3 e1;
		if (i == 0)
		{
			e1 = vl[n - 1] - vl[0];
		}
		else
		{
			e1 = vl[i - 1] - vl[i];
		}
		
		Vector3 e2;
		if (i == n- 1)
		{
			e1 = vl[0] - vl[i];
		}
		else
		{
			e2 = vl[i+1] - vl[i];
		}
		e1.normalize();
		e2.normalize();
		float dot = e1 * e2;
		float theta = safeAcos(dot);
		angleSum += theta;

	}
	float convexAngleSum = (float)(n - 2)*kPi;
	if (angleSum < convexAngleSum - (float)n * 0.0001f)
		return false;
	return true;
}

void print_v(const Vector3 v)
{
	cout << "[" << LimitZeroF(v.x)<< ","<< LimitZeroF(v.y) << "," << LimitZeroF(v.z) << "]" << endl;
}

void print_f(float v)
{
	cout << "[" << v << "]" << endl;
}

void print_Matrix3x3(Matrix4x3 m)
{
	cout << "Matrix:" << endl;
	cout << "[" << LimitZeroF(m.m11) << "\t" << LimitZeroF(m.m12) << "\t" << LimitZeroF(m.m13) << "]" << endl;
	cout << "[" << LimitZeroF(m.m21) << "\t" << LimitZeroF(m.m22) << "\t" << LimitZeroF(m.m23) << "]" << endl;
	cout << "[" << LimitZeroF(m.m31) << "\t" << LimitZeroF(m.m32) << "\t" << LimitZeroF(m.m33) << "]" << endl;
}


//https://www.bilibili.com/video/BV1ib411K7TK
int main()
{
	//Vector3_Test();
	//Matrix3x3_Test();
	//EulerAngles_Test();
	TriMeshTest();
	system("pause");
	return 0;
}

void TriMeshTest()
{
	EditTriMesh mesh;
	mesh.addTri();
	mesh.addVertex();
}

void Vector3_Test()
{
	//Vector3_Test_01();
	//Vector3_Test_02();
	Vector3_Test_03();
}

/*
*	P5 ������ ������ ������ģ(vectorMag) ��ֵ 
*/
void Vector3_Test_01()
{
	Vector3 v1(10, 20, 30);
	print_v(v1);
	Vector3 v2(v1);
	print_v(v2);
	Vector3 v3 = -v1;
	print_v(v3);
	v2.zero();
	print_v(v2);
	Vector3 v4(5, -4, 7);
	float r = vectorMag(v4);
	cout << r << endl;
}

/*
*	P6 �����ĳ˷� ���� ��׼��(normalize)
*   �����ļӷ�(λ��) ����(����)
*/
void Vector3_Test_02()
{
	Vector3 v1(-5, 0, 0.4);
	Vector3 v2 = v1 * -5;
	print_v(v2);
	Vector3 v5 = -5 * v1;
	print_v(v5);
	print_v(v1);
	v1 *= -5;
	print_v(v1);
	Vector3 v3(4.7, -6, 8);
	Vector3 v4 = v3 / 2;
	v3 /= 2;
	print_v(v3);
	print_v(v4);

	Vector3 v6(12, -5, 0);
	v6.normalize();
	print_v(v6);

	Vector3 a(1, 2, 3);
	Vector3 b(4, 5, 6);
	Vector3 r1 = a + b;
	Vector3 r2 = a - b;
	print_v(r1);
	print_v(r2);
	r1 += Vector3(2,2,2);
	print_v(r1);
	r1 -= Vector3(2, 2, 2);
	print_v(r1);

	Vector3 s1 = Vector3(5, 0, 0);
	Vector3 s2 = Vector3(-1, 8, 0);
	float dis = distance(s1, s2);
	cout << "dis:" << dis << endl;
}
/*
*	P7 ����
*		���(��˵Ľ����һ����ֵ��ͨ��������ʾ�н�) Ҳ���Լ������������ļн�
*		���(�����һ����ֱ����������������)  ��˵�ģ ||axb|| = ||a|| ||b|| sin  (�����������γɵ��ı��ε����)
*/
void Vector3_Test_03()
{
	//���
	Vector3 v1(3, -2, 7);
	Vector3 v2(0, 4, -1);
	print_f(v1 * v2);
	print_f(vector3Angle(v1, v2));
	//���
	Vector3 v3(1, 3, 4);
	Vector3 v4(2, -5, 8);
	print_v(cross(v3, v4));
}


void Matrix3x3_Test()
{
	//Matrix3x3_Test_01();
	//Matrix3x3_Test_02();
	//Matrix3x3_Test_03();
	//Matrix3x3_Test_04();
	//Matrix3x3_Test_05();
	//Matrix3x3_Test_06();
	Matrix3x3_Test_07();
}

/*
p10 ����*����
	������*����
*/
void Matrix3x3_Test_01()
{
	//����*����
	Matrix4x3 a, b, c;
	a.m11 = 1;	a.m12 = -5;	a.m13 = 3;
	a.m21 = 0;	a.m22 = -2;	a.m23 = 6;
	a.m31 = 7;	a.m32 = 2;	a.m33 = -4;

	b.m11 = -8;	b.m12 = 6;	b.m13 = 1;
	b.m21 = 7;	b.m22 = 0;	b.m23 = -3;
	b.m31 = 2;	b.m32 = 4;	b.m33 = 5;
	c = a * b;
	print_Matrix3x3(c);
	a *= b;
	print_Matrix3x3(a);
	//������*����
	Vector3 v(3, -1, 4);
	Matrix4x3 m;
	m.m11 = -2;	m.m12 = 0;	m.m13 = 3;
	m.m21 = 5;	m.m22 = 7;	m.m23 = -6;
	m.m31 = 1;	m.m32 = -4;	m.m33 = 2;
	print_v(v * m);
	v *= m;
	print_v(v);
}
/*
p11	������ת setRotate
*/
void Matrix3x3_Test_02()
{
	Vector3 a(10, 0, 0) ,b;
	Matrix4x3 M;
	M.setRotate(3, kPiOver2);
	b = a * M;
	print_Matrix3x3(M);
	print_v(b);
	M.setRotate(3, kPi);
	print_Matrix3x3(M);
	b = a * M;
	print_v(b);

	M.setRotate(1, -22.0f / 180 * kPi);
	print_Matrix3x3(M);
	M.setRotate(2, 30.0f / 180 * kPi);
	print_Matrix3x3(M);
}

/*
	p12 ����
	setScale
	ͶӰ
	����ͶӰ
	͸��ͶӰ(����ԶС)
*/
void Matrix3x3_Test_03()
{
	Vector3 a(10, 20, 30);
	//����ϵ��
	Vector3 scale(1,2,3);
	Matrix4x3 m;
	m.setScale(scale);
	print_v(a * m);
	//ͶӰ
	//xyƽ��
	Vector3 n(0, 0, 1);
	m.setProject(n);
	print_Matrix3x3(m);
	print_v(a * m);
}

/*
	����
	
	�б�
*/
void Matrix3x3_Test_04()
{
	//����
	Vector3 a(10, 20, 30), b;
	print_v(a);
	Matrix4x3 M;
	M.setReflect(1, 0);
	b = a * M;
	print_v(b);
	M.setReflect(2, 0);
	b = a * M;
	print_v(b);
	M.setReflect(3, 0);
	b = a * M;
	print_v(b);

	Vector3 n(0, 0, 1);
	M.setReflect(n);
	b = a * M;
	print_v(b);

	//�б�
	M.setShear(1, 1, 2);
	b = a * M;
	print_v(b);

}

/*
	p14
	����ʽ
*/
void Matrix3x3_Test_05()
{
	Matrix4x3 M;
	M.m11 = 3;	M.m12 = -2; M.m13 = 0;
	M.m21 = 1;	M.m22 = 4; M.m23 = -3;
	M.m31 = -1;	M.m32 = 0; M.m33 = 2;
	float detM = determinant(M);
	print_f(detM);
}

/*
	�������
*/
void Matrix3x3_Test_06()
{
	Matrix4x3 M;
	M.m11 = -4;	M.m12 = -3; M.m13 = 3;
	M.m21 = 0;	M.m22 = 2; M.m23 = -2;
	M.m31 = 1;	M.m32 = 4; M.m33 = -1;
	Matrix4x3 r = inverse(M);
	print_Matrix3x3(r);
	Matrix4x3 v1 = r * M;
	Matrix4x3 v2 = M *r;
	print_Matrix3x3(v1);
	print_Matrix3x3(v2);
}

/*
	��ת����
*/
void Matrix3x3_Test_07()
{
	RotationMatrix m;
	//��y��ת30��
	m.m11 = 0.866f;	m.m12 = 0;	m.m13 = -0.5f;
	m.m21 = 0;		m.m22 = 1;	m.m23 = 0;
	m.m31 = 0.5f;	m.m32 = 0;	m.m33 = 0.866f;

	Vector3 v(10, 20, 30);
	Vector3 v2;
	//��������ϵ����������ϵ
	v2 = m.inertialToObject(v);
	print_v(v2);
	Vector3 v3;
	//��������ϵ����������ϵ
	v3 = m.objectToInertial(v2);
	print_v(v3);
}

void EulerAngles_Test()
{
	EulerAngles_Test_01();
}

void EulerAngles_Test_01()
{
	RotationMatrix m;
	EulerAngles angle(kPiAngle(30.0f), 0, 0);
	m.setup(angle);
	Vector3 v(10,20,30);
	Vector3 v2;
	//��������ϵ����������ϵ
	v2 = m.inertialToObject(v);
	print_v(v2);
	Vector3 v3;
	//��������ϵ����������ϵ
	v3 = m.objectToInertial(v2);
	print_v(v3);
}

void EulerAngles_Test_02()
{

}

void EulerAngles_Test_03()
{

}

void EulerAngles_Test_04()
{

}

void EulerAngles_Test_05()
{

}
