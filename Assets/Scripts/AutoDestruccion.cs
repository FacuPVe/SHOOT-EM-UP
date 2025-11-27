using UnityEngine;

public class AutoDestruccion : MonoBehaviour
{
    public float tiempoDeExplosion = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, tiempoDeExplosion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
