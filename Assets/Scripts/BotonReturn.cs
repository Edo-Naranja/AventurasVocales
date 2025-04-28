using UnityEngine;

public class BotonReturn : MonoBehaviour
{
    public void AlInicio()
    {
        GameManager.Instancia.CambiarEscena(1);
    }
}
