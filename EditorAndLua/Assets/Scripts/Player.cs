using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//职业
public enum PlayerProfression
{
	Warrior = 0,
	Wizard = 1
}

public enum PlayerLoveColor
{
	Green = 1,
	Red = 2,
	Blue = 4,
	Orange = 8
}

//添加BoxCollider
[RequireComponent(typeof(BoxCollider))]
// Update()会在场景中对象发生变化或者项目组织发生变化时调用
[ExecuteInEditMode]
[AddComponentMenu("自定义Menu/Player")]
public class Player : MonoBehaviour
{
	public int Id;

	public string Name;

	public float Atk;

	public bool isMan;

	public Vector3 headDir;

	public Color Hair;

	public GameObject Weapon;

	public Texture Cloth;

	public PlayerProfression pro;
	
	public PlayerLoveColor loveColor;

	public List<string> Items;

	// Update is called once per frame
	void Update()
    {
		//Debug.Log("111");
    }
}
