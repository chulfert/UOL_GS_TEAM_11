using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float health = 100f;
    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < Camera.main.transform.position.z)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
        
    }

    public void TakeDamage()
    {
        health -= 10f;
        if (health <= 0f)
        {
            if(Explosion != null)
            {
                Debug.Log("Exploded");
                Instantiate(Explosion, transform.position, Quaternion.identity);
                
            }
            Destroy(gameObject, 0.5f);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerController>().TakeDamage(30);
            other.GetComponent<Rigidbody>().AddForce(Vector3.back * 20, ForceMode.Impulse);
            TakeDamage();
            if (Explosion != null)
            {
                Debug.Log("Explosion");
                Instantiate(Explosion, transform.position, Quaternion.identity);

            }
            Destroy(gameObject);
        }
    }
}
