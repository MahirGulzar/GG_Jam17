using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class MecanimAnimation : StateMachineBehaviour {

    public string Animation_Name;
    public float Speed;
    

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SkeletonAnimation anim = animator.GetComponent<SkeletonAnimation>();
        anim.state.SetAnimation(0, Animation_Name, true).timeScale=Speed;
    }
}
