using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    [SerializeField] GameObject EnemiesNearbyMusicKey;
    [SerializeField] GameObject CombatMusicKey;
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

    void DefaultMusic() {
        EnemiesNearbyMusic();
        CombatMusic();
    }
    void EnemiesNearbyMusic() {
        AudioEvents.TriggerEvent(EnemiesNearbyMusicKey);
        Debug.Log("Enemies Nearby");
    }
    void CombatMusic() {
        AudioEvents.TriggerEvent(CombatMusicKey);
        Debug.Log("Combat");
    }
}
