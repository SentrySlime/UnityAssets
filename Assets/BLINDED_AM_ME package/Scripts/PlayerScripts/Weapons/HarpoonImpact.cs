using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonImpact : MonoBehaviour
{


    public LayerMask CastMask;

    Vector3 oldPos;

    public bool impacted = false;
    public bool transformed = false;

    public List <GameObject> lastEnemy = new List<GameObject>();
    public Transform stuckPoint;
    public LayerMask layerMask;

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward * -6, out hit, 6, layerMask))
        //if (Physics.SphereCast(transform.position, 1, transform.forward * -6, out hit, 6, layerMask))
        {
            Debug.DrawRay(transform.position, transform.forward * -6, Color.red, 6);
            if (hit.collider.CompareTag("Wall") && !impacted)
            {
                HitWall(hit);
                if(lastEnemy != null && transformed)
                    for (int i = 0; i < lastEnemy.Count; i++)
                    {
                        lastEnemy[i].transform.localPosition = new Vector3(lastEnemy[i].transform.localPosition.x, lastEnemy[i].transform.localPosition.y, - 1.5f);
                        //lastEnemy[i].tag = "Untagged";
                        //lastEnemy[i].layer = 0;
                    }
                
            }
            else if (hit.collider.CompareTag("Cutable"))
            {
                HitEnemey(hit);
                transformed = true;
            }
        }
    }

    public void HitWall(RaycastHit hit)
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = hit.point;
        impacted = true;
    }

    public void HitEnemey(RaycastHit hit)
    {
        GameObject tempObj = hit.collider.gameObject;
        lastEnemy.Add(tempObj);
        if (tempObj.GetComponent<Enemy_Navmesh>())
            tempObj.GetComponent<Enemy_Navmesh>().canMove = false;
        tempObj.transform.SetParent(gameObject.transform, true);
        tempObj.GetComponent<Rigidbody>().isKinematic = true;
        tempObj.transform.localPosition = new Vector3(hit.collider.gameObject.transform.localPosition.x, hit.collider.gameObject.transform.localPosition.y, -1.5f/*Hit.collider.gameObject.transform.localPosition.z*/);
    }
}
