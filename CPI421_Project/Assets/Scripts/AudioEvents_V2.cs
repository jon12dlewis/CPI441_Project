using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvents_V2 : MonoBehaviour
{
    public delegate void MusicEvent();

    public static MusicEvent enemiesNearbyEvent;
    public static MusicEvent inCombatEvent;
    public static MusicEvent gamePausedEvent;
    public static MusicEvent gameUnpausedEvent;

    // returns a reference to a music event that can be subscribed to from other functions
    public static ref MusicEvent EventLookup(GameObject key) {
        if (key.gameObject.name == "Nearby Key") {
            return ref enemiesNearbyEvent;
        }
        else if (key.gameObject.name == "Combat Key") {
            return ref inCombatEvent;
        }
        else if (key.gameObject.name == "Paused Key") {
            return ref gamePausedEvent;
        }
        else if (key.gameObject.name == "Unpaused Key") {
            return ref gameUnpausedEvent;
        }

        else {
            Debug.Log("error with event lookup");
            return ref gamePausedEvent; // temp probably
        }
    }

    // triggers the enemies nearby event, all subscribed functions are called
    public static void EnemiesNearby() {
        if (enemiesNearbyEvent != null) enemiesNearbyEvent();
    }

    // triggers the in combat event, all subscribed functions are called
    public static void InCombat() {
        if (inCombatEvent != null) inCombatEvent();
    } 

    // triggers the game paused event, all subscribed functions are called
    public static void GamePaused() {
        if (gamePausedEvent != null) gamePausedEvent();
    }

    public static void GameUnpaused() {
        if (gameUnpausedEvent != null) gameUnpausedEvent();
    }
}
