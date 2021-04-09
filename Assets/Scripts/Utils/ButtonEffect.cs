using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Menu
{
    public class ButtonEffect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField]
        private float effectTime = .15f;
        [SerializeField]
        private float sizeEffect = .9f;
        [SerializeField, Tooltip("Fix problem in scrollComponents")]
        private bool scrollComponent = false;
        [SerializeField]
        private bool moveToStatrSize = false;
        private Coroutine pCor;

        [SerializeField, Tooltip("Start size")]
        private Vector2 sSize = new Vector2(1f, 1f);

        private void OnEnable()
        {
            //reset visual
            transform.localScale = sSize;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (pCor != null)
                StopCoroutine(pCor);
            pCor = StartCoroutine(press());

            if (scrollComponent)
            {
                GameCore.input.mouseUp -= UnpressPointer;
                GameCore.input.mouseUp += UnpressPointer;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (scrollComponent)
                return;

            if (pCor != null)
                StopCoroutine(pCor);
            pCor = StartCoroutine(unPress());
        }

        private void UnpressPointer()
        {
            if (pCor != null)
                StopCoroutine(pCor);

            GameCore.input.mouseUp -= UnpressPointer;

            transform.localScale = sSize;
        }

        IEnumerator press()
        {
            var tTime = Time.time;
            if (moveToStatrSize)
            {
                sSize = transform.localScale;
            }
            var defSize = sSize * sizeEffect;

            while (Time.time < tTime + effectTime)
            {
                transform.localScale = Vector2.Lerp(transform.localScale, defSize, (Time.time - tTime) / effectTime);
                yield return null;
            }

            transform.localScale = defSize;
        }

        IEnumerator unPress()
        {
            var tTime = Time.time;
            var defSize = sSize * (2f - sizeEffect);
            var eTime = effectTime / 2f;

            while (Time.time < tTime + eTime)
            {
                transform.localScale = Vector2.Lerp(transform.localScale, defSize, (Time.time - tTime) / effectTime);
                yield return null;
            }

            transform.localScale = defSize;
            defSize = sSize;

            while (Time.time < tTime + eTime)
            {
                transform.localScale = Vector2.Lerp(transform.localScale, defSize, (Time.time - tTime) / effectTime);
                yield return null;
            }

            transform.localScale = defSize;

        }

        [ContextMenu("SaveSize")]
        public void SaveStarSize()
        {
            sSize = transform.localScale;
        }
    }
}