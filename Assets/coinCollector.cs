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

    }

    void OnTriggerEnter2D(Collider2D other)
    {

    }

    public void AddScore(int s)
    {
        score += s;
    }
}
