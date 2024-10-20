using UnityEngine;
using TMPro;

public class Screen : MonoBehaviour
{
    public Material[] slides; // PNG images
    private int currentSlide = 0;
    private Renderer planeRenderer;

    public float waitTime = 5f; // Time to wait before next click
    private float timer = 0f; // Time remaining for the wait
    private float healthTimer = 0f; // Time in between slide changes
    private bool isClickable = true; // If the plane can be clicked
    public TextMeshProUGUI countdownText; 
    public Player Player;

    void Start()
    {
        planeRenderer = GetComponent<Renderer>();
        planeRenderer.material = slides[currentSlide]; // First slide
        //countdownText.gameObject.SetActive(false); // Initially hide the timer 
    }

    void Update()
    {
        // Measure time since last slide change for health reduction (exclusing exempt slides)
        if (isClickable || currentSlide == 0 || currentSlide == 9 || currentSlide == 18)
        {
            healthTimer += Time.deltaTime;
            if(healthTimer >= 10f) // 10 sec pass without a slide change = health reduction
            {
                Player.ReduceHealth(5f); // Reduce health by 5
                healthTimer = 0f; // Reset health timer
            }
        }
        else
        {
            healthTimer = 0f; //
        }

        // If timer not finished, increment the timer
        if(!isClickable)
        {
            timer += Time.deltaTime;
            int remainingTime = Mathf.CeilToInt(waitTime - timer);
            
            if(remainingTime >= 0)
            {
                countdownText.text = $"Can proceed in {remainingTime:D} seconds";
                countdownText.gameObject.SetActive(true); // Show timer while waiting
            }
            if (remainingTime <= 0)
            {
                isClickable = true; // Allow clicking again after 5 seconds
                timer = 0f; // Reset timer
                //countdownText.gameObject.SetActive(false); // Hide timer when finished
            }
        }
        else {
            // Hide the timer on exempt slides
            if (currentSlide == 0 || currentSlide == 9 || currentSlide == 18)
            {
                //countdownText.gameObject.SetActive(false);
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
            healthTimer = 0f; // Reset health timer on slide change

            // Reset click restriction if moving away from specific slides
            if (currentSlide != 0 && currentSlide != 9 && currentSlide != 18)
            {
                isClickable = false; // Disable clicking until timer expires
            }
        }
    }
}