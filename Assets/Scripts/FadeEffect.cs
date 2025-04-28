using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class FadeEffect : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private float fadeDuration = 1.0f; // Duración del efecto de fade

    // Método para iniciar Fade In en arrays de Images
    public void StartFadeIn(Image[] images)
    {
        StartCoroutine(Fade(0f, 1f, images)); // De transparente a opaco
    }

    // Método para iniciar Fade In en arrays de TextMeshProUGUI
    public void StartFadeIn(TextMeshProUGUI[] texts)
    {
        StartCoroutine(Fade(0f, 1f, texts)); // De transparente a opaco
    }

    // Método para iniciar Fade In en arrays de SpriteRenderers
    public void StartFadeIn(SpriteRenderer[] spriteRenderers)
    {
        StartCoroutine(Fade(0f, 1f, spriteRenderers)); // De transparente a opaco
    }

    // Método para iniciar Fade Out en arrays de Images
    public void StartFadeOut(Image[] images)
    {
        StartCoroutine(Fade(1f, 0f, images)); // De opaco a transparente
    }

    // Método para iniciar Fade Out en arrays de TextMeshProUGUI
    public void StartFadeOut(TextMeshProUGUI[] texts)
    {
        StartCoroutine(Fade(1f, 0f, texts)); // De opaco a transparente
    }

    // Método para iniciar Fade Out en arrays de SpriteRenderers
    public void StartFadeOut(SpriteRenderer[] spriteRenderers)
    {
        StartCoroutine(Fade(1f, 0f, spriteRenderers)); // De opaco a transparente
    }

    // Corrutina para manejar el efecto de fade en arrays de Images
    private IEnumerator Fade(float startAlpha, float targetAlpha, Image[] images)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);

            // Aplica el fade a cada Image en el array
            foreach (Image image in images)
            {
                if (image != null)
                {
                    Color color = image.color;
                    color.a = newAlpha;
                    image.color = color;
                }
            }

            yield return null; // Espera al siguiente frame
        }

        // Asegura que el valor final sea exacto
        foreach (Image image in images)
        {
            if (image != null)
            {
                Color color = image.color;
                color.a = targetAlpha;
                image.color = color;
            }
        }
    }

    // Corrutina para manejar el efecto de fade en arrays de TextMeshProUGUI
    private IEnumerator Fade(float startAlpha, float targetAlpha, TextMeshProUGUI[] texts)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);

            // Aplica el fade a cada TextMeshProUGUI en el array
            foreach (TextMeshProUGUI text in texts)
            {
                if (text != null)
                {
                    Color color = text.color;
                    color.a = newAlpha;
                    text.color = color;
                }
            }

            yield return null; // Espera al siguiente frame
        }

        // Asegura que el valor final sea exacto
        foreach (TextMeshProUGUI text in texts)
        {
            if (text != null)
            {
                Color color = text.color;
                color.a = targetAlpha;
                text.color = color;
            }
        }
    }

    // Corrutina para manejar el efecto de fade en arrays de SpriteRenderers
    private IEnumerator Fade(float startAlpha, float targetAlpha, SpriteRenderer[] spriteRenderers)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);

            // Aplica el fade a cada SpriteRenderer en el array
            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                if (spriteRenderer != null)
                {
                    Color color = spriteRenderer.color;
                    color.a = newAlpha;
                    spriteRenderer.color = color;
                }
            }

            yield return null; // Espera al siguiente frame
        }

        // Asegura que el valor final sea exacto
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            if (spriteRenderer != null)
            {
                Color color = spriteRenderer.color;
                color.a = targetAlpha;
                spriteRenderer.color = color;
            }
        }
    }
}