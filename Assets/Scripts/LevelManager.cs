using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int Escena;

    public QuestionManager questionManager;
    public Animator AnimAccion;
    void OnEnable()
    {
        QuestionManager.RespuestaEntregada += ReaccionRespuesta;
        QuestionManager.PreguntaLanzada += ReaccionLanzamiento;
    }
    void ReaccionRespuesta(bool correcta)
    {
        switch (correcta)
        {
            case true:
                AnimAccion.SetBool("Correcta", true);
                AnimAccion.SetTrigger("Respondido");

                break;
            case false:
                AnimAccion.SetBool("Correcta", false);
                AnimAccion.SetTrigger("Respondido");
                break;
        }
    }
    void ReaccionLanzamiento()
    {
        AnimAccion = questionManager.Desafios[QuestionManager.nTurno].GetComponent<Animator>();
    }
    void OnDisable()
    {
        QuestionManager.RespuestaEntregada -= ReaccionRespuesta;
        QuestionManager.PreguntaLanzada -= ReaccionLanzamiento;
    }
   
}
