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
        transform.Translate(movimiento);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Deestruir la nave cuando toca alguna estructura (meteoritos y decorados)
        Destroy(this.gameObject);
    }
}
