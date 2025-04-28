using UnityEngine;

public class BotonEtapa : MonoBehaviour
{
    public GameObject BloqueadorEtapa1;
    public GameObject BloqueadorEtapa2;
    public GameObject BloqueadorEtapa3;

    public void DesbloquearEtapa(int etapa)
    {
        switch(etapa)
        {
            case 1:
            BloqueadorEtapa1.SetActive(false);
            break;
            case 2:
            BloqueadorEtapa2.SetActive(false);
            break;
            case 3:
            BloqueadorEtapa3.SetActive(false);
            break;
            default:
            break;
        }        
    }
}
