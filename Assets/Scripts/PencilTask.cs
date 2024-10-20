using UnityEngine;

public class PencilTask : MonoBehaviour, Task
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Player player;
    public int clicks;
    public GameManager gm;
    bool inRadius;
    bool active;
    public GameObject taskUI;
    public float task_timer;
    public float health_timer;
    public bool decreasing;
    public GameObject[] pencils;
    void Start()
    {
        task_timer = 0;
        taskUI = this.gameObject.transform.GetChild(0).gameObject;
        taskUI.SetActive(false);     
        decreasing = false;  
    }

    // Update is called once per frame
    void Update()
    {
        task_timer+=Time.deltaTime;

        if(task_timer>=10 && !decreasing){
            //start losing health
            decreasing = true;
            InvokeRepeating("ReducePlayerHealth", 1f, 1f);
        }

        if (clicks == 5){
            Deactivate();
        }

        else if (Input.GetKeyDown("x") && inRadius && active)
        {
            clicks++;
            pencils[clicks - 1].SetActive(false);
        }
         
    }

    public void Activate(){
        for (int i = 0; i < pencils.Length; i++)
        {
            pencils[i].SetActive(true);
        }
        taskUI.SetActive(true);           
        active = true;
        
    }

    public void Deactivate(){
        gm.taskActive = false;
        clicks = 0;
        taskUI.SetActive(false);
        active = false;
        CancelInvoke("ReducePlayerHealth");
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player" && active){
            inRadius = true;

        }
    }

    private void OnTriggerExit(Collider other){
        if(other.tag == "Player" && active){
            inRadius = false;
        }
    }

    public void ReducePlayerHealth(){
        player.ReduceHealth(1);
        Debug.Log(player.GetHealth());
    }
}
