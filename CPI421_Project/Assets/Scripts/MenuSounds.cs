using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{
    [SerializeField] AudioSource menuOpen;
    [SerializeField] AudioSource menuClose;
    [SerializeField] AudioSource buttonClick;
    [SerializeField] AudioSource buttonHover;

    public void MenuOpen() {
        menuOpen.Play();
    }

    public void MenuClose() {
        menuClose.Play();
    }

    public void ButtonClick() {
        buttonClick.Play();
    }
    public void ButtonHover() {
        buttonHover.Play();
    }
}
