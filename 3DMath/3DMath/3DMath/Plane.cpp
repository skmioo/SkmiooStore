#include "Plane.h"
#include "Vector3.h"
#include "MathUtil.h"

Vector3 computeBestFitNormal(const Vector3 v[], int n)
{
	Vector3 result = kZeroVector;
	const Vector3 * p = &v[n - 1];
	for (int i = 0; i < n; i++)
	{
		const Vector3 *c = &v[i];
		result.x += (p->z + c->z) * (p->y - c->y);
		result.y += (p->x + c->x) * (p->z - c->z);
		result.z += (p->y + c->y) * (p->x - c->x);
		p = c;
	}
	result.normalize();
	return result;
}
