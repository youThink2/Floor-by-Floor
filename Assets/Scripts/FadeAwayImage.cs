using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FadeAwayImage : MonoBehaviour
{
    public float fadeTime;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if(fadeTime > 0)
        {
            //Image
            fadeTime -= Time.deltaTime;
            image.color = new Color(image.color.r, image.color.g, image.color.b, fadeTime);
        }
    }
}
