using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public delegate void LanzaPregunta();
    public static LanzaPregunta PreguntaLanzada;
    public delegate void Respuesta(bool esCorrecta);
    public static Respuesta RespuestaEntregada;
    public static int nTurno;
    public GameObject[] Desafios;
    public GameObject FinalDesafio;
    public static bool enJuego;
    public bool notUltimaEtapa;
    private void Start()
    {
        Iniciar();
    }
    private void Iniciar()
    {
        FinalDesafio.SetActive(false);
        enJuego = false;
        nTurno = 0;
        Invoke(nameof(LanzarPregunta),0.25f);        
    }
    private void Resetear()
    {
        for (int i = 0; i < Desafios.Length; i++)
        {
            Desafios[i].SetActive(false);
        }
    }
    public void LanzarPregunta()
    {
        Resetear();
        enJuego = true;
        PreguntaLanzada();
        Desafios[nTurno].SetActive(true);
    }
    public void RespuestaQuiz(bool correcta)
    {
        if (!enJuego) return;
        enJuego = false;
        RespuestaEntregada(correcta);
        if (correcta)
        {
            nTurno++;
            if (nTurno < Desafios.Length)
            {
                Invoke(nameof(LanzarPregunta), 4f);
                return;
            }
            Invoke(nameof(ActivarAnimacionFinal), 2f);
            return;
        }
        if (nTurno < Desafios.Length)
            {
                Invoke(nameof(LanzarPregunta), 4f);
                return;
            }
    }
    private void ActivarAnimacionFinal()
    {
        FinalDesafio.SetActive(true);
        FindFirstObjectByType<LanzamientoPreguntaManager>().FinalDeEscena(notUltimaEtapa);
    }   
}