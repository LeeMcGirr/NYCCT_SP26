using UnityEngine;

public class basic_wasd : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody2D myRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 targetDir = Vector3.zero;

        //IF the W key is pressed, THEN add a vector3 pointing forwards or up to the player's target or desired direction
        if(Input.GetKey(KeyCode.W))
        {
            targetDir = targetDir + Vector3.up;
        }

        if(Input.GetKey(KeyCode.S))

        {
            targetDir += Vector3.down;
        }

        if(Input.GetKey(KeyCode.D))
        {
            targetDir += Vector3.right;
        }

        if(Input.GetKey(KeyCode.A))
        {
            targetDir += Vector3.left;
        }

        targetDir = targetDir * speed;
        myRB.linearVelocity = targetDir;
    }
}
