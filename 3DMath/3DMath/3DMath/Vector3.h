#pragma once
class  Vector3
{
public:
	float x, y, z;
	Vector3() {}
	Vector3(const Vector3 &a) : x(a.x), y(a.y), z(a.z) {}
	Vector3(float nx, float ny, float nz) : x(nx), y(ny), z(nz) {}
	//¡„œÚ¡ø
	void zero() { x = y = z = 0.0f; }
	~Vector3() {}
private:

};