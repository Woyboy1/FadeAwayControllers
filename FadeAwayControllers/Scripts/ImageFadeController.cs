using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace FadeControllers_Woyboy
{

    /// <summary>
    /// Similar functionality with TextFadeController.cs but instead it controls an image component
    /// </summary>
    public class ImageFadeController : MonoBehaviour
    {
        [Header("Image Controller")]
        [SerializeField] private Image imageElement;
        [SerializeField] private float fadeDuration = 1.0f;

        public void SetFadeDuration(float fadeDuration)
        {
            this.fadeDuration = fadeDuration;
        }

        public IEnumerator Fade(float startAlpha, float endAlpha)
        {
            float elapsedTime = 0;
            Color color = imageElement.color;

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
                imageElement.color = color;
                yield return null;
            }

            color.a = endAlpha;
            imageElement.color = color;
        }
    }

}