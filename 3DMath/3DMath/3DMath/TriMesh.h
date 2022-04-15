#pragma once
#include "EditTriMesh.h"
class TriMesh
{
public:
	void fromEditMesh(const EditTriMesh &mesh);
	void toEditMesh(EditTriMesh &mesh)const;
};
