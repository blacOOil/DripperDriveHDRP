using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour
{
    public GameObject Itseft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
           
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
