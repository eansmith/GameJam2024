using UnityEngine;

public class Screen : MonoBehaviour
{
    public Material[] slides; // Array of materials with your PNG images
    private int currentSlide = 0;
    private Renderer planeRenderer;

    void Start()
    {
        planeRenderer = GetComponent<Renderer>();
        planeRenderer.material = slides[currentSlide]; // Set the first slide
    }

    void Update()
    {
        // On left mouse click, go to the next slide
        if (Input.GetMouseButtonDown(0))
        {
            currentSlide++;
            if (currentSlide >= slides.Length)
            {
                currentSlide = 0; // Loop back to the first slide
            }
            planeRenderer.material = slides[currentSlide]; // Change the material
        }
    }
}
