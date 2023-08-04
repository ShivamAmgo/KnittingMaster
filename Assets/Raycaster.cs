using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    Validator ActiveItemValidator = null;
    private void Start()
    {
        
    }
    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast and check if it hits any collider
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the object hit has a collider and a tag to confirm it's what we want to detect
                if (hit.collider != null && hit.collider.CompareTag("Item"))
                {
                    Validator VM = hit.transform.GetComponent<Validator>();
                    if (ActiveItemValidator == VM) return;
                    if (ActiveItemValidator == null)
                        ActiveItemValidator = VM;
                    else
                    {
                        VM.Validate(ActiveItemValidator.GetActiveKnitRow());
                    }
                    Debug.Log("Active Validator is " + ActiveItemValidator);
                }
            }
        }
    }
}
