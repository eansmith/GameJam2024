using UnityEngine;

public class GameManager : MonoBehaviour
{
   public GameObject [] children; 
   public GameObject [] tasks; 
   public int taskInd; //current task
   public bool taskActive; 
   public bool kid_counting; //is counter already counting
   public bool task_counting;
   public float kid_timer;
   public float task_timer;
   Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        kid_counting = false;
        task_counting = false;

        taskActive = false;

        children = GameObject.FindGameObjectsWithTag("child");
        tasks = GameObject.FindGameObjectsWithTag("task_item");
        

    }

    // Update is called once per frame
    void Update()
    {
        KidTimerUpdate();
        TaskTimerUpdate();

        if(player.health==0){
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
        if (kid_timer<=0){
            kid_counting = false;
            KidStandUp();
        }

    }

    /*
        Choose random child to stand up and leave the room
    */
    void KidStandUp(){
        int kidInd = Random.Range(0, 8);
        //children[kidInd].StandUp()
    }

    /*
        Create a timer from 30-40 seconds and update it
        When it reaches 0, call Task()
    */

    void TaskTimerUpdate(){
        if(!task_counting){
            //generate random time to count down from
            task_counting = true;
            task_timer = Random.Range(30,40);
        }
        else{
            task_timer -= Time.deltaTime;
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
            player.health -= 10;
        }
        else{
            //activate a new task
            //tasks[taskInd].activate(); we will have to add this
            taskActive = true;
        }
        
    }

    /*
        Show score and game over screen
    */
    void GameOver(){

    }

}
