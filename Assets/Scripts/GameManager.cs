using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    //public ChildController [] children; 
   public GameObject[] children;
   public GameObject [] tasks; 
   public GameObject [] desks;
   public int taskInd; //current task
   public bool taskActive; 
   public bool kid_counting; //is counter already counting
   public bool task_counting;
   public bool kid_standing = false;
   public float kid_timer;
   public float task_timer;
   public GameObject player;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        kid_counting = false;
        task_counting = false;

        taskActive = false;

        player = GameObject.Find("Player");
        children = GameObject.FindGameObjectsWithTag("Child");
        desks = GameObject.FindGameObjectsWithTag("Desk");
        //tasks = GameObject.FindGameObjectsWithTag("TaskItem");

    }

    // Update is called once per frame
    void Update()
    {
        KidTimerUpdate();
        TaskTimerUpdate();

        if(player.GetComponent<Player>().GetHealth() == 0){
            GameOver();
        }
    }


    /*
        Create a timer from 15-35 seconds and update it
        When it reaches 0, call KidStandUp
    */

    void KidTimerUpdate(){
        if(!kid_counting){
            //generate random time to count down from
            kid_counting = true;
            kid_timer = Random.Range(15,35);
        }
        else{
            kid_timer -= Time.deltaTime;

        }
        if (kid_timer<=0 && !kid_standing){
            kid_counting = false;

            int fightOrLeave = Random.Range(0, 10);
            print(fightOrLeave);
            if(fightOrLeave > 4)
            {
                kid_standing = true;
                KidStandUp();
            }
            else
            {
                kid_standing = true;
                KidFight();
            }
            
        }

    }

    /*
        Choose random child to stand up and leave the room
    */

    void KidStandUp(){
        int kidInd = Random.Range(0, children.Length);
        
        children[kidInd].GetComponent<ChildController>().StandUp();
    }

    void KidFight()
    {
        int kidInd = 0; 
        int kidInd2 = 0;
        do
        {
            kidInd = Random.Range(0, children.Length);
            kidInd2 = Random.Range(0, children.Length);
        } while (kidInd == kidInd2);
        children[kidInd].GetComponent<ChildController>().Fight();
        children[kidInd2].GetComponent<ChildController>().Fight();
    }

    /*
        Create a timer from 30-40 seconds and update it
        When it reaches 0, call Task()
    */
    void TaskTimerUpdate(){
        if(!task_counting){
            //generate random time to count down from
            task_counting = true;
            //task_timer = Random.Range(30,40);
            task_timer = 10;
            //Debug.Log(task_timer);
        }
        else{
            task_timer -= Time.deltaTime;
            //Debug.Log(task_timer);

        }
        
        if (task_timer<=0){
            task_counting = false;
            Task();
        }
    }

    /*
        Begin a task. If task is not done by the time
        Another task activates then reduce health
        taskActive - needs to be updated within task script?
    */

    void Task(){
        if(taskActive){
            //task already active - player loses points and move to next task
            player.GetComponent<Player>().ReduceHealth(10);
        }
        else{
            //activate a new task
            tasks[0].GetComponent<Task>().Activate();
            taskActive = true;
        }
        
    }

    /*
        Show score and game over screen
    */
    void GameOver(){
        
    }

}
