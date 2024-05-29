using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweUps : MonoBehaviour
{
    public GameObject Health;
    public GameObject Shield;
    private int Counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Wall"))//destroys the powerups if they touch the wall
        {
            Destroy(collision.gameObject);//destroy
        }
    }

    public void generator()
    {
        Vector3 position1 = new Vector3(Random.Range(-7, 7), 0, Random.Range(-3, 7));//random range sheild
        Instantiate(Health, position1, Quaternion.identity);//creates them 
        Vector3 position2 = new Vector3(Random.Range(-7, 7), 0, Random.Range(-3, 7));//random range for shield
        Instantiate(Shield, position2, Quaternion.identity);
        Counter++;
    }
}