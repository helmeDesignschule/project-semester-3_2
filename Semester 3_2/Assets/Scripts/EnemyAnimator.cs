using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private GameObject targetingVisuals;
    [SerializeField] private Animator animator;

    private Vector3 lastPosition;

    private void Awake()
    {
        lastPosition = transform.position;
    }

    private void LateUpdate()
    {
        Vector3 movement = transform.position - lastPosition;

        if (movement.magnitude > 0)
        {
            movement.Normalize();
            animator.SetFloat("moveDirectionX", movement.x);
            animator.SetFloat("moveDirectionY", movement.y);
        }

        lastPosition = transform.position;
    }

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
