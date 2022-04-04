using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    [SerializeField] Color color;
    [SerializeField] float fadeTime;
    [SerializeField] float lingerTime;
    private Material material;
    private Color variableColor;
    private float t;
    private bool active;

    void Awake()
    {
        this.material = GetComponent<Renderer>().material;
        variableColor = color;
        t = 0;
        //active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true && t <= 1f) {
            t += Time.deltaTime / fadeTime;
            variableColor = Color.Lerp(Color.black, color, t);
            material.SetColor("_OverlayColor", variableColor);
        }
        else if (active == true) {
            StartCoroutine(Linger());
        }
    }

    // should be called externally to begin the on-hit effect
    public void PlayHitEffect() {
        active = true;
        t = 0;
    }


    IEnumerator Linger() {
        yield return new WaitForSeconds(fadeTime);
        active = false;
        material.SetColor("_OverlayColor", Color.black);
    }
}
