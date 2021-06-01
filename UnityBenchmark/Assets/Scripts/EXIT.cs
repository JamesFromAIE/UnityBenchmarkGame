using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXIT : MonoBehaviour
{

    // CLOSE GAME WHEN PLAYER CLICKS OBJECT

    private float rayLength = 2f;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            if (hit.transform.tag == "AdminButton" && Input.GetKey(KeyCode.Mouse0))
            {
                Debug.Log("Goodbye, Cruel World!");

                Application.Quit();
            }

        }
    }


}
