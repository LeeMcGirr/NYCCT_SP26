using UnityEngine;

public class coin : MonoBehaviour
{
    public int value = 1;
    public float explosionForce = 500;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //collision.gameObject.SendMessage("AddScore", value);
            GameManager._gmInstance.myPlayer.SendMessage("AddScore", value);

            GameObject player = addForcePlayer._playerInstance.gameObject;

            //find the direction from one object to another
            Vector3 distance = player.transform.position - transform.position;
            //distance.normalized has a length of 1 
            player.GetComponent<Rigidbody2D>().AddForce(distance.normalized*explosionForce);

            Destroy(this.gameObject);
        }

    }
}
