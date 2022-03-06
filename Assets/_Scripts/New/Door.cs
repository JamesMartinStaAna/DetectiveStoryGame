using System.Collections;
using System.Collections.Generic;
using DetectiveGame.Player;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform targetPosition;
    [SerializeField] private Texture2D doorCursor;
    [SerializeField] private Sprite highlight;
    private Sprite baseSprite;
    private Player player;
    private TargetPosition targetPos;

    private bool isCoroutineRunning;
    private Fade fade;
    private Sprite sprite;

    private void Awake()
    {
        baseSprite = GetComponent<SpriteRenderer>().sprite;
        player = FindObjectOfType<Player>();
        targetPos = FindObjectOfType<TargetPosition>();
        fade = FindObjectOfType<Fade>();
        sprite = this.GetComponent<SpriteRenderer>().sprite;
    }

    private void OnMouseEnter() {
        if(targetPos.isDialogActive == true) return ;
        Cursor.SetCursor(doorCursor, Vector2.zero, CursorMode.Auto);
        sprite = highlight;
    }

    private void OnMouseExit() {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        sprite = baseSprite;
    }

    private void OnMouseDown()
    {
        if (isCoroutineRunning)
        {
            StopAllCoroutines();
        }

        StartCoroutine(CoroutineDoorInteract());
    }

    public IEnumerator CoroutineDoorInteract()
    {
        yield return new WaitForSeconds(0.1f);
        isCoroutineRunning = true;

        while (Vector2.Distance(player.transform.position, this.transform.position) > 0.5f)
        {

            if (Input.GetMouseButtonDown(0))
            {
                yield break;
            }
            else
            {
                targetPos.FollowTarget = this.transform.position;
            }
            yield return null;
        }

        fade.PlayerFadeToScene(3, targetPosition, false, 0);
        isCoroutineRunning = false;
    }
}
