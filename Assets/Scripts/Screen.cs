using UnityEngine;
using TMPro;

public class Screen : MonoBehaviour
{
    public Material[] slides; // PNG images
    private int currentSlide = 0;
    private Renderer planeRenderer;

    public float waitTime = 5f; // Time to wait before next click
    private float timer = 0f; // Time remaining for the wait
    private bool isClickable = true; // If the plane can be clicked
    public TextMeshProUGUI countdownText; 

    void Start()
    {
        planeRenderer = GetComponent<Renderer>();
        planeRenderer.material = slides[currentSlide]; // first slide
        countdownText.gameObject.SetActive(false); // Initially hide the timer 
    }

    void Update()
    {
        // If timer not finished, increment the timer
        if(!isClickable)
        {
            timer += Time.deltaTime;
            int remainingTime = Mathf.CeilToInt(waitTime - timer);
            
            if(remainingTime >= 0)
            {
                countdownText.text = $"Can proceed in\n{remainingTime:F1} seconds";
                countdownText.gameObject.SetActive(true); // Show timer while waiting
            }
            if (remainingTime <= 0)
            {
                isClickable = true; // Allow clicking again after 5 seconds
                timer = 0f; // Reset timer
                countdownText.gameObject.SetActive(false); // Hide timer when finished
            }
        }
        else {
            // Hide the timer on exempt slides
            if (currentSlide == 0 || currentSlide == 9 || currentSlide == 18)
            {
                countdownText.gameObject.SetActive(false);
            }
        }
    }

    void OnMouseDown()
    {
        // Allow clicking if timer expired OR on exempt slides
        if (isClickable || currentSlide == 0 || currentSlide == 9 || currentSlide == 18)
        {
            currentSlide++;
            if (currentSlide >= slides.Length)
            {
                currentSlide = slides.Length - 1; // Stay on the last slide
            }
            planeRenderer.material = slides[currentSlide]; // Change the material

            // Reset click restriction if moving away from specific slides
            if (currentSlide != 0 && currentSlide != 9 && currentSlide != 18)
            {
                isClickable = false; // Disable clicking until timer expires
            }
        }
    }
}



/*
I have a class called Player that has a ReduceHealth(float amount) method, 
*/