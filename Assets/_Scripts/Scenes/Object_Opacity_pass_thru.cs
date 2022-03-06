using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(SpriteRenderer))]
public class Object_Opacity_pass_thru : MonoBehaviour
{
    float alphaLevel;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
            alphaLevel = .5f;

        sprite.color = new Color(1, 1, 1, alphaLevel);
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
            alphaLevel = 1f;

        sprite.color = new Color(1, 1, 1, alphaLevel);

    }
 
}
