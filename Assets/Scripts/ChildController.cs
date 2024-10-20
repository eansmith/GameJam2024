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
    public bool isFighting = false;
    public bool isWalkingtoFight = false;
    Animator animator;

    public Transform exit;
    public Transform fight;

    public float pickUpDistance = 3;
    public Player player;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StandUp();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Fight();
        }
        if (Input.GetMouseButtonDown(0) && Vector3.Distance(cam.transform.position, this.transform.position) < pickUpDistance)
        {
                
                if (!isPickedUp && !isWalkingtoFight && !player.isHoldingChild)
                {
                    if (isStoodUp && agent.velocity.magnitude > 0 || isFighting) //if player is moving
                    {
                        isPickedUp = true;
                        player.isHoldingChild = true;
                        animator.SetBool("IsPickedUp", true);
                    }
                }
                //else
                //{
                   // isPickedUp = !isPickedUp;
                   // animator.SetBool("IsPickedUp", isPickedUp);
                //}

            
            
        }
        if (isPickedUp)
        {
            agent.Warp(childHolder.transform.position);
        }
        
        if (isFighting )
        {
            
            if(agent.remainingDistance < 1f && !isPickedUp) {
                isWalkingtoFight = false;
                animator.SetBool("IsFighting", true);
            }
            else
            {
                isWalkingtoFight = true;
                animator.SetBool("IsFighting", false);
                animator.SetBool("IsWalking", true);
            }
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
        isFighting = false;
        isWalkingtoFight = false;
        animator.SetBool("IsPickedUp", false);
        agent.Warp(chair.transform.position);
        player.isHoldingChild = false;

    }

    public void Fight()
    {
       
       isFighting = true;
       isWalkingtoFight = true;
       agent.SetDestination(fight.position);
    }
}
