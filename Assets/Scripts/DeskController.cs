using UnityEngine;

public class DeskController : MonoBehaviour
{
    public Transform chairPoint;
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
            ChildController controller = other.gameObject.GetComponent<ChildController>();
            if (chairPoint.transform == controller.chair.transform)
            {
                controller.SitDown();
            }
        }
    }
}
