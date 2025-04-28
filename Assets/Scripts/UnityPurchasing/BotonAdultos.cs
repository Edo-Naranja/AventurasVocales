using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BotonAdultos : MonoBehaviour
{
    public GameObject comprobacionEdad;
    public GameObject botonCompras;
    public TextMeshProUGUI botonVolver;
    public TextMeshProUGUI operacion;
     public TextMeshProUGUI titulo;
    public TextMeshProUGUI botonComprasIdioma;
    public TextMeshProUGUI botonComprobacionIdioma;
    
    public int resultadoSuma;
    public string resultadoIngresado;
    public int cifraIngresada;
    private int intentos;
    public void ActivarCompra()
    {
        if(intentos > 2) {return;}
        comprobacionEdad.SetActive(true);
        ComprobarEdad();
    }
    void Awake()
    {
        intentos = 0;
        comprobacionEdad.SetActive(false);
        botonCompras.SetActive(false);
    }
    void Start()
    {
        IdiomasCompras();
        if(GameManager.etapasCompradas){gameObject.SetActive(false);}
    }
    public void ComprobarEdad()
    {
        cifraIngresada = 0;
        resultadoIngresado = "";
        int randomSumando = Random.Range(0, 9);
        int randomSumando1 = Random.Range(10, 50);
        resultadoSuma = randomSumando + randomSumando1;
        ComprobarDiferentesIdiomas(randomSumando1, randomSumando);
    }
    public void ResponderPregunta(int respuesta)
    {
        cifraIngresada++;
        resultadoIngresado += respuesta;
        if(cifraIngresada < 2)
        {            
            return;
        }
        if(resultadoIngresado.ToString() == resultadoSuma.ToString())
        {
            botonCompras.SetActive(true);
            comprobacionEdad.SetActive(false);
        }        
        else
        {
            intentos++;
            comprobacionEdad.SetActive(false);
        }
    }
    public void IdiomasCompras()
    {
        switch(GameManager.lenguaje)
        {
            default:
            botonComprasIdioma.text = "Desbloquear niveles";
            botonComprobacionIdioma.text = "Para padres";
            botonVolver.text = "Volver";
            break;
            case "Deutsch":
            botonComprasIdioma.text = "Levels freischalten";
            botonComprobacionIdioma.text = "Für Eltern";
            botonVolver.text = "Zurückr";
            break;
            case "Polski":
            botonComprasIdioma.text = "Odblokuj poziomy";
            botonComprobacionIdioma.text = "Dla rodziców";
            botonVolver.text = "Wróć";
            break;
            case "Portugues":
            botonComprasIdioma.text = "Desbloquear cenários";
            botonComprobacionIdioma.text = "Para pais";
            botonVolver.text = "Voltar";
            break;
            case "English":
            botonComprasIdioma.text = "Unlock levels";
            botonComprobacionIdioma.text = "For Parents";
            botonVolver.text = "Back";
            break;
        }
    }
    public void ComprobarDiferentesIdiomas(int randomSumando1, int randomSumando)
    {
        switch(GameManager.lenguaje)
        {
            default:
            operacion.text = "¿Cuánto es " + randomSumando1 + "+ " + randomSumando + " ?";
            titulo.text = "Comprobación de edad";
            break;
            case "Deutsch":
            operacion.text = "Was ist " + randomSumando1 + "+ " + randomSumando + " ?";
            titulo.text = "Altersüberprüfung";
            break;
            case "Polski":
            operacion.text = "Ile to jest " + randomSumando1 + "+ " + randomSumando + " ?";
            titulo.text = "Weryfikacja wieku";
            break;
            case "Portugues":
            operacion.text = "Quanto é " + randomSumando1 + "+ " + randomSumando + " ?";
            titulo.text = "Verificação de idade";
            break;
            case "English":
            operacion.text = "What is " + randomSumando1 + "+ " + randomSumando + " ?";
            titulo.text = "Age verification";
            break;
        }
    }
       public void Cerrar()
    {
        botonCompras.SetActive(false);
    }

}
