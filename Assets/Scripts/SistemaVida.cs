using UnityEngine;

public class SistemaVida : MonoBehaviour
{
    [Header("Configuración de Vida")]
    public int vidaMaxima = 100;
    private int vidaActual;

    [Header("Efecto visual")]
    public GameObject explosionPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDaño(int cantidadDaño)
    {
        vidaActual -= cantidadDaño;

        Debug.Log("Daño recibido");

        if (vidaActual <= 0)
        {
            Muerte();
        }
    }

    void Muerte()
    {
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
