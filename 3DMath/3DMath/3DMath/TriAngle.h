#pragma once
#include "Vector3.h"
//����
class Vertex
{
	Vector3 p;
	//������Ϣ
};

//��������
class Triangle
{
	int vertex[3];
	//������Ϣ
};

//����������
class TriangleMesh
{
	int vertexCount;
	Vertex * vertexList;

	int triCount;
	Triangle * triList;
	
	//�������������
};