using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCoingenerator : MonoBehaviour
{
    public GameObject coin;
    private int coinCounter;

    // Update is called once per frame

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            generator();
        }
            
    }

    void Update()
    {
    }

    public void generator()
    {
        //randomly generates 3 coins in random location on one part of the stage
            Vector3 position = new Vector3(Random.Range(11, 20), 2.75f, Random.Range(-11, 0));
            Instantiate(coin, position, Quaternion.identity);
            coinCounter++;
    }
}
