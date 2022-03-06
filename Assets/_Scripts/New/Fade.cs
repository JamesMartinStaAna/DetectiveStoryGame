using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DetectiveGame.Player;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private bool isCoroutineRunning;
    private TargetPosition targetPosition;
    [SerializeField] private float fadeSpeed;
    private Player player;
    private void Awake()
    {
        fadeGroup = GetComponent<CanvasGroup>();
        player = FindObjectOfType<Player>();
        targetPosition = FindObjectOfType<TargetPosition>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerFadeToScene(float speed, Transform target, bool sceneTransfer, int buildIndex)
    {
        if (isCoroutineRunning)
        {
            StopAllCoroutines();
        }

        StartCoroutine(CoroutinePlayerFadeToScene(speed, target, sceneTransfer, buildIndex));
    }

    private IEnumerator FadeIn(float speed)
    {
        isCoroutineRunning = true;
        this.gameObject.SetActive(true);

        while (fadeGroup.alpha < 1)
        {
            fadeGroup.alpha += Time.deltaTime * speed;
            yield return null;
        }
    }

    private IEnumerator FadeOut(float speed)
    {
        isCoroutineRunning = true;

        while (fadeGroup.alpha >= 0)
        {
            fadeGroup.alpha -= Time.deltaTime * speed;
            yield return null;
        }

        this.gameObject.SetActive(false);
    }

    private IEnumerator CoroutinePlayerFadeToScene(float speed, Transform target, bool sceneTransfer, int buildIndex)
    {
        targetPosition.FollowTarget = player.transform.position;
        isCoroutineRunning = true;

        while (fadeGroup.alpha < 1)
        {
            fadeGroup.alpha += Time.deltaTime * speed;
            yield return null;
        }
        if (sceneTransfer)
        {
            SceneManager.LoadSceneAsync(buildIndex);
        }
        else
        {
            player.transform.position = new Vector3(target.transform.localPosition.x, 0, player.transform.position.z);
            targetPosition.FollowTarget = player.transform.position;
        }

        while (fadeGroup.alpha >= 0)
        {
            fadeGroup.alpha -= Time.deltaTime * speed;
            yield return null;
        }

        isCoroutineRunning = false;
    }
}
