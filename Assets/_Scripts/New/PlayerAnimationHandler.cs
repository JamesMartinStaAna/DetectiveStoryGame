using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    private Animator animator;

    public AnimatorOverrideController RightUnderwearNoGlassesController;
    public AnimatorOverrideController LeftUnderwearNoGlassesController;

    public AnimatorOverrideController activeRightController;
    public AnimatorOverrideController activeLeftController;

    private void Awake()
    {
        activeRightController = RightUnderwearNoGlassesController;
        activeLeftController = LeftUnderwearNoGlassesController;
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = activeRightController;

    }

    public void SetAnimationControllers(AnimatorOverrideController leftOverrideController, AnimatorOverrideController rightOverrideController)
    {
        if (animator.runtimeAnimatorController == activeLeftController)
        {
            if(leftOverrideController == rightOverrideController)
            {
                this.transform.localScale = new Vector3(-6, 6, 1);
            }
            animator.runtimeAnimatorController =leftOverrideController;
        }
        else
        {
            animator.runtimeAnimatorController = rightOverrideController;
        }
        activeLeftController = leftOverrideController;
        activeRightController = rightOverrideController;
    }

    public void SetAnimations(AnimatorOverrideController overrideController)
    {
        animator.runtimeAnimatorController = overrideController;
    }
}
