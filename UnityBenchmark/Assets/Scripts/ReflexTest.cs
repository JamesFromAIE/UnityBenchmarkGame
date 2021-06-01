using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflexTest : MonoBehaviour
{
    private float rayLength = 2f;
    private bool beenClicked = false;

  /*  public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5; */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            if (hit.transform.tag == "ReflexButton" && Input.GetKey(KeyCode.Mouse0) && beenClicked == false)
            {
                beenClicked = true;
                Debug.Log("I have been pressed once!");
            }

        }
    }
}
