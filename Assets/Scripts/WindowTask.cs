using UnityEngine;

public class WindowTask : MonoBehaviour, Task
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float activateDistance;
    public Camera cam;
    public int clicks;

    public GameObject taskUI;
    void Start()
    {
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
        if (Vector3.Distance(cam.transform.position, this.transform.position) < activateDistance){
            taskUI.SetActive(true);
        }
    }

    public void Deactivate(){
        
    }
}
