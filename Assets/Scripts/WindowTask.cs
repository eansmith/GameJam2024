using UnityEngine;
using TMPro;

public class WindowTask : MonoBehaviour
{
    public Camera cam;
    public int clicks; // Num clicks to wipe window
    public GameObject taskUI; // UI text that appears when task is active
    public GameObject dirtyWindow;
    public float wipeTimeLimit = 30f; // Time limit for wiping window
    private float healthLossTimer = 0f; // Timer to track health loss
    private bool isTaskActive = false; // If task is active
    public Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        taskUI.SetActive(false); // Start with activation text hidden
        dirtyWindow.SetActive(false); // Start with dirty window hidden
        player = FindFirstObjectByType<Player>(); // Find Player in scene
    }

    void Update()
    {
        if (isTaskActive)
        {
            if (IsPlayerClose())
            {
                taskUI.SetActive(true); // Show activation text

                if (Input.GetKeyDown(KeyCode.C)) // wiping window
                {
                    clicks++;
                    IncreaseTransparency();
                    if (clicks >= 30)
                    {
                        Deactivate(); // Complete task
                    }
                }
            }
            else
            {
                taskUI.SetActive(false); // Hide text if player is not close
            }

            // Manage health loss
            healthLossTimer += Time.deltaTime;
            if (healthLossTimer >= wipeTimeLimit)
            {
                player.ReduceHealth(1f * Time.deltaTime); // Reduce health by 1 per second
            }
        }
    }

    public void Activate()
    {
        isTaskActive = true; // Mark task as active
        dirtyWindow.SetActive(true); // Show dirty window
        clicks = 0; // Reset clicks
        healthLossTimer = 0f; // Reset health loss timer
    }

    public void Deactivate()
    {
        isTaskActive = false; // Mark task as inactive
        dirtyWindow.SetActive(false); // Hide dirty window
        taskUI.SetActive(false); // Hide activation text
    }

    private bool IsPlayerClose()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, GetComponent<SphereCollider>().radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player")) ///////////// Assuming player has the tag "Player"
            {
                return true; // Player close enough
            }
        }
        return false; // Player not close enough
    }

    private void IncreaseTransparency()
    {
        var renderer = dirtyWindow.GetComponent<Renderer>();
        Color color = renderer.material.color;
        color.a += 1f / 30f; // Increase transparency per click (30 total to fully wipe)
        renderer.material.color = color;

        if (color.a > 1f)
        {
            color.a = 1f;
        }
        renderer.material.color = color;
    }
}