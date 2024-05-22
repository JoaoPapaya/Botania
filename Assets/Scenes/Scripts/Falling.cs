using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{

    public float wait;
    public GameObject FallingObject;
  
    void Start()
    {
        InvokeRepeating("Fall", wait, wait);
    }

    void Fall()
    {
        Instantiate(FallingObject, new Vector3(Random.Range(-9, 9), 3, 0), Quaternion.identity);
    }
}
