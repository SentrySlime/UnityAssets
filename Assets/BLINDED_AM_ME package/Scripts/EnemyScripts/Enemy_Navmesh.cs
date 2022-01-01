using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Navmesh : MonoBehaviour
{
    GameObject player;

    public bool canMove = true;
    public float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(canMove)
        {
            RotateTowardsPlayer();
            MoveTowardsPlayer();
        }
    }

    public void RotateTowardsPlayer()
    {
        Vector3 tempVec = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        transform.LookAt(tempVec);
    }

    public void MoveTowardsPlayer()
    {
        var distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance > 3)
        {
            Vector3 tempvec = (player.transform.position - transform.position).normalized;
            transform.position = transform.position += (tempvec * speed) * Time.deltaTime;
        }
    }

}
