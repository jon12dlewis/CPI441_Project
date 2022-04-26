using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RisingText : MonoBehaviour
{
    [SerializeField] GameObject textContainer;
    [SerializeField] float smoothTime = 1f;

    Text text;
    Vector2 startPos;
    Vector2 endPos;
    Vector2 yVelocity;
    float travelDistance = 150;
    bool traveling;
    Color startColor;
    Color endColor;
    float t;


    // Start is called before the first frame update
    void Start()
    {
        text = textContainer.GetComponent<Text>();
        startPos = text.transform.position;
        endPos = new Vector2(text.transform.position.x, text.transform.position.y + travelDistance);
        yVelocity = Vector2.zero;

        startColor = text.color;
        endColor = new Color(text.color.r, text.color.g, text.color.b, 0);
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (traveling) {
            text.transform.position = Vector2.SmoothDamp(text.transform.position, endPos, ref yVelocity, smoothTime);

            t += Time.deltaTime / smoothTime;
            text.color = Color.Lerp(startColor, endColor, t);

            if (endPos.y - text.transform.position.y < 2f) {
                traveling = false;
                textContainer.SetActive(false);
            } 
        }
    }

    public void SetTravelingTrue() {
        traveling = true;
        text.transform.position = startPos;
        textContainer.SetActive(true);
        text.color = startColor;
        t= 0;
    }
}
