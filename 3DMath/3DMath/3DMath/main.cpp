#include <iostream>
#include "Vector3.h"
#include "main.h"
#include "Matrix3x3.h"
#include "MathUtil.h"
using namespace std;

void print_v(const Vector3 v)
{
	cout << "[" << LimitZeroF(v.x)<< ","<< LimitZeroF(v.y) << "," << LimitZeroF(v.z) << "]" << endl;
}

void print_f(float v)
{
	cout << "[" << v << "]" << endl;
}

void print_Matrix3x3(Matrix3x3 m)
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
	Matrix3x3_Test();
	system("pause");
	return 0;
}

void Vector3_Test()
{
	//Vector3_Test_01();
	//Vector3_Test_02();
	Vector3_Test_03();
}

/*
*	P5 零向量 负向量 向量的模(vectorMag) 赋值 
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
*	P6 向量的乘法 除法 标准化(normalize)
*   向量的加法(位移) 减法(距离)
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
*	P7 向量
*		点乘(点乘的结果是一个数值，通过正负表示夹角) 也可以计算俩个向量的夹角
*		叉乘(结果是一个垂直于俩个向量的向量)  叉乘的模 ||axb|| = ||a|| ||b|| sin  (是俩个向量形成的四边形的面积)
*/
void Vector3_Test_03()
{
	//点乘
	Vector3 v1(3, -2, 7);
	Vector3 v2(0, 4, -1);
	print_f(v1 * v2);
	print_f(vector3Angle(v1, v2));
	//叉乘
	Vector3 v3(1, 3, 4);
	Vector3 v4(2, -5, 8);
	print_v(cross(v3, v4));
}


void Matrix3x3_Test()
{
	//Matrix3x3_Test_01();
	//Matrix3x3_Test_02();
	Matrix3x3_Test_03();
}

/*
p10 矩阵*矩阵
	行向量*矩阵
*/
void Matrix3x3_Test_01()
{
	//矩阵*矩阵
	Matrix3x3 a, b, c;
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
	//行向量*矩阵
	Vector3 v(3, -1, 4);
	Matrix3x3 m;
	m.m11 = -2;	m.m12 = 0;	m.m13 = 3;
	m.m21 = 5;	m.m22 = 7;	m.m23 = -6;
	m.m31 = 1;	m.m32 = -4;	m.m33 = 2;
	print_v(v * m);
	v *= m;
	print_v(v);
}
/*
p11	向量旋转 setRotate
*/
void Matrix3x3_Test_02()
{
	Vector3 a(10, 0, 0) ,b;
	Matrix3x3 M;
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
	p12 缩放
	setScale
	投影
	正交投影
	透视投影(近大远小)
*/
void Matrix3x3_Test_03()
{
	Vector3 a(10, 20, 30);
	//缩放系数
	Vector3 scale(1,2,3);
	Matrix3x3 m;
	m.setScale(scale);
	print_v(a * m);
	//投影
	//xy平面
	Vector3 n(0, 0, 1);
	m.setProject(n);
	print_Matrix3x3(m);
	print_v(a * m);
}

/*
	镜像
	
	切变
*/
void Matrix3x3_Test_04()
{

}