using UnityEngine;

public class ChildTrigger : MonoBehaviour
{
    public Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Child")
        {
            InvokeRepeating("ReducePlayerHealth", 1f, 1f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Child")
        {
            CancelInvoke("ReducePlayerHealth");
        }
    }

    public void ReducePlayerHealth()
    {
        player.ReduceHealth(0.1f);
        Debug.Log(player.GetHealth());
    }
}
