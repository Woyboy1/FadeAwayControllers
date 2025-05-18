using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FadeControllers
{
    /// <summary>
    /// How to use? 
    /// 
    /// - Use a coroutine like FadeImage() to control the length of the Fade() 
    /// - That's it!
    /// 
    /// </summary>
    public class TextFadeController : MonoBehaviour
    {
        [Header("Text Controller")]
        [SerializeField] private TextMeshProUGUI textElement;
        [SerializeField] private float fadeDuration = 1.0f;
        [SerializeField] private float displayDuration = 2.0f;

        private void Start()
        {
            StartCoroutine(FadeText());
        }

        private IEnumerator FadeText()
        {
            // Fade in
            yield return StartCoroutine(Fade(0, 1));
            // Display for a while
            yield return new WaitForSeconds(displayDuration);
            // Fade out
            yield return StartCoroutine(Fade(1, 0));
        }

        private IEnumerator Fade(float startAlpha, float endAlpha)
        {
            float elapsedTime = 0;
            Color color = textElement.color;

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
                textElement.color = color;
                yield return null;
            }

            color.a = endAlpha;
            textElement.color = color;
        }
    }

}