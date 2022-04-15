#pragma once
#include "Vector3.h"
//顶点
class Vertex
{
	Vector3 p;
	//其他信息
};

//三角形类
class Triangle
{
	int vertex[3];
	//其他信息
};

//三角形网格
class TriangleMesh
{
	int vertexCount;
	Vertex * vertexList;

	int triCount;
	Triangle * triList;
	
	//大量的网格操作
};