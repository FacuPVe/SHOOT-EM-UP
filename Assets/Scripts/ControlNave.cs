using UnityEngine;

public class ControlNave : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad del proyectil
    public GameObject proyectilPrefab; // Referencia al prefab del proyectil
    public Transform puntoDisparo; // Punto desde donde se disparará el proyectil
    public float velocidadProyectil = 10f; // Velocidad del proyectil

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoName();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        // Instanciar el proyectil en el punto de disparo y la misma rotación de la nave
        GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);

        // Añadir velocidad de proyectil
        Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * velocidadProyectil;
    }
    private void MovimientoName()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(movimientoHorizontal, movimientoVertical) * velocidad * Time.deltaTime;
        
        // Calcular la nueva posición
        Vector3 nuevaPosicion = transform.position + (Vector3)movimiento;
        
        // Obtener los límites de la cámara
        Camera cam = Camera.main;
        if (cam != null)
        {
            float alturaCamara = cam.orthographicSize;
            float anchoCamara = alturaCamara * cam.aspect;
            
            float limiteIzquierdo = cam.transform.position.x - anchoCamara;
            float limiteDerecho = cam.transform.position.x + anchoCamara;
            float limiteInferior = cam.transform.position.y - alturaCamara;
            float limiteSuperior = cam.transform.position.y + alturaCamara;
            
            nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, limiteIzquierdo, limiteDerecho);
            nuevaPosicion.y = Mathf.Clamp(nuevaPosicion.y, limiteInferior, limiteSuperior);
        }
        
        transform.position = nuevaPosicion;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        MisilBehaviour misil = collision.GetComponent<MisilBehaviour>();
        SistemaVida vidaObjetivo = collision.GetComponent<SistemaVida>();
        
        if (misil == null)
        {
            if (vidaObjetivo != null)
            {
                // Daño letal al enemigo
                vidaObjetivo.RecibirDaño(1000); 
                
                // Daño letal al jugador
                SistemaVida miSistemaVida = GetComponent<SistemaVida>();
                if (miSistemaVida != null)
                {
                    miSistemaVida.RecibirDaño(1000);
                }
            }
            else
            {
                SistemaVida miSistemaVida = GetComponent<SistemaVida>();
                if (miSistemaVida != null)
                {
                    miSistemaVida.RecibirDaño(1000);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
