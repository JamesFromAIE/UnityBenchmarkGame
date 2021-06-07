using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflexTest : MonoBehaviour
{
    // Links Test to Buttons
    public ReflexButtons reflexButtons;

    private float rayLength = 4f;

    public int score;

    [HideInInspector]
    public bool playing;

    // Start is called before the first frame update
    void Start()
    {
        playing = reflexButtons.GetComponent<ReflexButtons>().enabled;
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Establishes a temporary Ray pointing out of camera
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Establishes that attached object can be hit by Raycast
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength) && Input.GetKey(KeyCode.Mouse0) && hit.transform.tag == "ReflexButton" && playing == false)
        {
            playing = true;
            
            Debug.Log("PLAYING REFLEX TEST!");
        }
        if (reflexButtons.gameTimer <= 0)
        {
            // What happens when Test ends
            playing = false;
            reflexButtons.randomNumber = 0;
            reflexButtons.LitButtons();
            Debug.Log("You pressed the Lit Buttons " + score + " times!");
            reflexButtons.gameTimer = 5;
            reflexButtons.GetComponent<ReflexButtons>().enabled = false;
        }


    }
}
