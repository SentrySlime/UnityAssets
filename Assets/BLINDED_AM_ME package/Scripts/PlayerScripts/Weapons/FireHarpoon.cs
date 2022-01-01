using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHarpoon : MonoBehaviour
{

    public GameObject harpoon;
    public float Velocity;
    public GameObject barrel;

    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(harpoon, transform.position, transform.rotation).GetComponent<Rigidbody>().AddForce(transform.forward * Velocity);
        }
        
    }
}
