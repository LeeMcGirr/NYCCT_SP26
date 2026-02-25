using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager _gmInstance;

    public float timeLimit = 30f;
    public float timer = 3f;
    public rocketPlayer myPlayerScript;
    public GameObject myPlayer;
    public GameObject basicCoin;

    public List<coin> allCoins;

    void Awake()
    {
        _gmInstance = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myPlayerScript = rocketPlayer._playerInstance;
        myPlayer = myPlayerScript.gameObject;

        //run the code in the following curly braces X amount of times, where X is the number
        //of iterations from 0 to 100 when you add +1 to i each time
        for(int i = 0; i < 100; i++)
        {
            //code here runs 99 times before this for loop finishes
        }

        coin[] startingCoinArray = GameObject.FindObjectsByType<coin>(FindObjectsSortMode.InstanceID);
        foreach (coin c in startingCoinArray)
        {
            allCoins.Add(c);
        }
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
            GameObject newCoin = Instantiate(basicCoin, spawnPoint, Quaternion.identity);
            allCoins.Add(newCoin.GetComponent<coin>());
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
