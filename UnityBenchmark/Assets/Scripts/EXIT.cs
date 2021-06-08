﻿using UnityEngine;

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
            if (hit.transform.tag == "ExitButton" && Input.GetMouseButtonDown(0))
            {
                Debug.Log("Goodbye, Cruel World!");

                Application.Quit();
            }

        }
    }


}
