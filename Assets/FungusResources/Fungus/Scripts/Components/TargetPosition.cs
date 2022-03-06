using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    [SerializeField] private Camera CameraTarget;
    public Vector2 FollowTarget;

    public float WalkSpeed;
    public float RunSpeed;
    public float DistanceBeforeSlowDown;
    private Animator animator;
    public bool isDialogActive;
    private Rigidbody rb;

    // Start is called before the first frame update
    private void Awake()
    {
        isDialogActive = true;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        if (CameraTarget == null)
        {
            CameraTarget = Camera.main;
        }

        CameraTarget.orthographicSize = 5.125f;
    }
    void Start()
    {
        FollowTarget = transform.position;
    }

    public void Move()
    {
        if (!isDialogActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePosition = CameraTarget.ScreenToWorldPoint(Input.mousePosition);
                FollowTarget = new Vector2(mousePosition.x, transform.position.y);
            }


            animator.SetFloat("MoveValue", Vector2.Distance(transform.position, FollowTarget));
        }
        else
        {
            animator.SetFloat("MoveValue", 0);
        }


    }

    private void FixedUpdate()
    {
        if (!isDialogActive)
        {
            Vector2 newPosition = Vector2.MoveTowards(transform.position, FollowTarget, Time.deltaTime * SpeedBasedOnDistance(FollowTarget));
            rb.MovePosition(newPosition);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            FollowTarget = new Vector2(this.transform.position.x, this.transform.position.y);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            // FollowTarget = new Vector2(this.transform.position.x, this.transform.position.y);
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


