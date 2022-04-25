using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

namespace Spine.Unity.Examples
{
    public class _RoleController : MonoBehaviour
    {

        [Header("Animation")]
        public SkeletonAnimation skeletonAnimation;



        //我是自己实现一个状态机，还是直接用unity自带的状态机就可以？
        //当角色在移动时
        public void RoleWalk()
        {
            skeletonAnimation.state.SetAnimation(0, "walk",false);
        }

        void RoleIdle()
        {
            skeletonAnimation.state.SetAnimation(0, "stand", false);
        }

    }


    public enum CharacterState
    {
        Idle,
        Walk
    }
}
