using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    int enemyCount;
    LinkedList<GameObject> combatants;
    enum MusicState {Default, Nearby, Combat};
    MusicState currentMusicState;

    void Awake() {
        currentMusicState = MusicState.Default;
        combatants = new LinkedList<GameObject>();
    }

    void Update() { 

        // only player is remaining
        if (enemyCount == 0) {
            if (currentMusicState != MusicState.Default) {
                DefaultMusic();
            }
            currentMusicState = MusicState.Default;
        }
        // Enemies exist in the level
        else if (combatants.Count == 0) {
            if (currentMusicState != MusicState.Nearby) {
               EnemiesNearbyMusic();
            }
            currentMusicState = MusicState.Nearby;
        }
        // player is in combat with enemy
        else if (combatants.Count > 0) {
            if (currentMusicState != MusicState.Combat) {
                CombatMusic();
            }
            currentMusicState = MusicState.Combat;
        }
    }

    // counting enemies
    public void EnemyEnable() {
        enemyCount++;
    }

    // removing dead enemies from count and combatants list
    public void EnemyDisable(GameObject obj) {
        enemyCount--;
        combatants.Remove(obj);
    }

    // adding units to a list of combatants
    public void InCombat(GameObject obj) {
        foreach(GameObject g in combatants) {
            if (obj == g) {
                return;
            }
        }
        combatants.AddLast(obj);
    }

    // toggles off Enemies Nearby music and Combat Music
    void DefaultMusic() {
        EnemiesNearbyMusic();
        CombatMusic();
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
