using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTrigger : MonoBehaviour
{

    public delegate void Blue();
    public static event Blue ToggleBlue;

    // triggers the toggle event
    void OnTriggerEnter2D(Collider2D collider) {
        if (ToggleBlue != null) {
            ToggleBlue();
        }
    }

    // triggers the toggle event
    void OnTriggerExit2D(Collider2D collider) {
        if (ToggleBlue != null) {
            ToggleBlue();
        }
    }
}
