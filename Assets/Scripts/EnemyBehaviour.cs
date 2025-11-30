using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad del proyectil
    public GameObject proyectilPrefab; // Referencia al prefab del proyectil
    public Transform puntoDisparo; // Punto desde donde se disparará el proyectil
    public float velocidadDisparo = 10f; // Velocidad del proyectil disparado
    public float tiempoDisparo = 2f; // Tiempo de disparo del proyectil
    public float refrescoDisparo = 0f; // Tiempo de refresco del disparo del proyectil


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        refrescoDisparo = 6;
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoName();
        if (refrescoDisparo > tiempoDisparo && EstaEnCamara())
        {
            Disparar();
            refrescoDisparo = 0f;
        }
        refrescoDisparo += Time.deltaTime;
    }

    void Disparar()
    {
        // Instanciar el proyectil en el punto de disparo y la misma rotación de la nave
        GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);

        // Añadir velocidad al proyectil
        Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(-1f, 0f) * velocidadDisparo;
    }

    private void MovimientoName()
    {
        //Debug.Log(this.transform.position.x);
        Vector2 movimiento = new Vector2(1, 0f) * velocidad * Time.deltaTime;
        transform.Translate(movimiento);
    }

    private bool EstaEnCamara()
    {
        Camera cam = Camera.main;
        if (cam == null)
        {
            return false;
        }

        float alturaCamara = cam.orthographicSize;
        float anchoCamara = alturaCamara * cam.aspect;

        float limiteIzquierdo = cam.transform.position.x - anchoCamara;
        float limiteDerecho = cam.transform.position.x + anchoCamara;
        float limiteInferior = cam.transform.position.y - alturaCamara;
        float limiteSuperior = cam.transform.position.y + alturaCamara;

        // Verificar si el enemigo está dentro de los límites de la cámara
        Vector3 posicion = transform.position;
        return posicion.x >= limiteIzquierdo && posicion.x <= limiteDerecho &&
               posicion.y >= limiteInferior && posicion.y <= limiteSuperior;
    }
}
