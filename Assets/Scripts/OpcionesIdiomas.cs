using TMPro;
using UnityEngine;

public class OpcionesIdiomas : MonoBehaviour
{
    public GameObject letreroConfirmacion;
    public TextMeshProUGUI letreroComenzar;
    public TextMeshProUGUI letreroVolver;
    public TextMeshProUGUI confirmarIdioma;
    public TextMeshProUGUI escena0Desafio;
    public TextMeshProUGUI escena1Desafio;
    public TextMeshProUGUI escena2Desafio;
    public TextMeshProUGUI escena3Desafio;
    public TextMeshProUGUI prompt;
    void Start()
    {
        letreroConfirmacion.SetActive(false);
    }
    public void SeleccionarIdioma(string idioma)
    {   
        GameManager.lenguaje = idioma;
        letreroConfirmacion.SetActive(true);
        MensajeIdioma();
    }
    private void MensajeIdioma()
    {
        switch(GameManager.lenguaje)
        {
            default:
            confirmarIdioma.text = "Confirma si quieres comenzar a jugar en español";
            letreroComenzar.text = "Confirmar";
            letreroVolver.text = "Volver";
            NombresEscenas("Español");
            break;
            case "Deutsch":
            confirmarIdioma.text =  "Bestätige, ob du auf Deutsch spielen möchtest.";
            letreroComenzar.text = "Akzeptieren";
            letreroVolver.text = "Zurückr";
            prompt.text = "Elige lo que quieres jugar";
            NombresEscenas("Deutsch");
            break;
            case "Polski":
            confirmarIdioma.text =  "Potwierdź, czy chcesz zacząć grać po polsku.";
            letreroComenzar.text = "Zaakceptuj";
            letreroVolver.text = "Wróć";
            NombresEscenas("Polski");
            break;
            case "Portugues":
            confirmarIdioma.text =  "Confirme se você deseja começar a jogar em português";
            letreroComenzar.text = "Aceitar";
            letreroVolver.text = "Voltar";
            NombresEscenas("Portugues");
            break;
            case "English":
            confirmarIdioma.text =  "Confirm if you want to start playing in English.";
            letreroComenzar.text = "Accept";
            letreroVolver.text = "Back";
            NombresEscenas("English");
            break;
            case "Francais":
            confirmarIdioma.text =  "Confirme si vous voulez commencer à jouer en français.";
            letreroComenzar.text = "Confirmer";
            letreroVolver.text = "Retour";
            NombresEscenas("Francaise");
            break;
        }
    }
    private void NombresEscenas(string idioma)
    {
        switch(idioma)
        {
            case "Deutsch":
                escena0Desafio.text = "Geometrische Formen";
                escena1Desafio.text = "Größen geometrischer Figuren";
                escena2Desafio.text = "Farben";
                escena3Desafio.text = "Größen und Farben geometrischer Figuren";
                prompt.text = "Wähle aus, was du spielen möchtest";
                break;
            case "Polski":
                escena0Desafio.text = "Figury geometryczne";
                escena1Desafio.text = "Rozmiary figur geometrycznych";
                escena2Desafio.text = "Kolory";
                escena3Desafio.text = "Rozmiary i kolory figur geometrycznych";
                prompt.text = "Wybierz, w co chcesz zagrać";
                break;
            case "Portugues":
                escena0Desafio.text = "Figuras geométricas";
                escena1Desafio.text = "Tamanhos de figuras geométricas";
                escena2Desafio.text = "Cores";
                escena3Desafio.text = "Tamanhos e cores de figuras geométricas";
                prompt.text = "Escolha o que você quer jogar";
                break;
            case "English":
                escena0Desafio.text = "Geometric shapes";
                escena1Desafio.text = "Sizes of geometric figures";
                escena2Desafio.text = "Colors";
                escena3Desafio.text = "Sizes and colors of geometric figures";
                prompt.text = "Choose what you want to play";
                break;
            case "Francais":
                escena0Desafio.text = "Geometric shapes";
                escena1Desafio.text = "Sizes of geometric figures";
                escena2Desafio.text = "Colors";
                escena3Desafio.text = "Sizes and colors of geometric figures";
                prompt.text = "Choose what you want to play";
                break;
            default:
                escena0Desafio.text = "Figuras geométricas";
                escena1Desafio.text = "Tamaños de figuras geométricas";
                escena2Desafio.text = "Colores";
                escena3Desafio.text = "Tamaños y colores de figuras geométricas";
                prompt.text = "Elige lo que quieras jugar";
                break;
        }
    }
}
