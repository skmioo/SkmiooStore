#pragma once
/*
�ԽǾ��� D
3 0 0 0
0 1 0 0
0 0 -5 0
0 0 0 2

��λ���� I
1 0 0 0 
0 1 0 0
0 0 1 0
0 0 0 1

������Ϊ����ʹ��
������ [1 2 3]  
������
	   [4
		5
		6]

ת�� T
a b c
d e f
g h i
=>
a d g
b e h
c f i

�������(�м����ȡ��ͷ)
A(rn) B(nc)
rn 4x2(4��2��)
nc 2x5(2��5��)
�ó�
AB(rc)
rc 4x5(4��5��)

A			B
-3	0		-7	2
5	0.5		4	6

A*B
-3*-7 + 0*4		-3*2 + 0*6
5*-7 + 0.5*4	5*2 + 0.5*6		
=>
21	-6
-33	13

��λ����˷�
IM = MI = M

����˷�
AB != BA
(AB)C = A(BC)
k(AB) = (kA)B = A(kB)
(ABC)T = (CT)(BT)(AT)

����������� ���������ұ�
[x y z] * [m11 m12 m13
		   m21 m22 m23
		   m31 m32 m33]
1x3		3x3
[xm11+ym21+zm31 xm12+ym22+zm32 xm13+ym23+zm33]
=> 1x3

[m11 m12 m13    [x
 m21 m22 m23  *	 y
 m31 m32 m33]	 z]

 3x3			3x1
[m11x+m12y+m13z
 m21x+m22y+m23z
 m31x+m32y+m33z]
 => 3x1

������v��������,����任(�Ƽ�):
vABC
��v��������,����任:
CBAv

DirectXʹ�õ���������
OpenGLʹ�õĵ�������(Unity shader��)

-------------------------------------
��ת����(�������������ת)
2d��ת����
x�� (1,0) -> cos() sin()
y�� (0,1) -> -sin() cos()
����ת�Ƕ�Ϊ0ʱ,���������� 
1	0
0	1

cos() sin()
-sin() cos()
3d��ת����
��x����ת
y�� (0, 1, 0) -> (0, cos(), sin())
z�� (0, 0, 1) -> (0, -sin(), cos())
��ת����
1	0	 0
0	cos	 sin
0	-sin cos
��y����ת
x�� (1, 0, 0) -> (cos(), 0, -sin())
z�� (0, 0, 1) -> (sin(), 0, cos())
��ת����
cos 0 -sin
0	1	0	
sin 0 cos
��z����ת
x�� (1, 0, 0) -> (cos(), sin(), 0)
y�� (0, 1, 0) -> (-sin(), cos(), 0)
��ת����
cos  sin	0
-sin cos	0
0	 0		1
-------------------------------------

-------------------------------------
���ž���
kx	0	0
0	ky	0
0	0	kz

X Y Z

=>
kxX	kyY	kzZ

-------------------------------------

-------------------------------------
ͶӰ����
Pxy 
1	0	0
0	1	0
0	0	0
Pxz
1	0	0
0	0	0
0	0	1
Pyz
0	0	0
0	1	0
0	0	1

ͶӰ������ƽ��
ƽ���Դ�ֱ��������ʾһ��ƽ��
����: 0 0 1 ���Ա�ʾxy���ɵ�ƽ��
Nx	Ny	Nz��ֱ�������ɵ�ƽ���ͶӰ����:
1+(0-1)Nx^2	(0-1)NxNy	(0-1)NxNz
(0-1)NxNy	1+(0-1)Ny^2	(0-1)NyNz
(0-1)NxNz	(0-1)NzNy	1+(0-1)Nz^2


-------------------------------------


*/
#include "MathUtil.h"

//Vector3����(���ư���ͷ�ļ�)
class Vector3;

class  Matrix3x3
{
public:
	float m11, m12, m13;
	float m21, m22, m23;
	float m31, m32, m33;
	Matrix3x3() {}

	void setRotate(int axis, float theta);

	void setScale(const float kx, const float ky, const float kz);
	void setScale(const Vector3 &scale);
	void setProject(const Vector3 &n);
};
//����˷�
Matrix3x3 operator *(const Matrix3x3 &a, const Matrix3x3 &b);
//����������˷�
Vector3 operator *(const Vector3 &v, const Matrix3x3 &m);
Vector3& operator *=(Vector3 &v, const Matrix3x3 &m);
Matrix3x3& operator *=(Matrix3x3 &a, const Matrix3x3 &b);
