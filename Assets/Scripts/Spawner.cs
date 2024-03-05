using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject healthPickupPrefab;
    public GameObject fuelPickupPrefab;
    public GameObject obstaclePrefab;

    public Material buildingMat;
    public Material emissiveMat;
    public Light pointLightPrefab;
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
            //scale obstacles to random size
            obj.transform.localScale = new Vector3(Random.Range(1,3), Random.Range(1,3), Random.Range(1,3));
            //impart rotational force to the obstacle
            obj.GetComponent<Rigidbody>().AddTorque(Random.Range(-8,8),Random.Range(-8,8),Random.Range(-8,8), ForceMode.Impulse);

            obj.GetComponent<Rigidbody>().AddForce(Random.Range(-15, 15), Random.Range(-5, 0), Random.Range(-15, 15), ForceMode.Impulse);
        }

        // Spawn building represented by cubes alongside the track
        for (int i = 0; i < 500; i++)
        {
            float x = Random.Range(-60, -40);
            if (i % 2 == 0) x *= -1;
            float y = 0; // Ground level adjustment
            float z = i * 4 + Random.Range(-3, 3);

            // Main building
            GameObject buildingBase = GameObject.CreatePrimitive(PrimitiveType.Cube);
            buildingBase.transform.position = new Vector3(x, y, z);
            buildingBase.transform.localScale = new Vector3(Random.Range(25, 40), Random.Range(40, 200), Random.Range(25, 60));
            buildingBase.GetComponent<Renderer>().material = buildingMat;

            // Add a simple detail to the building
            GameObject buildingDetail = GameObject.CreatePrimitive(PrimitiveType.Cube);
            buildingDetail.transform.parent = buildingBase.transform;
            buildingDetail.transform.localPosition = new Vector3(0, 1.1f, 0); // Position on top of the base
            buildingDetail.transform.localScale = new Vector3(0.5f, Random.Range(0.2f, 0.6f), 0.5f); // Smaller cube as a detail
            buildingDetail.GetComponent<Renderer>().material = buildingMat;

            if (Random.Range(0, 100) < 20)
            {
                Material neonMaterial = new Material(emissiveMat);
                neonMaterial.SetColor("_EmissionColor", new Color(Random.Range(0.5f, 1), Random.Range(0.5f, 1), Random.Range(0.5f, 1)));
                GameObject billboard = GameObject.CreatePrimitive(PrimitiveType.Quad);
                if (i % 2 == 0)
                {
                    billboard.transform.Rotate(0, -90, 0);
                    billboard.transform.position = new Vector3(-20, y + Random.Range(-10, 30), z);
                }
                else { 
                    billboard.transform.Rotate(0, 90, 0);
                    billboard.transform.position = new Vector3(20, y + Random.Range(-10, 30), z);
                }
                //rotate 90 degress to be parrallel to the z axis
                billboard.transform.localScale = new Vector3(10, 10, 10);
                billboard.GetComponent<Renderer>().material = neonMaterial;



                // Decorate the buidling with point ligths of the same color
                Light pointLight;
                if (i % 2 == 0)
                {
                    Vector3 pos = billboard.transform.position;
                    pos.x += 1;
                    pointLight = Instantiate(pointLightPrefab, pos, Quaternion.identity);
                    //angle towards the track if sspot
                    //pointLight.transform.LookAt(new Vector3(0, 0, z));
                   
                }
                else
                {
                    Vector3 pos = billboard.transform.position;
                    pos.x -=1   ;
                    pointLight = Instantiate(pointLightPrefab, pos, Quaternion.identity);
                    //angle towards the track
                   // pointLight.transform.LookAt(new Vector3(0, 0, z));

                }
                pointLight.color = neonMaterial.GetColor("_EmissionColor");
                pointLight.intensity = Random.Range(55, 100);
                pointLight.range = 250;
                

            }
            
            //spawn thick fog



           
             

            

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
