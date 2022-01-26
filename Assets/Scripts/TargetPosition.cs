using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    private Vector2 followTarget;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        followTarget = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            followTarget = new Vector2(mousePosition.x, 0);
        }

        transform.position = Vector2.MoveTowards(transform.position, followTarget, Time.deltaTime * Speed);
    }
}
