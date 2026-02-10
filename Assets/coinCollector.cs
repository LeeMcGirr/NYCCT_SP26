using UnityEngine;

public class coinCollector : MonoBehaviour
{
    public float score = 0;
    void Start()
    {  
    }
    void Update()
    {    
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "coin")
        {
            score += 1;
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

    }
}
