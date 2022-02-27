// This code is part of the Fungus library (https://github.com/snozbot/fungus)
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Fungus
{
    /// <summary>
    /// Detects mouse clicks and touches on a Game Object, and sends an event to all Flowchart event handlers in the scene.
    /// The Game Object must have a Collider or Collider2D component attached.
    /// Use in conjunction with the ObjectClicked Flowchart event handler.
    /// </summary>
    public class Clickable2D : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Tooltip("Is object clicking enabled")]
        [SerializeField] protected bool clickEnabled = true;

        [Tooltip("Mouse texture to use when hovering mouse over object")]
        [SerializeField] protected Texture2D hoverCursor;

        [Tooltip("Use the UI Event System to check for clicks. Clicks that hit an overlapping UI object will be ignored. Camera must have a PhysicsRaycaster component, or a Physics2DRaycaster for 2D colliders.")]
        [SerializeField] protected bool useEventSystem;

        public float DistanceToActivate;
        private TargetPosition targetPosition;
        private Sprite baseSprite;
        public static bool isHovered;
        [SerializeField] private Sprite Highlight;
        
        private void Awake() {
            targetPosition = FindObjectOfType<TargetPosition>();
            baseSprite = GetComponent<SpriteRenderer>().sprite;
        }

        protected virtual void ChangeCursor(Texture2D cursorTexture)
        {
            if (!clickEnabled)
            {
                return;
            }

            Cursor.SetCursor(cursorTexture, Vector3.zero, CursorMode.Auto);
        }

        protected virtual void DoPointerClick()
        {
            if (targetPosition.isDialogActive || !clickEnabled)
            {
                return;
            }

            var eventDispatcher = FungusManager.Instance.EventDispatcher;

            eventDispatcher.Raise(new ObjectClicked.ObjectClickedEvent(this));
            GetComponent<SpriteRenderer>().sprite = baseSprite;
            SetMouseCursor.ResetMouseCursor();
        }

        protected virtual void DoPointerEnter()
        {
            if(targetPosition.isDialogActive || !clickEnabled) return;

            GetComponent<SpriteRenderer>().sprite = Highlight;
            ChangeCursor(hoverCursor);
        }

        protected virtual void DoPointerExit()
        {
            if(!clickEnabled) return;
            // Always reset the mouse cursor to be on the safe side
            SetMouseCursor.ResetMouseCursor();
            GetComponent<SpriteRenderer>().sprite = baseSprite;
        }

        #region Legacy OnMouseX methods

        protected virtual void OnMouseDown()
        {
            if (!useEventSystem)
            {
                DoPointerClick();
            }
        }

        protected virtual void OnMouseEnter()
        {
            if (!useEventSystem)
            {
                DoPointerEnter();
                isHovered = true;
            }
        }

        protected virtual void OnMouseExit()
        {
            if (!useEventSystem)
            {
                DoPointerExit();
                isHovered = false;
            }
        }

        #endregion

        #region Public members

        /// <summary>
        /// Is object clicking enabled.
        /// </summary>
        public bool ClickEnabled { set { clickEnabled = value; } }

        #endregion

        #region IPointerClickHandler implementation

        public void OnPointerClick(PointerEventData eventData)
        {
            if (useEventSystem)
            {
                DoPointerClick();
            }
        }

        #endregion

        #region IPointerEnterHandler implementation

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (useEventSystem)
            {
                DoPointerEnter();
            }
        }

        #endregion

        #region IPointerExitHandler implementation

        public void OnPointerExit(PointerEventData eventData)
        {
            if (useEventSystem)
            {
                DoPointerExit();
            }
        }

        #endregion
    }
}
