using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class MirrorColliderScript : MonoBehaviour
{
    [SerializeField] private GameObject baseSpriteRenderer;
    [SerializeField] private Flowchart flowchart;
    public bool isClosed;

    private void Update()
    {
        if (!isClosed)
        {
            baseSpriteRenderer.SetActive(false);
            flowchart.SetBooleanVariable("InFrontOfMirror", false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || isClosed)
        {
            baseSpriteRenderer.SetActive(true);
            flowchart.SetBooleanVariable("InFrontOfMirror", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || isClosed)
        {
            baseSpriteRenderer.SetActive(false);
            flowchart.SetBooleanVariable("InFrontOfMirror", false);
        }
    }

    public void SetIsClosed(bool value)
    {
        isClosed = value;

    }
}
