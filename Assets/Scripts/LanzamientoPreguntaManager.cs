using TMPro;
using UnityEngine;

public class LanzamientoPreguntaManager : MonoBehaviour
{
   public AudioEscena audioEscena;
   public TextMeshProUGUI letreroPregunta;
   private AudioSource aS;
   private void OnEnable()
    {
        QuestionManager.PreguntaLanzada += LanzarPregunta;
        aS = GetComponent<AudioSource>();
        audioEscena = FindFirstObjectByType<AudioEscena>();
    }
   public void LanzarPregunta()
   {
        letreroPregunta.text = FindFirstObjectByType<CSVReader>().LeerTexto();
        return;
   }
   public void FinalDeEscena(bool notUltima)
   {
        switch(GameManager.lenguaje)
        {
            default:
            letreroPregunta.text = notUltima ? "Las figuras descansarán un momento para volver a jugar" : "¡Has logrado terminar todos los desafíos, felicitaciones!";            
            break;
            case "Deutsch":
            letreroPregunta.text = notUltima ? "Die Figuren werden eine Pause machen, um wieder zu spielen": "Du hast alle Herausforderungen gemeistert, herzlichen Glückwunsch!";
            break;
            case "Polski":
            letreroPregunta.text = notUltima ? "Figury odpoczną chwilę, aby znów zagrać": "Udało ci się ukończyć wszystkie wyzwania, gratulacje!";
            break;
            case "Portugues":
            letreroPregunta.text = notUltima ? "As figuras descansarão um momento para voltar a jogar": "Você conseguiu terminar todos os desafios, parabéns!";
            break;
            case "English":
            letreroPregunta.text = notUltima ? "The figures will rest for a moment to play again":"You have managed to complete all the challenges, congratulations!";
            break;
        }
   }
}
