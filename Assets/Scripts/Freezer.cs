using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezer : MonoBehaviour
{
    public float duration = 5f;
    bool isFrozen = false;
    void Update()
    {
        if(pendingFreezeDuration>0 && !isFrozen)
        {
            StartCoroutine(DoFreeze());
        }
    }
    float pendingFreezeDuration = 0f;
    public void Freeze()
    {
        pendingFreezeDuration = duration;
    }
    IEnumerator DoFreeze()
    {
        isFrozen = true;
        var orginal = Time.timeScale;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = orginal;
        pendingFreezeDuration = 0;
        isFrozen = false;
    }
}
