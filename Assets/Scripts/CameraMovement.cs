using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float movingSpeed = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * movingSpeed;
        if (transform.position.x >= 186)
        {
            movingSpeed = 0f;
        }
    }
}
