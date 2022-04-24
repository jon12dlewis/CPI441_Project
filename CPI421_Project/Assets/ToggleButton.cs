using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] bool showOnNextClick;

    // toggles between setting animator to show menu or to hide menu
    public void ToggleMe() {
        if (showOnNextClick) {
            animator.SetTrigger("Show");
            showOnNextClick = false;
        }
        else {
            animator.SetTrigger("hidden");
            showOnNextClick = true;
        }
    }

    // allows for closing the menu with the escape key
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!showOnNextClick) {
                showOnNextClick = true;
            }
        }
    }
}
