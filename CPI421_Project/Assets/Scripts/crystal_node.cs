using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystal_node : Fighter
{
    public Sprite Crystal_0;
    public Sprite Crystal_1;
    public Sprite Crystal_2;
    public Sprite Crystal_3;

    [SerializeField] AudioSource breakingSound;
    [SerializeField] AudioSource collectionSound;

    protected virtual void Update()
    {
        switch (hitPoint)
        {
            case 8:
                GetComponent<SpriteRenderer>().sprite = Crystal_0;
              break;
            case 7:
                BreakEffect();
              break;
            case 6:
                GetComponent<SpriteRenderer>().sprite = Crystal_1;
                break;
            case 5:
                BreakEffect();
              break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = Crystal_2;
                break;
            case 3:
                BreakEffect();
              break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = Crystal_3;
                break;
            case 1:
                BreakEffect();
              break;
            case 0:
                Death();
                break;
        }
    }

    // will play a sound effect for breaking into a smaller crystal
    void BreakEffect() {
        breakingSound.Play();
    }

    protected override void Death()
    {
        // this plays in addition to the default death sound
        var temp = Instantiate(deathSoundPrefab);
        temp.gameObject.SendMessage("SetAudioSource", collectionSound);

        Destroy(gameObject);
        GameManager.instance.GiveBlueCrystal(10);
        GameManager.instance.ShowText("Blue Crystal Obtained ", 40, Color.blue, transform.position, Vector3.up * 40, 1.0f);
    }
}
