using UnityEngine;
using System.Collections;

public class ExampleUseof_MeshCut : MonoBehaviour {

	public Material capMaterial;
    public int Velocity;

    public int damage = 100;

    Camera mainCamera;

    public GameObject blade;


    [Header("Sights")]
    public GameObject p11;
    public GameObject p22;

    public GameObject enemy;

	// Use this for initialization
	void Start () {

        mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	void Update(){

        if (Input.GetKey(KeyCode.Q))
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));
        else if (Input.GetKey(KeyCode.E))
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -45));
        else
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));

        if (Input.GetMouseButtonDown(0)){
            //RaycastHit[] hit;

            //hit = Physics.RaycastAll(transform.position, transform.forward, 100);

            //for (int i = 0; i < hit.Length; i++)
            //{
            //    GameObject victim = hit[i].collider.gameObject;
            //    if (victim.CompareTag("Ground"))
            //    {
            //        GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

            //        //Destroy(victim.GetComponent<BoxCollider>());
            //        //victim.AddComponent<MeshCollider>();



            //        //DestroyImmediate(victim.GetComponent<MeshCollider>());
            //        //var collider = victim.AddComponent<MeshCollider>();


            //        //if (!pieces[1].GetComponent<Rigidbody>())
            //        //{
            //        //    //mainCamera.transform.SetParent(pieces[1].transform);
            //        //    Vector3 tempVec = (victim.transform.position - transform.position).normalized;
            //        //    pieces[1].transform.SetParent(null);
            //        //    pieces[1].transform.TransformPoint(pieces[1].transform.position);
            //        //    pieces[1].AddComponent<BoxCollider>();
            //        //    //pieces[1].AddComponent<Rigidbody>().AddForce(tempVec * Velocity, ForceMode.Impulse);
            //        //    //pieces[1].GetComponent<Rigidbody>().AddTorque(-transform.up * 650);


            //        //}
            //    }




            //    //if (!pieces[1].GetComponent<BoxCollider>())
            //    //    pieces[1].AddComponent<BoxCollider>();
            //    //Destroy(pieces[1], 1);

            //}

            //----------------------------------------------------------------------------------------------------------------------------------------

            //RaycastHit hit;

            //if (Physics.Raycast(transform.position, transform.forward, out hit))
            //{

            //    //Physics.RaycastAll(transform.position, transform.forward, 100);
            //    //Physics.RaycastAll(blade.transform.position, blade.transform.forward, 100);
            //    //Physics.BoxCastAll(transform.position, )
            //    GameObject victim = hit.collider.gameObject;
            //    if (victim.CompareTag("Ground"))
            //    {
            //        Vector3 tempVec = (victim.transform.position - transform.position).normalized;

            //        Destroy(victim.GetComponent<BoxCollider>());
            //        victim.AddComponent<BoxCollider>();
            //        victim.GetComponent<Rigidbody>().AddForce(tempVec * Velocity, ForceMode.Impulse);
            //        victim.transform.DetachChildren();
            //        GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

            //        pieces[1].tag = "Ground";

            //        if (!pieces[1].GetComponent<Rigidbody>())
            //        {
            //            pieces[1].AddComponent<Rigidbody>().AddForce(tempVec * Velocity, ForceMode.Impulse);
            //        }

            //        if (!pieces[1].GetComponent<BoxCollider>())
            //            pieces[1].AddComponent<BoxCollider>();

            //        Destroy(pieces[1], 8);
            //    }

            //}

            //--------------------------------------------------------------------------------------------------------------------------

            RaycastHit[] hit;
            ////CharacterController charContr = GetComponent<CharacterController>();
            ////Vector3 p1 = transform.position + charContr.center + Vector3.up * -charContr.height * 3F;
            ////Vector3 p2 = p1 + Vector3.up * 10;
            //float distanceToObstacle = 0;

            // Cast character controller shape 10 meters forward to see if it is about to hit anything.
            hit = Physics.CapsuleCastAll(p11.transform.position, p22.transform.position, 0.5f, transform.forward * 7, 7);

            for (int i = 0; i < hit.Length; i++)
            {

                //Vector3 tempVec = (victim.transform.position - transform.position).normalized;
                if(hit[i].collider.CompareTag("Cutable"))
                {
                    GameObject victim = hit[i].collider.gameObject;

                    if(victim.GetComponent<EnemyHealth>())
                    {
                        EnemyHealth tempEnemy = victim.GetComponent<EnemyHealth>();
                        tempEnemy.TakeDamage(damage);

                        //victim.GetComponent<EnemyHealth>().TakeDamage(damage);

                    }


                    if (!victim.GetComponent<EnemyHealth>().dead)
                        return;
                     GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);


                    //victim.AddComponent<BoxCollider>();


                    Destroy(victim.GetComponent<MeshCollider>());
                    Destroy(victim.GetComponent<BoxCollider>());
                    victim.AddComponent<MeshCollider>().convex = true;



                    pieces[1].tag = "Cutable";
                    pieces[1].layer = 9;
                    victim.layer = 9;

                    pieces[1].transform.parent = null;

                    if (!pieces[1].GetComponent<Rigidbody>())
                    {
                        Vector3 tempVec = (victim.transform.position - transform.position).normalized;
                        //pieces[1].AddComponent<Rigidbody>();
                        pieces[1].AddComponent<Rigidbody>().AddForce(transform.right * 10);
                        //pieces[1].GetComponent<Rigidbody>().AddTorque(tempVec / 2);

                        if (victim.GetComponent<Rigidbody>())
                        {
                            Rigidbody victimRb = victim.GetComponent<Rigidbody>();
                            victimRb.isKinematic = false;
                            victimRb.AddForce(transform.right * -10);
                            victimRb.AddTorque(tempVec * 200);
                            //victim.GetComponent<Rigidbody>().isKinematic = false;
                        }


                    }

                    if (!pieces[1].GetComponent<BoxCollider>())
                        pieces[1].AddComponent<MeshCollider>().convex = true;
                    
                        //    Destroy(pieces[1], 8);

                }

            }



            //--------------------------------------------------------------------------------------------------------------------------

            //RaycastHit hit;

            //var posOne =  transform.up * 0.5;

            //hit = Physics.CapsuleCast(transform.position + (transform.up * 0.5), transform.position + (transform.up * -0.5), 0.2, transform.forward, out hit);

            //if (Physics.Raycast(transform.position, transform.forward, out hit))
            //{

            //    //Physics.RaycastAll(transform.position, transform.forward, 100);
            //    //Physics.RaycastAll(blade.transform.position, blade.transform.forward, 100);
            //    //Physics.BoxCastAll(transform.position, )
            //    GameObject victim = hit.collider.gameObject;
            //    if (victim.CompareTag("Ground"))
            //    {
            //        Vector3 tempVec = (victim.transform.position - transform.position).normalized;

            //        Destroy(victim.GetComponent<BoxCollider>());
            //        victim.AddComponent<BoxCollider>();
            //        victim.GetComponent<Rigidbody>().AddForce(tempVec * Velocity, ForceMode.Impulse);
            //        victim.transform.DetachChildren();
            //        GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

            //        pieces[1].tag = "Ground";

            //        if (!pieces[1].GetComponent<Rigidbody>())
            //        {
            //            pieces[1].AddComponent<Rigidbody>().AddForce(tempVec * Velocity, ForceMode.Impulse);
            //        }

            //        if (!pieces[1].GetComponent<BoxCollider>())
            //            pieces[1].AddComponent<BoxCollider>();

            //        Destroy(pieces[1], 8);
            //    }

            //}

            //----------------------------------------------------------------------------------------------------------------------------------------




            //RaycastHit hit;

            //if (Physics.Raycast(transform.position, transform.forward, out hit))
            //{

            //    //Vector3 tempVec = (victim.transform.position - transform.position).normalized;
            //    Physics.RaycastAll(transform.position, transform.forward, 100);
            //    GameObject victim = hit.collider.gameObject;

            //    Destroy(victim.GetComponent<BoxCollider>());
            //    victim.AddComponent<BoxCollider>();

            //    GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

            //    if (!pieces[1].GetComponent<Rigidbody>())
            //        pieces[1].AddComponent<Rigidbody>();

            //    if (!pieces[1].GetComponent<BoxCollider>())
            //        pieces[1].AddComponent<BoxCollider>();
            //    //    Destroy(pieces[1], 8);
            //}
        }
    }

	void OnDrawGizmosSelected() {

		Gizmos.color = Color.green;

		Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5.0f);
        Gizmos.DrawLine(transform.position + transform.up * 0.5f, transform.position + transform.up * 0.5f + transform.forward * 5.0f);
        Gizmos.DrawLine(transform.position + -transform.up * 0.5f, transform.position + -transform.up * 0.5f + transform.forward * 5.0f);

        Gizmos.DrawLine(transform.position, transform.position + transform.up * 0.5f);
        Gizmos.DrawLine(transform.position, transform.position + -transform.up * 0.5f);

    }

}
