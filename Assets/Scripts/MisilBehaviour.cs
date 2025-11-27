using UnityEngine;

public class MisilBehaviour : MonoBehaviour
{
    public float misileTime = 3f;
    private float shootedTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        shootedTime += Time.deltaTime;
        //Debug.Log(shootedTime);
        if (misileTime <= shootedTime)
        {
            DestroyMisile();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Misil impactado01");

        // Buscar si el objetivo con el que se hace colisión tiene sistema de vida
        SistemaVida vidaObjetivo = collision.GetComponent<SistemaVida>();

        if (vidaObjetivo != null)
        {
            vidaObjetivo.RecibirDaño(25);
        }

        // Detruir misil al impactar
        DestroyMisile();


    }

    private void DestroyMisile()
    {
        Destroy(this.gameObject);
    }
}
