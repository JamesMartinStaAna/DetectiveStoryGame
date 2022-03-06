using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DetectiveGame.Player;

public class DragNDropTutorial : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    [SerializeField] private Player player;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canvasGroup.alpha < 1) return;

        if(player.IsDraggingAnItem)
        {
            Destroy(this.gameObject);
        }
    }
}
