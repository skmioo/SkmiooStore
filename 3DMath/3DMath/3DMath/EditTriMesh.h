#pragma once
#include "Vector3.h"
class EditTriMesh
{
public:
	//������
	class Vertex
	{
	public:
		Vertex() { setDefaults(); }
		void setDefaults();
		//����
		Vector3 p;
		//��������
		float u, v;
		//���㷨����
		Vector3 normal;
	};
	//��������
	class Tri
	{
	public:
		Tri() { setDefaults(); }
		void setDefaults();
		struct Vert
		{
			//ֻ���涥�������
			int index;
			float u, v;
		};
		Vert v[3];
		//������
		Vector3 normal;
	};

	EditTriMesh();
	~EditTriMesh();

	Vertex & vertex(int vertexIndex);
	const Vertex & vertex(int vertexIndex) const;
	Tri&tri(int triIndex);
	int vertexCount() const { return vCount; }
	const Tri&tri(int triIndex) const;
	int triCount() const { return tCount; }
	void construct();
	void empty();
	//���Ӷ���
	int addVertex();
	int addVertex(const Vertex &v);
	void setVertexCount(int vc);
	//����������
	int addTri();
	int addTri(const Tri &t);
	void setTriCount(int tc);
	//����һ�������εķ�����
	void computeOneTriNormal(Tri & t);
	void computeOneTriNormal(int triIndex);
	void computeAllTriNormal();
	//���㶥��ķ�����(������Χ�����εķ�����֮��)
	void computeAllVertexNormal();

private:
	int vAlloc;
	int vCount;
	Vertex *vList;
	int tAlloc;
	int tCount;
	Tri * tList;
};
