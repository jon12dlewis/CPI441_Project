using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitPoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;
    public bool wasHit = false;

    // Immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    // push
    protected Vector3 pushDirection;

    // SFX
    [SerializeField] AudioSource damageSound;
    [SerializeField] AudioSource deathSound;
    [SerializeField] DeathSound deathSoundPrefab;

    // All fighters can recieve damage / die

    protected virtual void RecieveDamage(Damage dmg)
    {
        if(Time.time - lastImmune > immuneTime)
        {
            wasHit = true;
            lastImmune = Time.time;
            hitPoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
            
            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 50, Color.red, transform.position, Vector3.zero, 0.5f);

            if(hitPoint <= 0)
            {
                hitPoint = 0;

                if (deathSound != null) {   // TODO: currently does not play because spider is destroyed instantly on death
                    deathSound.Play(0);
                }
                Death();
            }
        }
    }

    protected virtual void Death()
    {

    }

    void OnDestroy() {
        var temp = Instantiate(deathSoundPrefab);
        temp.gameObject.SendMessage("SetAudioSource", deathSound);
    }
}
