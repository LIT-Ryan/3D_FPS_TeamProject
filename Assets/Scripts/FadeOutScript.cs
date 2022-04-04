using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutScript : MonoBehaviour
{
    //public SpriteRenderer _rend2;
    Image _rend1;
    

    // Start is called before the first frame update
    void Start()
    {
        
        _rend1.GetComponent<SpriteRenderer>();
        
        Color C = _rend1.material.color;
        
        C.a = 0f;
        _rend1.material.color = C;
        

        StartCoroutine(FadeIn());

    }

    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = _rend1.material.color;
            c.a = f;
            _rend1.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }


}