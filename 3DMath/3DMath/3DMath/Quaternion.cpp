#include "Quaternion.h"
#include "MathUtil.h"
#include <assert.h>
#include "RotationMatrix.h"
#include "EulerAngles.h"
const Quaternion kQuaternionIdentity = {1.0f, 0.0f, 0.0f, 0.0f};

/*
	四元数表示旋转
	q = [cos(θ/2) sin(θ/2)n]
	设置四元数的值
*/
void Quaternion::setToRotateAboutX(float theta)
{
	float thetaOver2 = theta * 0.5f;
	w = cos(thetaOver2);
	x = sin(thetaOver2);
	y = 0.0f;
	z = 0.0f;
}

/*
	四元数表示旋转
	q = [cos(θ/2) sin(θ/2)n]
	设置四元数的值
*/
void Quaternion::setToRotateAboutY(float theta)
{
	float thetaOver2 = theta * 0.5f;
	w = cos(thetaOver2);
	x = 0.0f;
	y = sin(thetaOver2);
	z = 0.0f;
}

/*
	四元数表示旋转
	q = [cos(θ/2) sin(θ/2)n]
	设置四元数的值
*/
void Quaternion::setToRotateAboutZ(float theta)
{
	float thetaOver2 = theta * 0.5f;
	w = cos(thetaOver2);
	x = 0.0f;
	y = 0.0f;
	z = sin(thetaOver2);
}
/*
	设置四元数的值
*/
void Quaternion::setToRotateAboutZ(const Vector3 & axis, float theta)
{
	Vector3 axis2 = axis;
	axis2.normalize();
	float thetaOver2 = theta * 0.5f;
	w = cos(thetaOver2);
	x = sin(thetaOver2) * axis2.x;
	y = sin(thetaOver2) * axis2.y;
	z = sin(thetaOver2) * axis2.z;
}

/*
	通过四元数的值获取旋转角度
*/
float Quaternion::getRotationAngle() const
{
	return safeAcos(w) * 2.0f;
}

/*
	通过四元数的值获取旋转轴
	q = [cos(θ/2) sin(θ/2)n]
*/
Vector3 Quaternion::getRotationAxis() const
{
	//sin(θ/2) = sqrt(1 - cos(θ/2) * cos(θ/2))
	float sinThetaOver2= sqrt(1.0f - w*w);
	float v = 1.0f / sinThetaOver2;
	return Vector3(x * v, y * v, z * v);
}

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
Quaternion Quaternion::operator*(const Quaternion & a) const
{
	Quaternion result;
	result.w = w * a.w - x*a.x - y * a.y - z * a.z;
	result.x = w * a.x + x * a.w + z * a.y - y * a.z;
	result.y = w * a.y + y * a.w + x * a.z - z * a.x;
	result.z = w * a.z + z * a.w + y * a.x - x * a.y;
	return result;
}

/*
	四元数点乘
*/
float dotProduct(const Quaternion & a, const Quaternion & b)
{
	return a.w * b.w + a.x * b.x + a.y * b.y + a.z * b.z;
}
/*
	共轭
*/
Quaternion conjugate(const Quaternion & q)
{
	Quaternion result;
	result.w = q.w;
	result.x = -q.x;
	result.y = -q.y;
	result.z = -q.z;
	return result;
}
/*
	求幂
*/
Quaternion pow(const Quaternion & q, float exponent)
{
	if (fabs(q.w) > 0.9999f)
	{
		return q;
	}
	float alpha = acos(q.w);
	float newAlpha = exponent * alpha;
	Quaternion result;
	result.w = cos(newAlpha);

	float mult = sin(newAlpha) / sin(alpha);
	result.x = q.x * mult;
	result.y = q.y * mult;
	result.z = q.z * mult;
	return result;
}


Quaternion &Quaternion::operator*=(const Quaternion & a)
{
	*this  = *this * a;
	return *this;
}

