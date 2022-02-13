using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_cylces : StateMachineBehaviour
{
    readonly float breatheMinTime = 1;
    readonly float breatheMaxTime = 2;

    float breatheTimer = 0;

    string[] breatheTrigger = { "Breathe","Blink"};

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (breatheTimer <= 0)
        {
            IdleRandom(animator);
            breatheTimer = Random.Range(breatheMinTime, breatheMaxTime);
        }
        else
        {
            breatheTimer -= Time.deltaTime;
        }
    }

    void IdleRandom(Animator animator)
    {
        System.Random rnd = new System.Random();
        int idlecyc = rnd.Next(breatheTrigger.Length);
        string idleTrigger = breatheTrigger[idlecyc];
        animator.SetTrigger(idleTrigger);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
