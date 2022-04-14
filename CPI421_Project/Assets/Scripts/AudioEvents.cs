using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvents : MonoBehaviour
{
    public delegate void MusicEvent();

    public static Transform[] triggers;
    private static MusicEvent[] events;
    public static AudioEvents instance;
    
    // needs to be awake instead of start so that it triggers before OnEnable events in other scripts
    void Awake() {
        // get children of triggerparent
        triggers = gameObject.GetComponentsInChildren<Transform>();     // get the music keys (this script is placed on the parent of the set of keys)
        events = new MusicEvent[triggers.Length];                       // create corresponding events

        Debug.Log("events on awake");
        Debug.Log(triggers[0]);
        Debug.Log(triggers);
        Debug.Log(triggers.Length);
    }

    // returns the event (for subscription and triggering purposes) of a corresponding key (empty game object)
    public static ref MusicEvent EventLookup(GameObject key) {
        
        for (int i = 0; i < triggers.Length; i++) {
            if (key == triggers[i].gameObject) {
                return ref events[i];
            }
        }
        Debug.Log("EventLookup Audio Error");
        return ref events[0];   // should probably set this to some kind of null reference instead
    }

    // internally triggers the event using an external key
    public static void TriggerEvent(GameObject key) {
        Debug.Log("Attempting to Trigger Event");
        Debug.Log(key);

        for (int i = 0; i < triggers.Length; i++) {
            Debug.Log("In for loop");
            Debug.Log(triggers[i]);
            Debug.Log(key);
            if (key == triggers[i].gameObject) {
                Debug.Log("Please work");
                Debug.Log(events[i]);
                events[i]();
                return;
            }
        }
        Debug.Log("Event specified does not exist");
    }
}
