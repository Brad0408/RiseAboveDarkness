using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    //Script to casue screen shake
    public IEnumerator Shake(float duration, float magnitude)

    { 
        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0.0f;

        //Effect the screen
        while (elapsed < duration) 
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            //Make the screen shake
            transform.localPosition = new Vector3 (x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        //Set back to normal
        transform.localPosition = originalPosition;

    }
}
