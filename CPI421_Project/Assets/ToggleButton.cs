using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] bool showOnNextClick;
    [SerializeField] AudioSource openSound;
    [SerializeField] AudioSource closeSound;

    // toggles between setting animator to show menu or to hide menu
    public void ToggleMe() {
        if (showOnNextClick) {
            animator.SetTrigger("Show");
            showOnNextClick = false;
            if (openSound != null) openSound.Play();
        }
        else {
            animator.SetTrigger("hidden");
            showOnNextClick = true;
            if (closeSound != null) closeSound.Play();
        }
    }


    void Update() {

        // allows for closing the menu with the escape key
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!showOnNextClick) {
                showOnNextClick = true;
                if (closeSound != null) closeSound.Play();
            }
        }

        // adds tab in as a hotkey for opening and closing the inventory menu
        if (Input.GetKeyDown(KeyCode.Tab)) {
            ToggleMe();
        }
    }
}
