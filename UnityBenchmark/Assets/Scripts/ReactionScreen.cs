using UnityEngine;

public class ReactionScreen : MonoBehaviour
{
    // How far until player can no longer reach
    private float rayLength = 6f;
    
    // Times for test
    public float randomTime = 0;
    public float timer = 0;
    public float reactionTime = 0;

    // How many times the player has reacted in ONE 'attempt'
    public int reactionCount;
    // The average of the last three reaction scores
    public float averageReaction = 0;
    // Variables to store reaction times
    public float reaction1 = 0;
    public float reaction2 = 0;
    public float reaction3 = 0;
    // Helps Passive Red Screen run only once each reaction time
    private bool hasRun = false;

    // Checks whether Database received updated score or not
    public bool reactionSent = false;

    public bool reacting;

    

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            PassiveColours();

            TriggeredColours();
    }

    // What happens while colours are present
    void PassiveColours()
    {
        // What happens when Red is first shown
        if (gameObject.GetComponent<Renderer>().material.color == Color.red)
        {
            if (hasRun == false)
            {
                Debug.Log("PLAYING REFLEX TEST!");
                randomTime = Random.Range(1.0f, 7.0f);
                hasRun = true;
            }
            timer += Time.deltaTime;
        }

        // If Red and timer >= randomTime, Turn Green
        if (gameObject.GetComponent<Renderer>().material.color == Color.red && timer >= randomTime)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 0);
            timer = 0;
        }
        // If Green, start reaction timer
        if (gameObject.GetComponent<Renderer>().material.color == Color.green)
        {
            reactionTime += Time.deltaTime;
        }
    }

    // What happens when colours are triggered
    void TriggeredColours()
    {

        // Establishes a temporary Ray pointing out of camera
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Establishes that attached object can be hit by Raycast
        RaycastHit hit;

        // When screen gets clicked by player
        if (Physics.Raycast(ray, out hit, rayLength) && hit.transform.tag == "ReactionScreen")
        {

            if (Input.GetMouseButtonDown(0))
            {
                // If Cyan, Turn Red
                if (gameObject.GetComponent<Renderer>().material.color == Color.cyan)
                {
                    gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0);
                }
                // If Green, Turn Cyan and find reaction time
                else if (gameObject.GetComponent<Renderer>().material.color == Color.green)
                {
                    gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 1);
                    hasRun = false;
                    Debug.Log("Your reaction time was " + reactionTime + " seconds!");
                    ReactionTimes();
                    reactionTime = 0;
                    reactionCount++;
                    if (reactionCount == 3)
                    {
                        reacting = false;
                        AverageTime();
                        reactionCount = 0;
                    }
                }
                // If Red, Turn Cyan and inform player they clicked too early
                else if (gameObject.GetComponent<Renderer>().material.color == Color.red)
                {
                    gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 1);
                    timer = 0;
                    Debug.Log("You clicked TOO EARLY!");
                    hasRun = false;
                }
            }

        }
    }

    // Stores Prior reaction time values (up to 3 currently)
    void ReactionTimes()
    {
        if (reaction1 == 0)
        {
            reaction1 = reactionTime;
        }
        else if (reaction2 == 0)
        {
            reaction2 = reactionTime;
        }
        else if (reaction3 == 0)
        {
            reaction3 = reactionTime;
        }
    }
    // Calculates and Prints Average Reaction Time
    void AverageTime()
    {
        // Finds average
        averageReaction = (reaction1 + reaction2 + reaction3) / reactionCount;
        // Puts value into 3 decimal place
        averageReaction = (Mathf.Round(averageReaction * 1000) / 1000);

        // Linked to Function in Database --> Update()
        

        Debug.Log("Your average reaction time is " + averageReaction + " seconds!");

        reactionSent = true;


        // Resets values in script
        reaction1 = 0;
        reaction2 = 0;
        reaction3 = 0;
        
    }

}
