#include "EulerAngles.h"
//#include "MathUtil.h"
#include "Quaternion.h"
#include <math.h>
/*
	以欧拉角设置旋转矩阵值
	以EulerAngles的Roll Pitch	Yaw顺序进行旋转
	Roll(以z轴旋转) (Bank)
	cos  sin	0
	-sin cos	0
	0	 0		1
	Pitch(以x轴旋转)
	1	0	 0
	0	cos	 sin
	0	-sin cos
	Yaw(以y轴旋转) (Head)
	cos 0 -sin
	0	1	0
	sin 0 cos
	RPY的矩阵相乘结果
	cos(y)cos(r) + sin(y)sin(p)sin(r)	sin(r)cos(p)	-sin(y)cos(r) + cos(y)sin(p)sin(r)
	-cos(y)sin(r) + sin(y)sin(p)cos(r)	cos(r)cos(p)	sin(r)sin(y) + cos(y)sin(p)cos(r)
			sin(y)cos(p)					-sin(p)			cos(y)cos(p)
*/

/*
	计算欧拉角
	m32 = -sin(p);
	p = asin(-m32);

	m31 = sin(y)cos(p)
	m33 = cos(y)cos(p)
	sin(y) = m31 / cos(p);
	cos(y) = m33 / cos(p);
	tan(y) = sin(y) / cos(y)
	y      = atan(sin(y) / cos(y)) = atan2(sin(y) / cos(y))
								   = atan2(m31,m33);

	m12	= sin(r)cos(p)
	m22 = cos(r)cos(p)
	r	   = atan2(sin(r),cos(r))
		   = atan2(m12,m22);

*/

void EulerAngles::fromObjectToWorldMatrix(const Matrix4x3 & m)
{
	float sp = -m.m32;
	//检测万向锁
	if (fabs(sp) > 0.9999f)
	{
		pitch = kPiOver2 * sp;
		roll = 0.0f;
		yaw = atan2(-m.m23, m.m11);
	}
	else
	{
		yaw = atan2(m.m31, m.m33);
		pitch = asin(sp);
		roll = atan2(m.m12, m.m22);
	}
}


void EulerAngles::fromWorldToObjectMatrix(const Matrix4x3 & m)
{
	float sp = -m.m23;
	//检测万向锁
	if (fabs(sp) > 0.9999f)
	{
		pitch = kPiOver2 * sp;
		yaw = atan2(-m.m31, m.m11);
		roll = 0.0f;
	}
	else
	{
		yaw = atan2(m.m13, m.m33);
		pitch = asin(sp);
		roll = atan2(m.m21, m.m22);
	}
}


void EulerAngles::fromRotationMatrix(const RotationMatrix & m)
{
	float sp = -m.m23;
	//检测万向锁
	if (fabs(sp) > 0.9999f)
	{
		pitch = kPiOver2 * sp;
		yaw = atan2(-m.m31, m.m11);
		roll = 0.0f;
	}
	else
	{
		yaw = atan2(m.m13, m.m33);
		pitch = asin(sp);
		roll = atan2(m.m21, m.m22);
	}
}


void EulerAngles::fromObjectToInertialQuaternion(const Quaternion &q)
{
	float sp = -2.0f * (q.y *q.z - q.w *q.x);
	if (fabs(sp) > 0.9999f)
	{
		pitch = kPiOver2 * sp;
		yaw = atan2(-q.x * q.z + q.w * q.y, 0.5f - q.y*q.y - q.z * q.z);
		roll = 0;
	}
	else
	{
		pitch = asin(sp);
		yaw = atan2(q.x*q.z + q.w*q.y, 0.5f - q.x*q.x - q.y *q.y);
		roll = atan2(q.x*q.y + q.w*q.z, 0.5f - q.x*q.x - q.z *q.z);
	}
}

void EulerAngles::fromInertialToObjectQuaternion(const Quaternion &q)
{
	float sp = -2.0f * (q.y *q.z + q.w *q.x);
	if (fabs(sp) > 0.9999f)
	{
		pitch = kPiOver2 * sp;
		yaw = atan2(-q.x * q.z - q.w * q.y, 0.5f - q.y*q.y - q.z * q.z);
		roll = 0;
	}
	else
	{
		pitch = asin(sp);
		yaw = atan2(q.x*q.z - q.w*q.y, 0.5f - q.x*q.x - q.y *q.y);
		roll = atan2(q.x*q.y - q.w*q.z, 0.5f - q.x*q.x - q.z *q.z);
	}
}

/*
	角度限制跟万向锁处理
*/
void EulerAngles::canonize()
{
	pitch = wrapPi(pitch);
	if (pitch < -kPiOver2)
	{
		pitch = -kPi - pitch;
		yaw += kPi;
		roll += kPi;
	}
	else if (pitch > kPiOver2)
	{
		pitch = kPi - pitch;
		yaw += kPi;
		roll += kPi;
	}

	if (fabs(pitch) > kPiOver2 - 1e-4)
	{
		//出现万向锁时，令roll为0，其值附加到yaw上，
		yaw += roll;
		roll = 0;
	}
	else
	{
		roll = wrapPi(roll);
	}

	yaw = wrapPi(yaw);

}
