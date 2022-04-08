#pragma once
#include <math.h>
class  Vector3
{
public:
	float x, y, z;
	Vector3() {}
	Vector3(const Vector3 &a) : x(a.x), y(a.y), z(a.z) {}
	Vector3(float nx, float ny, float nz) : x(nx), y(ny), z(nz) {}
	//零向量
	void zero() { x = y = z = 0.0f; }
	Vector3 operator-() const { return Vector3(-x, -y, -z); }
	Vector3 operator*(float k) const { return Vector3(k * x, k * y, k * z); }
	Vector3 operator*=(float k) {
		x *= k;
		y *= k;
		z *= k;
		return *this;
	}
	Vector3 operator/(float k) const
	{
		float oneOverK = 1.0f / k;
		return Vector3(x * oneOverK, y * oneOverK, z * oneOverK);
	}

	Vector3 operator/=(float k)
	{
		float oneOverK = 1.0f / k;
		x *= oneOverK;
		y *= oneOverK;
		z *= oneOverK;
		return *this;
	}
	
	Vector3 operator+(const Vector3 & v) const
	{
		return Vector3(x + v.x, y + v.y, z + v.z);
	}

	Vector3 operator-(const Vector3 & v) const
	{
		return Vector3(x - v.x, y - v.y, z - v.z);
	}


	Vector3 operator+=(const Vector3 & v)
	{
		x += v.x;
		y += v.y;
		z += v.z;
		return *this;
	}

	Vector3 operator-=(const Vector3 & v)
	{
		x -= v.x;
		y -= v.y;
		z -= v.z;
		return *this;
	}

	void normalize()
	{
		float magSq = x * x + y * y + z * z;
		if (magSq > 0.0f)
		{
			float oneOverMag = 1.0f / sqrt(magSq);
			x *= oneOverMag;
			y *= oneOverMag;
			z *= oneOverMag;
		}
	}

	float operator *(const Vector3& v) const
	{
		return x * v.x + y * v.y + z * v.z;
	}

	~Vector3() {}
private:

};

//模
inline float vectorMag(const Vector3 & a)
{
	return sqrt(a.x * a.x + a.y * a.y + a.z * a.z);
}

inline Vector3 operator*(float k, const Vector3 &v)
{
	return Vector3(k* v.x, k * v.y, k *v.z);
}


inline float distance(const Vector3 & v1, const Vector3 & v2)
{
	return vectorMag(v1 - v2);
}

/*
	v1*v2 = ||v1|| * ||v2|| * cos()
	180度
*/
inline float vector3Angle(const Vector3 & v1, const Vector3 & v2)
{
	float dotValue = v1 * v2;
	float magV1 = vectorMag(v1);
	float magV2 = vectorMag(v2);
	float angle = acos(dotValue / (magV1 * magV2)) * 180 / 3.1415926;
	return angle;
}

inline Vector3 cross(const Vector3 &v1, const Vector3 &v2)
{
	return Vector3(
		v1.y * v2.z - v1.z * v2.y,
		v1.z * v2.x - v1.x * v2.z,
		v1.x * v2.y - v1.y * v2.x
	);
}