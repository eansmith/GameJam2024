using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class ChildController : MonoBehaviour
{
    public Camera cam;

    public NavMeshAgent agent;

    public Transform childHolder;
    public Transform chair;

    public bool isPickedUp = false;
    public bool isStoodUp = false;

    Animator animator;

    public Transform exit;

    public float pickUpDistance = 3;


    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            /*Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }*/
            StandUp();
        }
        if (Input.GetMouseButtonDown(0) && Vector3.Distance(cam.transform.position, this.transform.position) < pickUpDistance)
        {
                
                if (!isPickedUp)
                {
                    if (agent.velocity.magnitude > 0)
                    {
                        isPickedUp = !isPickedUp;
                        animator.SetBool("IsPickedUp", isPickedUp);
                    }
                }
                else
                {
                    isPickedUp = !isPickedUp;
                    animator.SetBool("IsPickedUp", isPickedUp);
                }

            
            
        }
        if (isPickedUp)
        {
            agent.Warp(childHolder.transform.position);
        }

    }

    public void StandUp()
    {
        isStoodUp = true;
        agent.SetDestination(exit.position);
    }

    public void SitDown()
    {

        isStoodUp = false;
        isPickedUp = false;
        animator.SetBool("IsPickedUp", false);
        agent.Warp(chair.transform.position);

    }
}
