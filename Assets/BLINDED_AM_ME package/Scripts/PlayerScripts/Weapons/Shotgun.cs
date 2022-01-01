using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public GameObject barrel;
    public GameObject projectile;


    public LayerMask layermask;

    public float projectileSpeed;
    public float shotgunOffset;
    public int pelletAmount;

    void Start()
    {
        
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.T))
        {

            RaycastHit hit;

            for (int i = 0; i < pelletAmount; i++)
            {
                //currentHitDistance = maxDistance;
                //You create a random direction
                Quaternion tempRotation = Random.rotation;

                float minYOffset = Random.Range(-shotgunOffset, 0);
                float maxYOffset = Random.Range(shotgunOffset, 0);

                float minXoffset = Random.Range(-shotgunOffset, 0);
                float maxXoffset = Random.Range(shotgunOffset, 0);

                Vector3 projectileSpawn = new Vector3(((minXoffset + maxXoffset / 1.5f) + 0.5f), ((minYOffset + maxYOffset / 1.5f) + 0.5f), 0);

                Vector3 finalDirection = (transform.forward - barrel.transform.position).normalized;

                //Shoot a raycast, the way we deal damage
                Physics.Raycast(transform.position, transform.forward, out hit, 800, layermask);

                //Creates a projectile (Purely cosmetic to give the player a tactial sense of firing something)
                //GameObject rb = Instantiate(projectile, barrel.transform.position - transform.right * projectileSpawn.x + transform.up * projectileSpawn.y, Quaternion.identity);
                //GameObject rb = Instantiate(projectile, barrel.transform.position, Quaternion.identity);
                //then adds force to that projectile, launching it
                //GameObject rb = Instantiate(projectile, barrel.transform.position, transform.rotation = new Quaternion(projectileSpawn.x, transform.rotation.y + projectileSpawn.y, projectileSpawn.z, transform.rotation.w));
                GameObject rb = Instantiate(projectile, barrel.transform.position, Quaternion.identity);
                rb.transform.rotation = new Quaternion(transform.rotation.x, 45, transform.rotation.z, transform.rotation.w);
                rb.GetComponent<Rigidbody>().AddForce(rb.transform.forward * projectileSpeed, ForceMode.Impulse);
                //rb.GetComponent<Rigidbody>().AddForce(transform.forward  * projectileSpeed, ForceMode.Impulse);

            }

            //if(Physics.Raycast(transform.position, transform.forward, out hit, 20, layermask))
            //{
            //    print(hit.collider.name);
            //}
        }



    }
}
