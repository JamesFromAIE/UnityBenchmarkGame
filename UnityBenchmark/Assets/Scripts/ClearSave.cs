using UnityEngine;

public class ClearSave : MonoBehaviour
{
    private float rayLength = 3f;

    public bool clearReflex;
    public bool clearReaction;
    // Update is called once per frame
    void Update()
    {
        // Establishes a temporary Ray pointing out of camera
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Establishes that attached object can be hit by Raycast
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength) && Input.GetMouseButtonDown(0) && hit.transform.tag == "ClearButton" && clearReflex == false && clearReaction == false)
        {
            clearReflex = true;
            clearReaction = true;
        }
    }
}