//从旋转矩阵得到四元数
void Quaternion::fromRotationMatrix(const RotationMatrix & m)
{
	float m11 = m.m11;
	float m12 = m.m12;
	float m13 = m.m13;
	
	float m21 = m.m21;
	float m22 = m.m22;
	float m23 = m.m23;

	float m31 = m.m31;
	float m32 = m.m32;
	float m33 = m.m33;

	float fourWSquaredMinus1 = m11 + m22 + m33;
	float fourXSquaredMinus1 = m11 - m22 - m33;
	float fourYSquaredMinus1 = m22 - m11 - m33;
	float fourZSquaredMinus1 = m33 - m11 - m22;
	int biggestIndex = 0;
	float fourBiggestSquaredMinus1 = fourWSquaredMinus1;
	if (fourBiggestSquaredMinus1 < fourXSquaredMinus1)
	{
		biggestIndex = 1;
		fourBiggestSquaredMinus1 = fourXSquaredMinus1;
	}

	if (fourBiggestSquaredMinus1 < fourYSquaredMinus1)
	{
		biggestIndex = 2;
		fourBiggestSquaredMinus1 = fourYSquaredMinus1;
	}

	if (fourBiggestSquaredMinus1 < fourZSquaredMinus1)
	{
		biggestIndex = 3;
		fourBiggestSquaredMinus1 = fourZSquaredMinus1;
	}
	
	float biggestValue = sqrt(fourBiggestSquaredMinus1 + 1.0f) * 0.5f;
	float mult = 0.25f / biggestValue;
	switch (biggestIndex)
	{
	case 0:
		w = biggestValue;
		x = (m23 - m32) * mult;
		y = (m31 - m13) * mult;
		z = (m12 - m21) * mult;
		break;

	case 1:
		x = biggestValue;
		w = (m23 - m32) * mult;
		y = (m12 + m21) * mult;
		z = (m31 + m13) * mult;
		break;

	case 2:
		y = biggestValue;
		w = (m31 - m13) * mult;
		x = (m12 + m21) * mult;
		z = (m23 + m32) * mult;
		break;

	case 3:

		z = biggestValue;
		w = (m12 - m21) * mult;
		x = (m31 + m13) * mult;
		y = (m23 + m32) * mult;
		break;
	default:
		break;
	}
}

//从欧拉角得到四元数
void Quaternion::setToRotateObjectToInertial(const EulerAngles &orientation)
{
	float sp, sr, sy;
	float cp, cr, cy;
	sinCos(&sp, &cp, orientation.pitch * 0.5f);
	sinCos(&sr, &cr, orientation.roll * 0.5f);
	sinCos(&sy, &cy, orientation.yaw * 0.5f);
	w = cy * cp * cr + sy * sp * sr;
	x = cy * sp * cr + sy * cp * sr;
	y = -cy * sp * sr + sy * cp * cr;
	z = -sy * sp * cr + cy * cp * sr;
}

void Quaternion::setToRotateInertialToObject(const EulerAngles &orientation)
{
	float sp, sr, sy;
	float cp, cr, cy;
	sinCos(&sp, &cp, orientation.pitch * 0.5f);
	sinCos(&sr, &cr, orientation.roll * 0.5f);
	sinCos(&sy, &cy, orientation.yaw * 0.5f);
	w = cy * cp * cr + sy * sp * sr;
	x = -cy * sp * cr - sy * cp * sr;
	y = cy * sp * sr - sy * cp * cr;
	z = sy * sp * cr - cy * cp * sr;
}

/*
	规范化
*/
void Quaternion::normalize()
{
	float mag = (float)sqrt(w * w + x * x + y * y + z * z);
	if (mag > 0.0f)
	{
		float oneOverMag = 1.0f / mag;
		w = w * oneOverMag;
		x = x * oneOverMag;
		y = y * oneOverMag;
		z = z * oneOverMag;
	}
	else
	{
		assert(false);
		identity();
	}
}

Quaternion slerp(const Quaternion &q0, const Quaternion &q1, float t)
{
	if (t <= 0) return q0;
	if (t >= 1.0f) return q1;
	float cosOmega = dotProduct(q0, q1);
	float q1w = q1.w;
	float q1x = q1.x;
	float q1y = q1.y;
	float q1z = q1.z;
	if (cosOmega < 0)
	{
		q1w = -q1w;
		q1x = -q1x;
		q1y = -q1y;
		q1z = -q1z;
		cosOmega = -cosOmega;		
	}
	float k0, k1;
	if (cosOmega > 0.9999f)
	{
		k0 = 1.0f - t;
		k1 = t;
	}
	else
	{
		float sinOmega = sqrt(1.0f - cosOmega * cosOmega);
		float omage = atan2(sinOmega, cosOmega);
		float oneOverSinOmega = 1.0f / sinOmega;
		k0 = sin((1.0f - t) * omage) * oneOverSinOmega;
		k1 = sin(t * omage) * oneOverSinOmega;
	}
	Quaternion result;
	result.x = k0 * q0.x + k1 * q1x;
	result.y = k0 * q0.y + k1 * q1y;
	result.z = k0 * q0.z + k1 * q1z;
	result.w = k0 * q0.w + k1 * q1w;
	return result;
}