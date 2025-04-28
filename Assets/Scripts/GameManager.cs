using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variable estática que almacena la única instancia del GameManager
    private static GameManager instancia;
    private static int escenaActual;
    public static string lenguaje;
    public bool etapa2 = true, etapa3 = true, etapa4 = true;
    public static bool etapasCompradas;

    // Método para obtener la instancia del GameManager
    public static GameManager Instancia
    {
        get
        {
            if (instancia == null)
            {
                // Si no existe una instancia, intentamos encontrar una en la escena
                instancia = FindFirstObjectByType<GameManager>();

                // Si no se encuentra en la escena, creamos una nueva instancia
                if (instancia == null)
                {
                    GameObject gameManagerObject = new ();
                    instancia = gameManagerObject.AddComponent<GameManager>();
                }
            }
            return instancia;
        }
    }

    // Método para inicializar el GameManager (puede ser llamado desde otro script)
    public void Initialize()
    {
        etapasCompradas = LoadBool("EtapasCompradas");
        escenaActual = 2;
        SceneManager.sceneLoaded += ActualizarEscenaDesafio;
        etapa2 = LoadBool("Etapa2");
        etapa3 = LoadBool("Etapa3");
        etapa4 = LoadBool("Etapa4");
        if(etapa2)
        {
            FindAnyObjectByType<BotonEtapa>().DesbloquearEtapa(1);
        } 
        if(etapa3)
        {
            FindAnyObjectByType<BotonEtapa>().DesbloquearEtapa(2);
        } 
        if(etapa4)
        {
            FindAnyObjectByType<BotonEtapa>().DesbloquearEtapa(3);
        }           
    }

    // Aquí puedes agregar más métodos y lógica de juego según tus necesidades
    private void Awake()
    {
        // Asegura que solo haya una instancia del GameManager
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // Evita que el objeto se destruya al cargar una nueva escena
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye esta
        }
    }
    private void Start()
    {
        // Inicializa el GameManager cuando comienza el juego
        Initialize();
    }
    public void CambiarEscena(int sEscena)
    {
        if(sEscena <= 2)
        {
            SceneManager.LoadScene(sEscena); 
            return;  
        }
        switch(sEscena)
            {
                case 1:
                if(etapa2)
                {
                    escenaActual = sEscena;
                    SceneManager.LoadScene(sEscena);
                }
                break;
                case 3:
                if(etapa2)
                {
                    escenaActual = sEscena;
                    SceneManager.LoadScene(sEscena);
                }
                break;
                case 4:
                if(etapa3)
                {
                    escenaActual = sEscena;
                    SceneManager.LoadScene(sEscena);
                }
                break;
                case 5:
                if(etapa4)
                {
                    escenaActual = sEscena;
                    SceneManager.LoadScene(sEscena);
                }
                break;
                case 7:
                SceneManager.LoadScene(7);
                break;
                
                default:
                break;

            }
        
    }
    public void CambiarEscena()
    {
        escenaActual++;
        SceneManager.LoadScene(escenaActual);
    }
    public void SaveBool(string key, bool value)
    {
        // Convertir el bool a int (true -> 1, false -> 0)
        PlayerPrefs.SetInt(key, value ? 1 : 0);

        // Guardar los cambios
        PlayerPrefs.Save();
    }
    bool LoadBool(string key)
    {
        // Cargar el valor como int y convertirlo a bool
        return PlayerPrefs.GetInt(key) == 1; // 1 -> true, 0 -> false
    }
    public void ActualizarEscenaDesafio(Scene escena, LoadSceneMode loadSceneMode)
    {
        switch(escena.buildIndex)
        {
            case 1:
            Initialize();
            break;
            case 2:
            LevelManager.Escena = escena.buildIndex - 2;
            break;
            case 3:
            LevelManager.Escena = escena.buildIndex - 2;
            break;
            case 4:
            LevelManager.Escena = escena.buildIndex - 2;
            break;
            case 5:
            LevelManager.Escena = escena.buildIndex - 2;
            break;
            default:
            break;
        }
    }
    public void ReiniciarEtapas()
    {
        SaveBool("Etapa2", false);
        SaveBool("Etapa3", false);
        SaveBool("Etapa4", false);
        SaveBool("EtapasCompradas", false);
    }
}
