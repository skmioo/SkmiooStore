#pragma once
/*
对角矩阵 D
3 0 0 0
0 1 0 0
0 0 -5 0
0 0 0 2

单位矩阵 I
1 0 0 0 
0 1 0 0
0 0 1 0
0 0 0 1

向量作为矩阵使用
行向量 [1 2 3]  
列向量
	   [4
		5
		6]

转置 T
a b c
d e f
g h i
=>
a d g
b e h
c f i

矩阵相乘(中间相等取俩头)
A(rn) B(nc)
rn 4x2(4行2列)
nc 2x5(2行5列)
得出
AB(rc)
rc 4x5(4行5列)

A			B
-3	0		-7	2
5	0.5		4	6

A*B
-3*-7 + 0*4		-3*2 + 0*6
5*-7 + 0.5*4	5*2 + 0.5*6		
=>
21	-6
-33	13

单位矩阵乘法
IM = MI = M

矩阵乘法
AB != BA
(AB)C = A(BC)
k(AB) = (kA)B = A(kB)
(ABC)T = (CT)(BT)(AT)

行向量放左边 列向量放右边
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

若向量v是行向量,矩阵变换(推荐):
vABC
若v是列向量,矩阵变换:
CBAv

DirectX使用的是行向量
OpenGL使用的的列向量(Unity shader中)

-------------------------------------
旋转矩阵(就是坐标轴的旋转)
2d旋转矩阵
x轴 (1,0) -> cos() sin()
y轴 (0,1) -> -sin() cos()
当旋转角度为0时,就是坐标轴 
1	0
0	1

cos() sin()
-sin() cos()
3d旋转矩阵
绕x轴旋转
y轴 (0, 1, 0) -> (0, cos(), sin())
z轴 (0, 0, 1) -> (0, -sin(), cos())
旋转矩阵
1	0	 0
0	cos	 sin
0	-sin cos
绕y轴旋转
x轴 (1, 0, 0) -> (cos(), 0, -sin())
z轴 (0, 0, 1) -> (sin(), 0, cos())
旋转矩阵
cos 0 -sin
0	1	0	
sin 0 cos
绕z轴旋转
x轴 (1, 0, 0) -> (cos(), sin(), 0)
y轴 (0, 1, 0) -> (-sin(), cos(), 0)
旋转矩阵
cos  sin	0
-sin cos	0
0	 0		1
-------------------------------------

-------------------------------------
缩放矩阵
kx	0	0
0	ky	0
0	0	kz

X Y Z

=>
kxX	kyY	kzZ

-------------------------------------

-------------------------------------
投影矩阵
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

投影到任意平面
平面以垂直的向量表示一个平面
比如: 0 0 1 可以表示xy构成的平面
Nx	Ny	Nz垂直向量构成的平面的投影矩阵:
1+(0-1)Nx^2	(0-1)NxNy	(0-1)NxNz
(0-1)NxNy	1+(0-1)Ny^2	(0-1)NyNz
(0-1)NxNz	(0-1)NzNy	1+(0-1)Nz^2


-------------------------------------


*/
#include "MathUtil.h"

//Vector3声明(类似包含头文件)
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
//矩阵乘法
Matrix3x3 operator *(const Matrix3x3 &a, const Matrix3x3 &b);
//矩阵跟向量乘法
Vector3 operator *(const Vector3 &v, const Matrix3x3 &m);
Vector3& operator *=(Vector3 &v, const Matrix3x3 &m);
Matrix3x3& operator *=(Matrix3x3 &a, const Matrix3x3 &b);
