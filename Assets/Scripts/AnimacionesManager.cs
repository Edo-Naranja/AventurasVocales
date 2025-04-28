using UnityEngine;

public class AnimacionesManager : MonoBehaviour
{
    public void CambiarDeEscena()
    {
        if(GameManager.etapasCompradas)
        {
            GameManager.Instancia.CambiarEscena();
            return;
        }
        GameManager.Instancia.CambiarEscena(7);        
    }
}
