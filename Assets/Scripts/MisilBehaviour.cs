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
        Debug.Log(shootedTime);
        if (misileTime <= shootedTime)
        {
            DestroyMisile();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        DestroyMisile();
    }

    private void DestroyMisile()
    {
        Destroy(this.gameObject);
    }
}
