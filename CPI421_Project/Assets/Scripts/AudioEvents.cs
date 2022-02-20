using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvents : MonoBehaviour
{
    public delegate void MusicEvent();

    public static Transform[] triggers;
    private static MusicEvent[] events;

    public bool toggleboi;
    private bool oldToggleboi;
    public GameObject keyboi;
    
    // needs to be awake instead of start so that it triggers before OnEnable events in other scripts
    void Awake() {
        // get children of triggerparent
        triggers = gameObject.GetComponentsInChildren<Transform>();     // get the music keys (this script is placed on the parent of the set of keys)
        events = new MusicEvent[triggers.Length];                       // create corresponding events

        oldToggleboi = toggleboi;   // ignore this
    }

    // TEMP
    // this is an example of how an event will be called, it will not be in the final version
    void Update() {
        if (toggleboi != oldToggleboi) {    // ignore this

            ref var temp = ref AudioEvents.EventLookup(keyboi);     // access the event via the game object key
            if (temp != null) {                                     // ensure that something is subscribed to this event
                temp();                                             // trigger the event
            }
        }
        oldToggleboi = toggleboi;   // ignore this
    }

    // returns the event (for subscription and triggering purposes) of a corresponding key (empty game object)
    public static ref MusicEvent EventLookup(GameObject key) {
        
        for (int i = 0; i < triggers.Length; i++) {
            if (key == triggers[i].gameObject) {
                return ref events[i];
            }
        }
        return ref events[0];   // should probably set this to some kind of null reference instead
    }
}
