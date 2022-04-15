#pragma once
#include "Vector3.h"
#include "Matrix4x3.h"
class AABB3
{
public:
	Vector3 min;
	Vector3 max;
	
	Vector3 size() const { return max - min; }

	float xSize() { return max.x - min.x; }
	float ySize() { return max.y - min.y; }
	float zSize() { return max.z - min.z; }
	//中心
	Vector3 center() { return (min + max) * 0.5f; }
	//8个角的位置
	/*
		  6---7
		 /|  /|
		2---3 |
		| 4-|-5
		|/  |/
		0---1
	*/
	Vector3 corner(int i) const;

	void empty();

	bool isEmpty() const;

	void add(const Vector3 &p);
	void add(const AABB3 &box);

	bool contains(const Vector3 &p) const;

	void setToTransformedBox(const AABB3 &box, const Matrix4x3 &m);

	//AABB3上距离p点最近的点 
	Vector3 closestPointTi(const Vector3 & p) const;
};
