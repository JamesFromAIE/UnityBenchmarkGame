using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXIT : MonoBehaviour
{

    // CLOSE GAME WHEN PLAYER CLICKS OBJECT

    // Update is called once per frame
    void Update()
    {
        // Establishes a Raycast from the camera
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Something happens when hit
        RaycastHit hit;
        //print("hello 1");
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            if (hit.transform.position == transform.position)
            {
                Application.Quit();
            }
        }
    }
}
