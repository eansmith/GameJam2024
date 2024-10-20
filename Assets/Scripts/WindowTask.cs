using UnityEngine;
using TMPro;

public class WindowTask : MonoBehaviour, Task
{
    public Player player;
    public Camera cam;
    public int clicks; // Num clicks to wipe window
    public GameObject taskUI; // UI text that appears when task is active
    public GameObject dirtyWindow;
    public float task_timer;
    private bool inRadius;
    private bool active;
    public bool decreasing;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        task_timer = 0;
        taskUI.SetActive(false);
        dirtyWindow.SetActive(false);
        decreasing = false;
    }

    void Update()
    {
        task_timer += Time.deltaTime;

        if (task_timer >= 30 && !decreasing)
        {
            decreasing = true; // Start losing health
            InvokeRepeating("ReducePlayerHealth", 1f, 1f);
        }

        if (clicks == 30)
        {
            Deactivate();
        }
        else if (Input.GetKeyDown("c") && inRadius && active) // Wiping window
        {
            clicks++;
            IncreaseTransparency();
        }
    }

    public void Activate()
    {
        dirtyWindow.SetActive(true);
        taskUI.SetActive(true);
        active = true;
        task_timer = 0;
        clicks = 0;
        decreasing = false;
        CancelInvoke("ReducePlayerHealth");
    }

    public void Deactivate()
    {
        dirtyWindow.SetActive(false);
        taskUI.SetActive(false);
        active = false;
        CancelInvoke("ReducePlayerHealth");
    }

    public bool isActive()
    {
        return active;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && active)
        {
            inRadius = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && active)
        {
            inRadius = false;
        }
    }

    private void IncreaseTransparency()
    {
        var renderer = dirtyWindow.GetComponent<Renderer>();
        Color color = renderer.material.color;
        color.a += 1f / 30f;
        renderer.material.color = color;
    }

    public void ReducePlayerHealth()
    {
        player.ReduceHealth(1);
    }

    public bool IsActive()
    {
        throw new System.NotImplementedException();
    }
}