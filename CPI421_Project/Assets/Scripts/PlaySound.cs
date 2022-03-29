using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] AudioSource sound;

    public void PlayGivenSound() {
        sound.Play(0);
    }
}
