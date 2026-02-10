using UnityEngine;

public class rocket_wasd : MonoBehaviour
{
    public Rigidbody2D myRB;
    public float speed = 3f;
    public float ySpeed = 1f;
    Vector3 inputDir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello World");
    }
    //functions with the prefix VOID do not return a value
    // Update is called once per frame
    void Update()
    {
        inputDir = Direction();
        //Debug.Log("player input: " + inputDir);
    }
    //FixedUpdate is called once every physics frame
    void FixedUpdate()
    {

        //placeholder velocity so we can break it up
        //and add the natural gravity back in
        Vector3 newVel = inputDir * speed;

        //setting the linearVel = gravity in the Y axis
        newVel.y = myRB.linearVelocity.y;

        //if there IS a y input from the player
        if(inputDir.y != 0) 
        { 
            //adding that back in on TOP of the existing gravity
            newVel.y += inputDir.y * ySpeed; 
        }

        if (inputDir != Vector3.zero)
        {
            myRB.linearVelocity = newVel;
        }
    }
 
    //functions can return a value sometimes
    Vector3 Direction()
    {
        Vector3 dir = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
        {
            dir = dir + Vector3.up;
        }

        else if(Input.GetKey(KeyCode.S))
        {
            dir = dir + Vector3.down;
        }


        if(Input.GetKey(KeyCode.A))
        {
            dir += Vector3.left;
        }

        else if(Input.GetKey(KeyCode.D))
        {
            dir += Vector3.right;
        }
            return dir;
    }
}
