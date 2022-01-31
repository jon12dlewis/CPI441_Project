using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTrigger : MonoBehaviour
{

    public delegate void Green();
    public static event Green ToggleGreen;

    // triggers the toggle event
    void OnTriggerEnter2D(Collider2D collider) {
        if (ToggleGreen != null) {
            ToggleGreen();
        }
        
        Debug.Log("Enter Green");
    }

    // triggers the toggle event
    void OnTriggerExit2D(Collider2D collider) {
        if (ToggleGreen != null) {
            ToggleGreen();
        }
        Debug.Log("Exit Green");
    }
}
