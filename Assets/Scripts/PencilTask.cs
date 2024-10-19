using UnityEngine;

public class PencilTask : MonoBehaviour, Task
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float activateDistance;
    public Player player;
    public int clicks;

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
        if (clicks>=5){
            Deactivate();
        }
        else if (Input.GetKeyDown("x"))
        {
            clicks++;
        }
    }

    public void Activate(){
        taskUI.SetActive(true);
        Debug.Log("active!");
        if (Vector3.Distance(player.transform.position, this.transform.position) < activateDistance){
            
        }
    }

    public void Deactivate(){
        
    }
}
