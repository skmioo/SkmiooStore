using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[System.Serializable]
public struct roleImageStruct
{
    public int ID;
    public AssetReferenceSprite roleTopImage;
    public AssetReferenceSprite roleBottomImage;
}

/// <summary>
/// 出于避免修改角色结构导致冲突等问题
/// 角色详情的图片使用这里引用
/// 待数据结构稳定后应该合并到角色数据中
/// </summary>
[CreateAssetMenu(menuName = "NewData/Role/RoleTextData")]
public class RoleImageDataSet : ScriptableObject
{
    public roleImageStruct[] roleImageAry;
}
