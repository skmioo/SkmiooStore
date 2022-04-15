#include "EditTriMesh.h"
#include <string.h>
#include <stdlib.h>
#include <assert.h>
#include <iostream>
void EditTriMesh::Vertex::setDefaults()
{
	memset(this, 0, sizeof(this));
}

void EditTriMesh::Tri::setDefaults()
{
	memset(this, 0, sizeof(this));
}

EditTriMesh::EditTriMesh()
{
	construct();
}


void EditTriMesh::construct()
{
	vAlloc = 0;
	vCount = 0;
	vList = NULL;
	tAlloc = 0;
	tCount = 0;
	tList = NULL;
}


EditTriMesh::~EditTriMesh()
{
	empty();
}

EditTriMesh::Vertex & EditTriMesh::vertex(int vertexIndex)
{
	assert(vertexIndex >= 0);
	assert(vertexIndex < vCount);
	return vList[vertexIndex];
}

const EditTriMesh::Vertex & EditTriMesh::vertex(int vertexIndex) const
{
	assert(vertexIndex >= 0);
	assert(vertexIndex < vCount);
	return vList[vertexIndex];
}

EditTriMesh::Tri &EditTriMesh::tri(int triIndex)
{
	assert(triIndex >= 0);
	assert(triIndex < tCount);
	return tList[triIndex];
}

const EditTriMesh::Tri &EditTriMesh::tri(int triIndex) const
{
	assert(triIndex >= 0);
	assert(triIndex < tCount);
	return tList[triIndex];
}

void EditTriMesh::empty()
{
	if (vList != NULL)
	{
		free(vList);
		vList = NULL;
	}
	vAlloc = 0;
	vCount = 0;
	
	tAlloc = 0;
	tCount = 0;

	if (tList != NULL)
	{
		free(tList);
		tList = NULL;
	}
}


int EditTriMesh::addVertex()
{
	int r = vCount;
	if (vCount >= vAlloc)
	{
		setVertexCount(vCount + 1);
	}
	else
	{
		++vCount;
		vList[r].setDefaults();
	}
	return r;
}

int EditTriMesh::addVertex(const Vertex &v)
{
	int r = vCount;
	if (vCount >= vAlloc)
	{
		setVertexCount(vCount + 1);
	}
	else
	{
		++vCount;
	}
	vList[r] = v;
	return r;
}

void EditTriMesh::setVertexCount(int vc)
{
	assert(vc >= 0);
	assert(vCount <= vAlloc);
	if (vc > vCount)
	{
		if (vc > vAlloc)
		{
			vAlloc = (int)(vc * 4.0f / 3) + 10;
			vList = (Vertex *)realloc(vList, vAlloc * sizeof(*vList));
			if (vList == NULL)
			{
				printf("分配内存失败");
				return;
			}
		}
		while (vCount < vc)
		{
			vList[vCount].setDefaults();
			++vCount;
		}
	}
	else
	{
		vCount = vc;
	}
}




int EditTriMesh::addTri()
{
	int r = tCount;
	if (tCount >= tAlloc)
	{
		setTriCount(tCount + 1);
	}
	else
	{
		++tCount;
		tList[r].setDefaults();
	}
	return r;
}

int EditTriMesh::addTri(const Tri &t)
{
	int r = tCount;
	if (tCount >= tAlloc)
	{
		setTriCount(tCount + 1);
	}
	else
	{
		++tCount;
	}
	tList[r] = t;
	return r;
}

void EditTriMesh::setTriCount(int tc)
{
	assert(tc >= 0);
	assert(tCount <= tAlloc);
	if (tc > tCount)
	{
		if (tc > tAlloc)
		{
			tAlloc = (int)(tc * 4.0f / 3) + 10;
			tList = (Tri *)realloc(tList, tAlloc * sizeof(*tList));
			if (tList == NULL)
			{
				printf("分配内存失败");
				return;
			}
		}
		while (tCount < tc)
		{
			tList[tCount].setDefaults();
			++tCount;
		}
	}
	else
	{
		tCount = tc;
	}
}


/*
	class Tri
	{
	public:
		Tri() { setDefaults(); }
		void setDefaults();
		struct Vert
		{
			//只保存顶点的索引
			int index;
			float u, v;
		};
		Vert v[3];
		//法向量
		Vector3 normal;
	};
*/
void EditTriMesh::computeOneTriNormal(Tri & t)
{
	const Vector3 & v1 = vertex(t.v[0].index).p;
	const Vector3 & v2 = vertex(t.v[1].index).p;
	const Vector3 & v3 = vertex(t.v[2].index).p;
	Vector3 e1 = v3 - v2;
	Vector3 e2 = v1 - v3;
  	t.normal = cross(e1 ,e2);
	t.normal.normalize();
}

void EditTriMesh::computeOneTriNormal(int triIndex)
{
	computeOneTriNormal(tri(triIndex));
}

void EditTriMesh::computeAllTriNormal()
{
	for (int i = 0 ; i < triCount(); ++i)
	{
		computeOneTriNormal(i);
	}
}

void EditTriMesh::computeAllVertexNormal()
{
	int i;
	computeAllTriNormal();
	for (int i = 0; i < vertexCount(); ++i)
	{
		vertex(i).normal.zero();
	}

	for (int i = 0; i < triCount(); ++i)
	{
		const Tri * t = &tri(i);
		for (int j = 0; i < 3;j++)
		{
			vertex(t->v[j].index).normal += t->normal;
		}
	}

	for (int i = 0; i < vertexCount(); ++i)
	{
		vertex(i).normal.normalize();
	}

}