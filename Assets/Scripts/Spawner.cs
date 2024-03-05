using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject healthPickupPrefab;
    public GameObject fuelPickupPrefab;
    public GameObject obstaclePrefab;
    // Start is called before the first frame update
    void Start()
    {
        // INstntiate Health Pickup Prefabs along the Track
        for (int i = 0; i < 10; i++)
        {
            float x = Random.Range(-10, 10);
            float y = Random.Range(3, 8);
            float z = i * 200 + Random.Range(-5,5);
            Instantiate(healthPickupPrefab, new Vector3(x,y,z), Quaternion.identity);
        }

        // INstntiate Fuel Pickup Prefabs along the Track
        for (int i = 0; i < 10; i++)
        {
            float x = Random.Range(-10, 10);
            float y = Random.Range(3, 8);
            float z = i * 200 + Random.Range(-3,3);

            float rotation = Random.Range(0, 360);
            Instantiate(fuelPickupPrefab, new Vector3(x,y,z), Quaternion.Euler(0,rotation,0));
        }

        // INstntiate Obstacle Prefabs along the Track
        for (int i = 0; i < 40; i++)
        {
            float x = Random.Range(-10, 10);
            float y = Random.Range(5, 40);
            float z = i * 50 + Random.Range(-3,3);
            GameObject obj = Instantiate(obstaclePrefab, new Vector3(x,y,z), Quaternion.identity);
            //impart rotational force to the obstacle
            obj.GetComponent<Rigidbody>().AddTorque(Random.Range(-10,10),Random.Range(-10,10),Random.Range(-10,10), ForceMode.Impulse);

            obj.GetComponent<Rigidbody>().AddForce(Random.Range(-20, 20), Random.Range(-20, 0), Random.Range(-20, 20), ForceMode.Impulse);
        }

        // Spawn building represented by cubes alongside the track
        for (int i = 0; i < 500; i++)
        {
            float x = Random.Range(-50, -30);
            if(i % 2 == 0)
            {
                x *= -1;
            }
            float y = -20;
            float z = i * 50 + Random.Range(-3,3);
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.transform.position = new Vector3(x,y,z);
            obj.transform.localScale = new Vector3(Random.Range(10,40), Random.Range(150, 440), Random.Range(10, 40));
        }
    }   
    
    // Update is called once per frame
    void Update()
    {
        //sometimes spawn a new obstacle
        if(Random.Range(0,100) < 20)
        {
            float x = Random.Range(-40, 40);
            float y = Random.Range(10, 60);
            float z = Random.Range(-3,2000);
            GameObject obj = Instantiate(obstaclePrefab, new Vector3(x,y,z), Quaternion.identity);
            //impart rotational force to the obstacle
            obj.GetComponent<Rigidbody>().AddTorque(Random.Range(-10,10),Random.Range(-10,10),Random.Range(-10,10), ForceMode.Impulse);
            
            obj.GetComponent<Rigidbody>().AddForce(Random.Range(-20, 20), Random.Range(-20, 0), Random.Range(-20, 20), ForceMode.Impulse);
        }
    }
}
