using UnityEngine;

public class ProyectilJugador : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Verificar si el proyectil está fuera de los límites de la cámara
        if (!EstaEnCamara())
        {
            Destroy(gameObject);
        }
    }

    private bool EstaEnCamara()
    {
        Camera cam = Camera.main;
        if (cam == null)
        {
            return true; // Si no hay cámara, no destruir
        }

        float alturaCamara = cam.orthographicSize;
        float anchoCamara = alturaCamara * cam.aspect;

        float limiteIzquierdo = cam.transform.position.x - anchoCamara;
        float limiteDerecho = cam.transform.position.x + anchoCamara;
        float limiteInferior = cam.transform.position.y - alturaCamara;
        float limiteSuperior = cam.transform.position.y + alturaCamara;

        Vector3 posicion = transform.position;
        
        // Verificar si está fuera de los límites (con un pequeño margen para evitar destrucción prematura)
        return posicion.x >= limiteIzquierdo && posicion.x <= limiteDerecho &&
               posicion.y >= limiteInferior && posicion.y <= limiteSuperior;
    }
}

