using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateColour : MonoBehaviour
{
    
    Material myMaterial;

    public Color originalColor;

    public bool testAnimation;

    public float t = 0;


    void Start()
    {
        myMaterial = gameObject.GetComponent<Renderer>().material;
        originalColor = myMaterial.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (testAnimation)
        {
            testAnimation = false;
            HitTriggered();

        } 

        if (t > 0)
        {
            myMaterial.color = Color.Lerp(originalColor, Color.white, t);
            t -= Time.deltaTime * 2;
            
        } else if (t <= 0)
        {
            myMaterial.color = originalColor;
        }


    }


    // This function resets the color lerp timer variable t to maximum value 1 
    public void HitTriggered()
    {
        t = 1;
    }

}
