using UnityEngine;
using TMPro;
using System.Collections;
public class ControlStart : MonoBehaviour
{
    public GameObject Portada;
    public GameObject Idiomas;
    public GameObject ConfirmarIdioma;
    public GameObject Mapa;
    public TextMeshProUGUI textMesh;
    public float displayTime = 3f;
    public float fadeDuration = 1f;

    private readonly string[] messages =
    {
        "Dotknij ekranu, aby rozpocząć", // Polaco
        "Toca la pantalla para comenzar", // Español
        "Tap the screen to start", // Inglés
        "Toque na tela para começar", // Portugués
        "Tippen Sie auf den Bildschirm, um zu starten", // Alemán
        "Touchez l'écran pour commencer" //Francés
    };
    void Awake()
    {
        Portada.SetActive(false);
        Idiomas.SetActive(false);
        ConfirmarIdioma.SetActive(false);
        Mapa.SetActive(false);
    }
    void Start()
    {
        Portada.SetActive(true);
        StartCoroutine(RotateMessages());
    }
    private IEnumerator RotateMessages()
    {
        int index = 0;
        Color originalColor = textMesh.color;

        while (true)
        {
            yield return StartCoroutine(FadeText(0)); // Desvanece el texto
            textMesh.text = messages[index]; // Cambia el texto
            yield return StartCoroutine(FadeText(1)); // Reactiva la opacidad

            yield return new WaitForSeconds(displayTime);

            index = (index + 1) % messages.Length; // Cambia al siguiente mensaje
        }
    }

    private IEnumerator FadeText(float targetAlpha)
    {
        Color color = textMesh.color;
        float startAlpha = color.a;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            textMesh.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
    }
    public void Comenzar()
    {
        Portada.SetActive(false);
        Idiomas.SetActive(true);
    }
    public void ConfirmacionIdioma()
    {
        ConfirmarIdioma.SetActive(true);
    }
    public void ComenzarJuego(int escena)
    {
        GameManager.Instancia.CambiarEscena(escena);
    }
    public void Volver()
    {
       ConfirmarIdioma.SetActive(false);
    }
    public void IrAlMapa()
    {
        Idiomas.SetActive(false);
        Mapa.SetActive(true);
    }
}
