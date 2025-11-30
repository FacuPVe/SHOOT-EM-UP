using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI textoPuntos;
    private int puntuacionTotal = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void SumarPuntos(int puntos)
    {
        puntuacionTotal += puntos;
        ActualizarUI();
    }
    
    void ActualizarUI()
    {
        if(textoPuntos != null)
        {
            Debug.Log("Punto añadido");
            textoPuntos.text = "Puntos: " + puntuacionTotal;
        }
    }

    public void GameOver()
    {
        Invoke("ReiniciarNivel", 2f);
    }

    void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
