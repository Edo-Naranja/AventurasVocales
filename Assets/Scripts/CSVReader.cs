using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
    public string fileName = "Spanish"; // Nombre sin extensión
    private List<string[]> data = new List<string[]>();

    void Start()
    {
        fileName = GameManager.lenguaje;
        LoadCSV();        
    }

    void LoadCSV()
    {
        TextAsset csvFile = Resources.Load<TextAsset>(fileName);
        if (csvFile != null)
        {
            string[] lines = csvFile.text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line)) // Evita líneas vacías
                {
                    string[] values = line.Trim().Split(',');
                    data.Add(values);
                }
            }
            if (data.Count > 2 && data[2].Length > 3)
            {
                Debug.Log("Valor en [2][3]: " + data[2][3]);
            }
            else
            {
                Debug.LogWarning("El CSV no tiene suficientes datos para acceder a [2][3].");
            }
            Debug.Log("CSV cargado correctamente.");
        }
        else
        {
            Debug.LogError("No se encontró el archivo CSV en Resources.");
        }
    }

    public string LeerTexto()
    {
        if (data.Count > 1 && data[1].Length > 1)
        {
            return data[QuestionManager.nTurno + 1 + LevelManager.Escena * 10][2];
        }
        else
        {
            Debug.LogError("El CSV no tiene suficientes datos.");
            return "Error: Datos insuficientes";
        }
    }
    public string LeerTexto(bool correcta)
    {
        if (data.Count > 1 && data[1].Length > 1)
        {
            if(correcta)
            {
                return data[QuestionManager.nTurno + 1 + LevelManager.Escena * 10][3];
            }
            return data[QuestionManager.nTurno + 1 + LevelManager.Escena * 10][4];
            
        }
        else
        {
            Debug.LogError("El CSV no tiene suficientes datos.");
            return "Error: Datos insuficientes";
        }
    }
}

