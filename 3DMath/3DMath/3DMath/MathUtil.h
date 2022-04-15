#pragma once
#include <math.h>
#include "Vector3.h"
const float kPi = 3.14159265f;
const float k2Pi = kPi * 2.0f;
const float kPiOver2 = kPi * 0.5f;
const float k1Overpi = 1.0f / kPi;
const float k1Over2pi = 1.0f / k2Pi;

inline void sinCos(float * returnSin, float * returnCos, float theta)
{
	*returnSin = sin(theta);
	*returnCos = cos(theta);
}


inline void sinCos(float & returnSin, float & returnCos, float theta)
{
	returnSin = sin(theta);
	returnCos = cos(theta);
}

inline float LimitZeroF(float v)
{
	if (v > -0.00001f && v < 0.00001f)
		v = 0;
	return v;
}

inline float kPiAngle(float angle)
{
	return (angle / 180.0f) * kPi;
}
/*通过加上是的的2pi的倍数，讲角度限制在-pi到pi区间内*/
extern float wrapPi(float theta);

extern float safeAcos(float x);