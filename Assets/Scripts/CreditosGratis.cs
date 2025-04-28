using TMPro;
using UnityEngine;

public class CreditosGratis : MonoBehaviour
{
    public TextMeshProUGUI textoGeneral;
    public TextMeshProUGUI textoVolver;
    void Start()
    {
        Idiomas();
    }
    public void Idiomas()
    {
        switch(GameManager.lenguaje)
        {
            default:
            textoGeneral.text = "Gracias por jugar la etapa de prueba de nuestro juego. Te invitamos a adquirir todos los niveles en la pantalla de inicio";
            textoVolver.text = "Volver";
            break;
            case "Deutsch":
            textoGeneral.text = "Vielen Dank, dass du die Testversion unseres Spiels gespielt hast. Alle Level kannst du im 'Start'-Bildschirm freischalten.";
            textoVolver.text = "Zurück";
            break;
            case "Polski":
            textoGeneral.text = "Dziękujemy za zagranie w wersję próbną naszej gry. Pełną wersję poziomów odblokujesz w ekranie 'Start'.";
            textoVolver.text = "Powrót";
            break;
            case "Portugues":
            textoGeneral.text = "Obrigado por jogar a versão de teste do nosso jogo. Você pode desbloquear todos os níveis na tela 'Início'.";
            textoVolver.text = "Voltar";
            break;
            case "English":
            textoGeneral.text = "Thank you for playing the trial version of our game. You can unlock all levels on the 'Start' screen.";
            textoVolver.text = "Back";
            break;
        }
    }
}
