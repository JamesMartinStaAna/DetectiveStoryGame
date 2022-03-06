using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DetectiveGame.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerAnimationHandler playerAnimationHandler;
        private TargetPosition targetPosition;
        private Player player;
        private bool nearWall;
        private Animator animator;
        private Rigidbody playerRigidbody;
        private Camera _camera;
        private void Awake()
        {
            _camera = Camera.main;
            playerRigidbody = GetComponent<Rigidbody>();
            playerAnimationHandler = GetComponent<PlayerAnimationHandler>();
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
                targetPosition.FollowTarget = this.transform.position;
            }

            if (Input.GetMouseButtonDown(0) && !targetPosition.isDialogActive)
            {
                var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

                if (mousePosition.x - transform.position.x < 0)
                {
                    if (playerAnimationHandler.activeLeftController == playerAnimationHandler.activeRightController)
                    {
                        this.transform.localScale = new Vector3(-6, 6, 1);
                    }
                    else
                    {
                        this.transform.localScale = new Vector3(6, 6, 1);
                        playerAnimationHandler.SetAnimations(playerAnimationHandler.activeLeftController);
                    }

                }
                else
                {
                    if (playerAnimationHandler.activeLeftController == playerAnimationHandler.activeRightController)
                    {
                        this.transform.localScale = new Vector3(6, 6, 1);
                    }
                    playerAnimationHandler.SetAnimations(playerAnimationHandler.activeRightController);
                }
            }
        }
   
    }
}
