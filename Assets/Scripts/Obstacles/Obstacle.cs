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
        
    }

    public void TakeDamage()
    {
        health -= 20f;
        if (health <= 0f)
        {
            if(Explosion != null)
            {
                Instantiate(Explosion, transform.position, Quaternion.identity);
                
            }
            Destroy(gameObject);

        }
    }
}
