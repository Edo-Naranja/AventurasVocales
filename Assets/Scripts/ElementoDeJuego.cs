using System.Collections;
using UnityEngine;

public class ElementoDeJuego : MonoBehaviour
{
    public bool target;
    public Animator anim;
    
    void OnEnable()
    {
         StartCoroutine(Pestanear());
    }
    private IEnumerator Pestanear()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(0f, 10));
            anim.SetTrigger("Blink");
        }
    }
    void OnMouseDown()
    {
        SeleccionarElemento(target);
    }
    public void SeleccionarElemento(bool correcta)
    {
        // Verificar si el juego está activo
        if (!QuestionManager.enJuego) return;

        // Obtener el QuestionManager y llamar al método RespuestaQuiz
        QuestionManager questionManager = FindFirstObjectByType<QuestionManager>();
        if (questionManager != null)
        {
            anim.SetTrigger(correcta ? "Arriba":"CerrarOjos");
            questionManager.RespuestaQuiz(correcta);
        }

        // Si la respuesta es incorrecta, desactivar el objeto después de 2.5 segundos
        if (!correcta) Invoke(nameof(Inactivar), 2.5f);
    }

    private void Inactivar()
    {
        gameObject.SetActive(false);
    }
}
