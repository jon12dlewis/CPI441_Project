using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTesting : MonoBehaviour
{
    [SerializeField] bool nearby;
    [SerializeField] bool combat;

    bool oldNearby;
    bool oldCombat;

    void Start() {
        nearby = true;
        oldNearby = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (nearby != oldNearby) {
            EnemiesNearbyMusic();
        }
        oldNearby = nearby;

        if (combat != oldCombat) {
            CombatMusic();
        }
        oldCombat = combat;
    }

    // toggles on Enemies nearby music
    void EnemiesNearbyMusic() {
        AudioEvents_V2.EnemiesNearby();
    }

    // toggles on Enemies nearby music
    void CombatMusic() {
        AudioEvents_V2.InCombat();
    }
}
