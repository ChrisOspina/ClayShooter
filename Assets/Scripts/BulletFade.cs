using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1f);
        iTween.FadeTo(gameObject, 0f, 1f);
    }
}
