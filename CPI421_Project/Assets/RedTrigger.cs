using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTrigger : MonoBehaviour
{
    public delegate void Red();
    public static event Red ToggleRed;

    // triggers the toggle event
    void OnTriggerEnter2D(Collider2D collider) {
        if (ToggleRed != null) {
            ToggleRed();
        }
    }

    // triggers the toggle event
    void OnTriggerExit2D(Collider2D collider) {
        if (ToggleRed != null) {
            ToggleRed();
        }
    }
}
