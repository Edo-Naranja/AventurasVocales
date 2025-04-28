using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    public FadeEffect fadeEffect;
    public TextMeshProUGUI creditText;
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI agradecimientos;
    public TextMeshProUGUI agradecimientos2;
    public GameObject primeraAnimacion;
    public GameObject segundaAnimacion;
    public GameObject terceraAnimacion;
    public TextMeshProUGUI[] bloque;
    public Image[] bloqueImagenes;
    public TextMeshProUGUI[] bloque1;
    public Image[] bloqueImagenes1;
    public TextMeshProUGUI[] bloque2;
    public Image[] bloqueImagenes2;
    private void SelectorIdioma()
    {
        switch(GameManager.lenguaje)
        {
            default:
            creditText.text = "Créditos";
            mainText.text = "Este juego fue diseñado y desarrollado en su totalidad por Eduardo Guerrero, a través de Naranja Lab.";
            agradecimientos.text = "Gracias por jugar";
            agradecimientos2.text = "Para el desarrollo de este juego se utilizó música de Cafofo Music (Casual Music Pack Vol 1), GUI Pro-CasualGame de Layer Labs, Photoshop, Illustrator y Audition de Adobe";
            break;
            case "Deutsch":
            creditText.text = "Credits";
            mainText.text = "Dieses Spiel wurde vollständig von Eduardo Guerrero entworfen und entwickelt, durch Naranja Lab.";
            agradecimientos.text = "Danke fürs Spielen!";
            agradecimientos2.text = "Für die Entwicklung dieses Spiels wurde Musik von Cafofo Music (Casual Music Pack Vol 1), GUI Pro-CasualGame von Layer Labs, Photoshop, Illustrator und Audition von Adobe verwendet.";
            break;
            case "Portugues":
            creditText.text = "Créditos";
            mainText.text = "Este jogo foi integralmente projetado e desenvolvido por Eduardo Guerrero, através do Naranja Lab.";
            agradecimientos.text = "Obrigado por jogar!";
            agradecimientos2.text = "Para o desenvolvimento deste jogo, foi utilizada música de Cafofo Music (Casual Music Pack Vol 1), GUI Pro-CasualGame da Layer Labs, Photoshop, Illustrator e Audition da Adobe.";
            break;
            case "Polski":
            creditText.text = "Credits";
            mainText.text = "Ta gra została w całości zaprojektowana i opracowana przez Eduardo Guerrero, poprzez Naranja Lab.";
            agradecimientos.text = "Dzięki za granie!";
            agradecimientos2.text = "Do stworzenia tej gry wykorzystano muzykę z Cafofo Music (Casual Music Pack Vol 1), GUI Pro-CasualGame od Layer Labs, Photoshop, Illustrator i Audition od Adobe.";
            break;
            case "English":
            creditText.text = "Credits";
            mainText.text = "This game was fully designed and developed by Eduardo Guerrero, through Naranja Lab.";
            agradecimientos.text = "Thank you for playing!";
            agradecimientos2.text = "For the development of this game, music from Cafofo Music (Casual Music Pack Vol 1), GUI Pro-CasualGame by Layer Labs, Photoshop, Illustrator, and Audition by Adobe were used.";
            break;
        }
    }
    void Awake()
    {
        primeraAnimacion.SetActive(false);
        segundaAnimacion.SetActive(false);
        terceraAnimacion.SetActive(false);
    }
    void Start()
    {
        SelectorIdioma();
        StartCoroutine(TimeLineCreditos());
        
    }
    IEnumerator TimeLineCreditos()
    {
        primeraAnimacion.SetActive(true);
        fadeEffect.StartFadeIn(bloque);
        fadeEffect.StartFadeIn(bloqueImagenes);
        yield return new WaitForSeconds(8f);
        primeraAnimacion.GetComponent<Animator>().SetTrigger("Salir");
        fadeEffect.StartFadeOut(bloque);
       // fadeEffect.StartFadeOut(bloqueImagenes);
        yield return new WaitForSeconds(2f);
        segundaAnimacion.SetActive(true);
        fadeEffect.StartFadeIn(bloque1);
        fadeEffect.StartFadeIn(bloqueImagenes1);
        yield return new WaitForSeconds(8f);
        segundaAnimacion.GetComponent<Animator>().SetTrigger("Salir");
        fadeEffect.StartFadeOut(bloque1);
        fadeEffect.StartFadeOut(bloqueImagenes1);
        terceraAnimacion.SetActive(true);
        fadeEffect.StartFadeIn(bloque2);
        fadeEffect.StartFadeIn(bloqueImagenes2);
        yield return new WaitForSeconds(2f);
       // terceraAnimacion.GetComponent<Animator>().SetTrigger("Salir");
       // fadeEffect.StartFadeOut(bloque2);  //    fadeEffect.StartFadeOut(bloqueImagenes2);
       yield return new WaitForSeconds(8);
       GameManager.Instancia.CambiarEscena(1);
    }
}
