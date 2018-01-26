using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SpineAnimator : StateMachineBehaviour {

    public string animationname;
    public float speed;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SkeletonAnimation anim = animator.GetComponent<SkeletonAnimation>();
        anim.state.SetAnimation(0, animationname, true).timeScale = speed;
    }
}
