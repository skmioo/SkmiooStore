#pragma once
#include <math.h>

const float kPi = 3.14159265f;
const float k2Pi = kPi * 2.0f;
const float kPiOver2 = kPi * 0.5f;

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