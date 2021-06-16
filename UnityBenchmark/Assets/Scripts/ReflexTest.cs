using UnityEngine;
using UnityEngine.UI;

public class ReflexTest : MonoBehaviour
{
    // Links Test to Buttons
    public ReflexButtons reflexButtons;

    public GameObject startButton;

    private float rayLength = 4f;

    public int score;

    // Establishes UI elements for result
    public Image reflexMask;
    public Text reflexText;
    private float resultTime = 2f;
    private bool resultShown = false;

    [HideInInspector]
    public bool playing;

    public bool reflexSent = false;

    // Start is called before the first frame update
    void Start()
    {
        playing = reflexButtons.GetComponent<ReflexButtons>().enabled;
        playing = false;

        reflexText.enabled = false;
        reflexMask.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Establishes a temporary Ray pointing out of camera
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Establishes that attached object can be hit by Raycast
        RaycastHit hit;

        // When buttons is pressed
        if (Physics.Raycast(ray, out hit, rayLength) && Input.GetMouseButtonDown(0) && hit.transform.tag == "StartButton" && playing == false)
        {
            playing = true;
            score = 0;
            Debug.Log("PLAYING REFLEX TEST!");
        }
        // What happens when Test ends
        if (reflexButtons.gameTimer <= 0)
        {
            // Stop the game
            playing = false;

            reflexButtons.randomNumber = 0;

            reflexButtons.LitButtons();

            Debug.Log("You pressed the Lit Buttons " + score + " times!");

            reflexSent = true;

            resultShown = true;

            // Resets Timer
            reflexButtons.gameTimer = 10;

            reflexButtons.hasRun = false;

            
        }

        if (resultShown)
        {
            resultTime -= Time.deltaTime;
            reflexText.enabled = true;
            reflexMask.enabled = true;

            if (resultTime <= 0)
            {
                reflexText.enabled = false;
                reflexMask.enabled = false;
                resultTime = 2;
                resultShown = false;
            }
        }

    }
}
