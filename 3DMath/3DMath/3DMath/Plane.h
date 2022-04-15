#pragma once
class Vector3;
//从n个点计算出最佳平面
Vector3 computeBestFitNormal(const Vector3 v[], int n);