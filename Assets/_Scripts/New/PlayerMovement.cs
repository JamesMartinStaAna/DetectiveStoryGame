using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DetectiveGame.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private TargetPosition targetPosition;
        private Player player;
        private bool nearWall;
        private Animator animator;
        private void Awake()
        {
            animator = GetComponent<Animator>();
            player = GetComponent<Player>();
            targetPosition = GetComponent<TargetPosition>();
        }

        private void Update()
        {
            if (!player.IsDraggingAnItem)
            {
                targetPosition.Move();
            }
            else
            {
                animator.SetFloat("MoveValue", 0);
            }
        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                targetPosition.FollowTarget = transform.position;
                //nearWall = true;
            }
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                // nearWall = true;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                //nearWall = false;
            }
        }
    }
}
