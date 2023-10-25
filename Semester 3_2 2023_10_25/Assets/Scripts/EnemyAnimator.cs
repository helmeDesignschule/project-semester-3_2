using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private GameObject targetingVisuals;
    
    public void PlayTargetingAnimation(float duration)
    {
        StartCoroutine(PlayTargetingAnimationCoroutine(duration));
    }

    private IEnumerator PlayTargetingAnimationCoroutine(float duration)
    {
        targetingVisuals.SetActive(true);
        targetingVisuals.transform.localScale = Vector3.zero;

        float timePassed = 0;
        while (timePassed < duration)
        {
            yield return null;
            timePassed += Time.deltaTime;
            float alpha = timePassed / duration;

            targetingVisuals.transform.localScale = new Vector3(alpha, alpha, alpha);
        }
        targetingVisuals.SetActive(false);
    }
}
