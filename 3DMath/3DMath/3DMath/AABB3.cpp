#include "AABB3.h"
#include <assert.h>

/*	
	  6---7
	 /|  /|
	2---3 |
	| 4-|-5
 	|/  |/
	0---1
*/
Vector3 AABB3::corner(int i) const
{
	assert(i >= 0);
	assert(i <= 7);
	return Vector3(	(i & 1) ? max.x : min.x,
					(i & 2) ? max.y : min.y,
					(i & 4) ? max.z : min.z);

}

void AABB3::empty()
{
	float kBigNumber = 1e37f;
	min.x = min.y = min.z = kBigNumber;
	max.x = max.y = max.z = -kBigNumber;
}

bool AABB3::isEmpty() const
{
	return (min.x > max.x || min.y > max.y || min.z > max.z);
}

void AABB3::add(const Vector3 & p)
{
	if (p.x < min.x) min.x = p.x;
	if (p.x > max.x) max.x = p.x;

	if (p.y < min.y) min.y = p.y;
	if (p.y > max.y) max.y = p.y;

	if (p.z < min.z) min.z = p.z;
	if (p.z > max.z) max.z = p.z;

}

void AABB3::add(const AABB3 & box)
{
	if (box.min.x < min.x) min.x = box.min.x;
	if (box.max.x > max.x) max.x = box.max.x;

	if (box.min.y < min.y) min.y = box.min.y;
	if (box.max.y > max.y) max.y = box.max.y;
	
	if (box.min.z < min.z) min.z = box.min.z;
	if (box.max.z > max.z) max.z = box.max.z;

}

bool AABB3::contains(const Vector3 & p) const
{
	return (p.x >= min.x && p.x <= max.x)&&
		(p.y >= min.y && p.y <= max.y) &&
		(p.z >= min.z && p.z <= max.z);
}

void AABB3::setToTransformedBox(const AABB3 & box, const Matrix4x3 & m)
{
	if (box.isEmpty())
	{
		empty();
		return;
	}

	min = max = getTranslation(m);
	if (m.m11 > 0.0f)
	{
		min.x += m.m11 * box.min.x;	max.x += m.m11 * box.max.x;
	}
	else
	{
		min.x += m.m11 * box.max.x;	max.x += m.m11 * box.min.x;
	}

	if (m.m12 > 0.0f)
	{
		min.y += m.m12 * box.min.x;	max.y += m.m12 * box.max.x;
	}
	else
	{
		min.y += m.m12 * box.max.x;	max.y += m.m12 * box.min.x;
	}

	if (m.m13 > 0.0f)
	{
		min.z += m.m13 * box.min.x;	max.z += m.m13 * box.max.x;
	}
	else
	{
		min.z += m.m13 * box.max.x;	max.z += m.m13 * box.min.x;
	}

	if (m.m21 > 0.0f)
	{
		min.x += m.m21 * box.min.y;	max.x += m.m21 * box.max.y;
	}
	else
	{
		min.x += m.m21 * box.max.y;	max.x += m.m21 * box.min.y;
	}

	if (m.m22 > 0.0f)
	{
		min.y += m.m22 * box.min.y;	max.y += m.m22 * box.max.y;
	}
	else
	{
		min.y += m.m22 * box.max.y;	max.y += m.m22 * box.min.y;
	}

	if (m.m23 > 0.0f)
	{
		min.z += m.m23 * box.min.y;	max.z += m.m23 * box.max.y;
	}
	else
	{
		min.z += m.m23 * box.max.y;	max.z += m.m23 * box.min.y;
	}

	if (m.m31 > 0.0f)
	{
		min.x += m.m31 * box.min.z;	max.x += m.m31 * box.max.z;
	}
	else
	{
		min.x += m.m31 * box.max.z;	max.x += m.m31 * box.min.z;
	}

	if (m.m32 > 0.0f)
	{
		min.y += m.m32 * box.min.z;	max.y += m.m32 * box.max.z;
	}
	else
	{
		min.y += m.m32 * box.max.z;	max.y += m.m32 * box.min.z;
	}

	if (m.m33 > 0.0f)
	{
		min.z += m.m33 * box.min.z;	max.z += m.m33 * box.max.z;
	}
	else
	{
		min.z += m.m33 * box.max.z;	max.z += m.m33 * box.min.z;
	}

}
//AABB3上距离p点最近的点
Vector3 AABB3::closestPointTi(const Vector3 & p) const
{
	Vector3 r;
	if (p.x < min.x)
	{
		r.x = min.x;
	}
	else if(p.x > max.x)
	{
		r.x = max.x;
	}
	else
	{
		r.x = p.x;
	}

	if (p.y < min.y)
	{
		r.y = min.y;
	}
	else if (p.y > max.y)
	{
		r.y = max.y;
	}
	else
	{
		r.y = p.y;
	}

	if (p.z < min.z)
	{
		r.z = min.z;
	}
	else if (p.z > max.z)
	{
		r.z = max.z;
	}
	else
	{
		r.z = p.z;
	}
	return r;
}
