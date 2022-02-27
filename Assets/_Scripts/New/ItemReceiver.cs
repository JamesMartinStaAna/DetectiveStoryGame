using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using DetectiveGame.Player;


public class ItemReceiver : MonoBehaviour
{
    public string keyID;
    [SerializeField] private Player player;
    [SerializeField] private bool consumeItem;
    [SerializeField] private Flowchart flowchart;
    [SerializeField] private string targetBlock;
    [SerializeField] private float distanceToActivate;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    public void ReceiveItem(Item item)
    {
        if (Vector2.Distance(player.transform.position, this.transform.position) > distanceToActivate && distanceToActivate != 0) return;

        if (flowchart != null)
        {
            Debug.Log("tried to execute");
            flowchart.ExecuteBlock(targetBlock);
        }

        if (consumeItem)
        {
            item.Use();
        }
    }
}
