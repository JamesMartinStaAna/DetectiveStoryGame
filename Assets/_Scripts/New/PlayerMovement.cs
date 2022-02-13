using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DetectiveGame.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private TargetPosition targetPosition;
        private Player player;
        private void Awake()
        {
            player = GetComponent<Player>();
            targetPosition = GetComponent<TargetPosition>();
        }

        private void Update()
        {
            if (!player.IsDraggingAnItem)
            {
                targetPosition.Move();
            }
        }
    }
}
