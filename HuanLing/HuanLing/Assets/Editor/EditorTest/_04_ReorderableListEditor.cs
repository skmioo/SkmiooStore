using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// UnityEditorInternal是Unity内部使用、还未开放给用用户的一些库，可能有一些很有意思的类，例如ReorderableList，但注意可能会随着新版本发生变化
using UnityEditorInternal;
using UnityEditor;

// CanEditMultipleObjects告诉Unity，当我们选择同一种类型的多个组件时，我们自定义的面板是可以支持同时修改所有选中的组件的
// 如果我们在修改参数时使用的是serializedObject，那么这个功能Unity会自动完成的
// 但如果我们是直接使用"target"来访问和修改参数的话，这个变量只能访问到选中的第一个组件
// 此时我们可以使用"targets"来得到所有选中的相同组件
[CanEditMultipleObjects]
[CustomEditor(typeof(_04_ReorderableList))]
public class _04_ReorderableListEditor : Editor
{
	// UnityEditorInternal中提供了一种可排序的列表面板显示类
	ReorderableList m_List;
	_03_CustomList m_Piston;
	// OnEnable会在自定义面板被打开的时候调用，例如当选中一个包含了PistonE04Pattern的gameobject时
	void OnEnable()
	{
		if (target == null)
		{
			return;
		}

		FindPistonComponent();
		CreateReorderableList();
		//SetupReoirderableListHeaderDrawer();
		//SetupReorderableListElementDrawer();
		//SetupReorderableListOnAddDropdownCallback();
	}
	void FindPistonComponent()
	{
		m_Piston = (target as _04_ReorderableList).GetComponent<_03_CustomList>();
	}

	void CreateReorderableList()
	{
		// ReorderableList是一个非常棒的查看数组类型变量的实现类。它位于UnityEditorInternal中，这意味着Unity并没有觉得该类足够好到可以开放给公众
		// 更多关于ReorderableLists的内容可参考：
		// http://va.lent.in/unity-make-your-lists-functional-with-reorderablelist/
		m_List = new ReorderableList(
						serializedObject,
						serializedObject.FindProperty("Pattern"),
						true, true, true, true);
	}

}

