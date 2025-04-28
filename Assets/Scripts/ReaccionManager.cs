using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReaccionManager : MonoBehaviour
{
    public AudioEscena audioEscena;
    private AudioSource aS;
    public TextMeshProUGUI letreroPregunta;
    private void OnEnable()
    {
        QuestionManager.RespuestaEntregada += ReaccionarRespuesta;
        aS = GetComponent<AudioSource>();
        audioEscena = FindFirstObjectByType<AudioEscena>();
    }
    private void ReaccionarRespuesta(bool correcta)
    {

        letreroPregunta.text = FindFirstObjectByType<CSVReader>().LeerTexto(correcta);
        if (correcta)
        {
            aS.PlayOneShot(audioEscena.fanfarriaCorrecta);
           // letreroPregunta.text = FindFirstObjectByType<CSVReader>().LeerTexto();
           // aS.PlayOneShot(audioEscena.PFB[QuestionManager.nTurno]);
            return;
        }
        aS.PlayOneShot(audioEscena.fanfarriaIncorrecta);
      //  aS.PlayOneShot(audioEscena.NFB[QuestionManager.nTurno]);
    }
    private void OnDisable()
    {
        QuestionManager.RespuestaEntregada -= ReaccionarRespuesta;
    }
}
