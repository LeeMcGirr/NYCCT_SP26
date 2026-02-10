using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timeLimit = 30f;
    public float timer = 3f;
    public GameObject myPlayer;
    public GameObject basicCoin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this timer runs every 3 seconds and resets to run again
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Vector3 spawnPoint = Random.insideUnitSphere * 6f;
            spawnPoint.z = 0f;
            Instantiate(basicCoin, spawnPoint, Quaternion.identity);
            timer = 3;
        }

        //this timer runs only ONCE then ends
        if(timeLimit >= 0)
        {
            timeLimit -= Time.deltaTime;
            if(timeLimit < 0)
            {
                Debug.Log("Game Over");
                Destroy(myPlayer);
            }
        }
        
    }
}
