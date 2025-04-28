using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Objeto : MonoBehaviour
{
    public void SeleccionarElemento(bool correcta)
    {
        if(!QuestionManager.enJuego) {return;}
        FindFirstObjectByType<QuestionManager>().RespuestaQuiz(correcta);
        if(correcta){return;}
        Invoke(nameof(Inactivar), 2.5f);
    }
    private void Inactivar()
    {
        gameObject.SetActive(false);
    }
}
