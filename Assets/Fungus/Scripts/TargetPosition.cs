using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    public Vector2 FollowTarget;

    public float WalkSpeed;
    public float RunSpeed;
    public float DistanceBeforeSlowDown;

    public bool isDialogActive;

    // Start is called before the first frame update
    void Start()
    {
        FollowTarget = transform.position;
    }

    public void Move()
    {
        if (!isDialogActive)
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                FollowTarget = new Vector2(mousePosition.x, transform.position.y);
            }
            transform.position = Vector2.MoveTowards(transform.position, FollowTarget, Time.deltaTime * SpeedBasedOnDistance(FollowTarget));
        }
    }

    private float SpeedBasedOnDistance(Vector2 targetPosition)
    {
        if (Vector2.Distance(this.transform.position, FollowTarget) > DistanceBeforeSlowDown)
        {
            return RunSpeed;
        }
        else
        {
            return WalkSpeed;
        }
    }

    public void EnterDialog()
    {
        isDialogActive = true;
    }

    public void ExitDialog()
    {
        isDialogActive = false;
    }
}


