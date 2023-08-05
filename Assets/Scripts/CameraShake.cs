using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
using UnityEngine;
using UnityStandardAssets.Utility;

public class CameraShake : MonoBehaviour
{

    public IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0.0f;
        Vector3 originalPos = transform.localPosition;
        SmoothFollow followComponent = Camera.main.GetComponent<SmoothFollow>();
        followComponent.enabled = false;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float z = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = originalPos + new Vector3(x, originalPos.y - followComponent.height, z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        followComponent.enabled = true;

        transform.localPosition = originalPos;
    }
}
