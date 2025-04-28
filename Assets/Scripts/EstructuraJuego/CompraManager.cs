using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
public class CompraManager : MonoBehaviour
{
    public TextMeshProUGUI titulo;
    public TextMeshProUGUI precio;
    public TextMeshProUGUI compraFallida;
    public TextMeshProUGUI compraExitosa;
    public GameObject fallo;
    void Awake()
    {
        fallo.SetActive(false);
    }
    public void OnPurchaseComplete(Product product)
    {
        GameManager.Instancia.SaveBool("EtapasCompradas", true);
        GameManager.Instancia.SaveBool("Etapa2", true);
        GameManager.Instancia.SaveBool("Etapa3", true);
        GameManager.Instancia.SaveBool("Etapa4", true);
        ComprobarDiferentesIdiomas();
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureDescription purchaseFailureDescription)
    {
        fallo.SetActive(true);
        compraFallida.text = purchaseFailureDescription.reason.ToString();
        Invoke(nameof(ActivarLetreroFalla),5f);
    }
    public void OnProductFetched(Product product)
    {
        if(product.metadata.localizedTitle != null)
        {
            titulo.text = product.metadata.localizedTitle;
        }
        if(product.metadata.localizedPriceString != null)
        {
            precio.text = product.metadata.localizedPriceString;
        }
    }
    private void ActivarLetreroFalla()
    {
        fallo.SetActive(false);
    }
    public void ComprobarDiferentesIdiomas()
    {
        switch(GameManager.lenguaje)
        {
            default:
            compraExitosa.text = "La compra fue realizada con éxito. Cierre este juego y vuelva a abrir para ver los cambios";
            break;
            case "Deutsch":
            compraExitosa.text = "Der Kauf war erfolgreich. Schließen Sie das Spiel und starten Sie es neu, um die Änderungen zu sehen.";
            break;
            case "Polski":
            compraExitosa.text = "Zakup został pomyślnie zrealizowany. Zamknij grę i uruchom ją ponownie, aby zobaczyć zmiany.";
            break;
            case "Portugues":
            compraExitosa.text = "A compra foi concluída com sucesso. Feche o jogo e reabra-o para ver as alterações.";
            break;
            case "English":
            compraExitosa.text = "The purchase was successful. Please close and restart the game to see the changes.";
            break;
        }
    }
 
}
