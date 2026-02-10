using UnityEngine;

public class CracklePopper : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CracklePop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CracklePop()
    {
        for (int i =1; i <=100; i++)
        {
            if(i%5 == 0) 
            {
                if (i % 3 == 0)
                {
                    print("CracklePop");
                }
                else { print("Pop"); }
            }
            else if(i%3 == 0) { print("Crackle"); }
            else { print(i); }
        }
    }
}
