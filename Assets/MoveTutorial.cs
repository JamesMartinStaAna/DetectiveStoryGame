using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTutorial : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canvasGroup.alpha < 1) return;

        if(Input.GetMouseButtonDown(0))
        {
            Destroy(this.gameObject);
        }
    }
}
