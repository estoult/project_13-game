using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiAtackIndicator : MonoBehaviour
{
    
    public Slider uiAttackIndicator;
    public Coroutine currentRoutine;

    public void ResetAttackIndicator()
    {
        uiAttackIndicator.value = 0;
        uiAttackIndicator.maxValue = 100;
        uiAttackIndicator.direction = Slider.Direction.LeftToRight;
    }

    public void StartIndicator(float duration,Action onComplete)
    {
        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
        }

        currentRoutine = StartCoroutine(IndicatorRoutine(duration, onComplete));
    }
    
    public void StopIndicator()
    {
        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
        }
        currentRoutine = null;

        if (uiAttackIndicator != null)
        {
            uiAttackIndicator.value = 0f;
        }
    }
    
    private IEnumerator IndicatorRoutine(float duration, Action onComplete)
    {
        float timer = 0f;
        uiAttackIndicator.maxValue = duration;
        uiAttackIndicator.value = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            uiAttackIndicator.value = timer;
            yield return null;
        }
        onComplete?.Invoke();
    }
    
}
