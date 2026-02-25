using UnityEngine;

public class rocketPlayer : MonoBehaviour
{
    //in the class let's declare a static instance of the class
    //this variable doesn't have a value yet - here in line 7 it's just an empty reference
    public static rocketPlayer _playerInstance;
    
    
    public GameManager myGM;
    public GameObject Camera;
    public Camera myCam;

    public float score = 0;
    public Rigidbody2D myRB;
    public float speed = 3f;
    public float ySpeed = 1f;
    Vector3 inputDir;

    public bool grounded;
    public SpriteRenderer mySprite;
    
    //awake runs BEFORE start, so it's best for any self-referential script and component values
    void Awake()
    {
        //fill the empty static player instance reference
        _playerInstance = this;
        myRB = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //find our game manager
        myGM = GameManager._gmInstance;
        Transform gameManagerTransform = myGM.gameObject.GetComponent<Transform>();

        Debug.Log("Hello World");

        //find camera so we can code it to follow the player
        //find can use strings as an argument - for the name
        Camera = GameObject.Find("Main Camera");
        Camera = GameObject.FindGameObjectWithTag("MainCamera");

        myCam = Camera.GetComponent<Camera>();



    }
    //functions with the prefix VOID do not return a value
    // Update is called once per frame
    void Update()
    {
        inputDir = Direction();
        //Debug.Log("player input: " + inputDir);

        //camera follow code typically goes in Update because you want the camera
        //to update every time the frame renders
        //Vector3 newCamPos = new Vector3(transform.position.x, transform.position.y, Camera.transform.position.z);
        //Camera.transform.position = newCamPos;
    }
    //FixedUpdate is called once every physics frame
    void FixedUpdate()
    {

        //placeholder velocity so we can break it up
        //and add the natural gravity back in
        Vector3 newVel = myRB.linearVelocity;
        //if there IS a y input from the player
        if(inputDir != Vector3.zero) 
        { 
            //adding that back in on TOP of the existing gravity
            newVel.y += inputDir.y * ySpeed;
            newVel.x += inputDir.x * speed;
        }
     
        myRB.linearVelocity = newVel;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            mySprite.color = Color.green;
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        mySprite.color = Color.blue;
        grounded = false;
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

    public void AddScore(int s)
    {
        score += s;
    }
}
