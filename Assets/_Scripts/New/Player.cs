using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DetectiveGame.Player
{
    public class Player : MonoBehaviour
    {
        public bool IsDraggingAnItem;
        private SpriteRenderer spriteRenderer;
        public Sprite spriteCurrentOutfit;
        

        public Sprite underWear;
        public Sprite work;
        private void Awake() {
            //Debug.unityLogger.logEnabled = false;
        }

        void Start()
        {

        }

        public void ChangeToWork()
        {
            spriteRenderer.sprite = work;
        }

        public void ChangeToUnderwear()
        {
            spriteRenderer.sprite = underWear;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

