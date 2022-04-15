#include "RotationMatrix.h"
#include "MathUtil.h"
#include "EulerAngles.h"
#include "Quaternion.h"
//单位矩阵
void RotationMatrix::identity()
{
	m11 = 1;	m12 = 0;	m13 = 0;
	m21 = 0;	m22 = 1;	m23 = 0;
	m31 = 0;	m32 = 0;	m33 = 1;
}
/*
	interial to object
				|m11 m12 m13|
	[ix iy iz]	|m21 m22 m23| = [ox oy oz]
				|m31 m32 m33|

	object to interial
				因为是正交矩阵所以用转置矩阵代替逆矩阵
				|m11 m21 m31|
	[ox oy oz]	|m12 m22 m32| = [ix iy iz]
				|m13 m23 m33|

*/

//从物体坐标系转换为惯性坐标系
Vector3 RotationMatrix::objectToInertial(const Vector3 & v) const
{
	return Vector3(v.x * m11 + v.y * m12 + v.z * m13,
		v.x * m21 + v.y * m22 + v.z * m23,
		v.x * m31 + v.y * m32 + v.z * m33);
}


//从惯性坐标系转换为物体坐标系
Vector3 RotationMatrix::inertialToObject(const Vector3 & v) const
{
	return Vector3( v.x * m11 + v.y * m21 + v.z * m31,
					v.x * m12 + v.y * m22 + v.z * m32,
					v.x * m13 + v.y * m23 + v.z * m33);
}

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
void RotationMatrix::setup(const EulerAngles &orientation)
{
	float sy, cy, sr, cr, sp, cp;
	sinCos(&sy, &cy, orientation.yaw);
	sinCos(&sp, &cp, orientation.pitch);
	sinCos(&sr, &cr, orientation.roll);
	m11 = cy * cr + sy * sp * sr;		m12 = sr * cp;		m13 = -sy * cr + cy * sp * sr;
	m21 = -cy * sr + sy * sp * cr;		m22 = cr * cp;		m23 = sr * sy + cy * sp * cr;
	m31 = sy * cp;						m32 = -sp;			m33 = cy * cp;
}
//从惯性到物体的四元数得到矩阵
void RotationMatrix::fromInerialToObjectQuaternion(const Quaternion & q)
{
	m11 = 1.0f - 2.0f*(q.y*q.y + q.z*q.z);
	m12 = 2.0f * (q.x*q.y + q.w*q.z);
	m13 = 2.0f * (q.x*q.z - q.w*q.y);
	
	m21 = 2.0f * (q.x*q.y - q.w*q.z);
	m22 = 1.0f - 2.0f * (q.x*q.x + q.z*q.z);
	m23 = 2.0f * (q.y*q.z + q.w*q.x);

	m31 = 2.0f * (q.x*q.z + q.w*q.y);
	m32 = 2.0f * (q.y*q.z - q.w*q.x);
	m33 = 1.0f - 2.0f * (q.x*q.x + q.y*q.y);

}
//从物体到惯性的四元数得到矩阵
void RotationMatrix::fromObjectToInerialQuaternion(const Quaternion & q)
{
	m11 = 1.0f - 2.0f*(q.y*q.y + q.z*q.z);
	m21 = 2.0f * (q.x*q.y + q.w*q.z);
	m31 = 2.0f * (q.x*q.z - q.w*q.y);

	m12 = 2.0f * (q.x*q.y - q.w*q.z);
	m22 = 1.0f - 2.0f * (q.x*q.x + q.z*q.z);
	m32 = 2.0f * (q.y*q.z + q.w*q.x);

	m13 = 2.0f * (q.x*q.z + q.w*q.y);
	m23 = 2.0f * (q.y*q.z - q.w*q.x);
	m33 = 1.0f - 2.0f * (q.x*q.x + q.y*q.y);
}