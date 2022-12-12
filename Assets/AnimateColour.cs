using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateColour : MonoBehaviour
{
    
    Material myMaterial;

    public Color originalColor;

    public Color originalEmissionColor;

    public bool testAnimation;

    public float t = 0;


    void Start()
    {
        myMaterial = gameObject.GetComponent<Renderer>().material;
        originalColor = myMaterial.color;

        if (gameObject.tag != "MelodyGem" )
        {
            originalEmissionColor = myMaterial.GetColor("_EmissionColor");
        }
        
        
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
            if (gameObject.tag == "MelodyGem")
            {
                myMaterial.color = Color.Lerp(originalColor, Color.white, t);
            } else
            {
                myMaterial.SetColor("_EmissionColor", Color.Lerp(originalEmissionColor, Color.white, t));
            }
            
            t -= Time.deltaTime * 2;
            
        } else if (t <= 0)
        {
            

            if (gameObject.tag == "MelodyGem")
            {
                myMaterial.color = originalColor;
            } else
            {
                myMaterial.SetColor("_EmissionColor", originalEmissionColor);
            }
            
        }


    }


    // This function resets the color lerp timer variable t to maximum value 1 
    public void HitTriggered()
    {
        t = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag != "MelodyGem")
        {
            HitTriggered();
        }
    }

}
