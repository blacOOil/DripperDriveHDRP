using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchingHelicopter : MonoBehaviour
{
    public Transform target,target0;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = transform.position;
        Vector3 b = target.position;
      //  Vector3 c = target0.position;
        transform.position = Vector3.Lerp(a, b, Speed);
       // transform.position = Vector3.Lerp(b, c, Speed);
    }
}
