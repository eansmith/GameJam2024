using UnityEngine;

public class PencilTask : MonoBehaviour, Task
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float activateDistance;
    public Player player;
    public int clicks;
    public GameManager gm;
    bool inRadius;
    bool active;
    public GameObject taskUI;
    void Start()
    {
        activateDistance = 10;
        taskUI = this.gameObject.transform.GetChild(0).gameObject;
        taskUI.SetActive(false);       
    }

    // Update is called once per frame
    void Update()
    {
        if (clicks == 5){
            Deactivate();
        }
        else if (Input.GetKeyDown("x") && inRadius && active)
        {
            clicks++;
            Debug.Log(clicks);
        }
    }

    public void Activate(){
        taskUI.SetActive(true);
        //transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);        Debug.Log("active!");
        Vector3 temp = new Vector3(1,3,12);
        taskUI.transform.position = temp;
        Debug.Log(taskUI.transform.position);
        
        active = true;
        
    }

    public void Deactivate(){
        gm.taskActive = false;
        clicks = 0;
        taskUI.SetActive(false);
        active = false;
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
}
