using UnityEngine;

public class movingPlatform : MonoBehaviour
{

    Vector3 startPos;
    Vector3 prevFramePos;
    public float speed;
    public float distance;

    public GameObject rider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //find the delta from start position to move the object
        float deltaX = Mathf.Sin(Time.time*speed)*distance;
        //set the new pos based off the recorded start pos from Start()
        Vector3 newPos = new Vector3(startPos.x + deltaX, startPos.y, startPos.z);
        transform.position = newPos;

        //finding the delta from LAST FRAME
        Vector3 deltaPos = transform.position - prevFramePos;
        //if the player is on the platform, MOVE them with the platform!
        if (rider != null) { rider.transform.position += deltaPos; }
        Debug.Log("deltaPos: " + deltaPos);

        //saving the position from the end of this frame for use in the next frame
        prevFramePos = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rider = collision.gameObject;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            rider = null;
        }
    }
}
