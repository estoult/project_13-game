using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LoadingHelper : MonoBehaviour
{
    public Image radioLoader;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        radioLoader.fillMethod = Image.FillMethod.Radial360;
        radioLoader.fillClockwise = true;
        radioLoader.fillAmount = 1;
        
        // ???? RadioLoader.fillOrigin
    }

    // Update is called once per frame
    void Update()
    {
       /* if (radioLoader.fillAmount>=1)
        {
            Reset();
        }
        else
        {
            timePassed += Time.deltaTime;
            float t = timePassed / spellCd;
            radioLoader.fillAmount = Mathf.Lerp(0f, 1f, t);
        }*/
    }

    public void SetLoader(float f)
    {
        radioLoader.fillAmount = f;
    }
    public void Reset()
    {
        radioLoader.fillAmount = 0f;
        //Debug.Log(this.name +" RESET");
    }
/*
    public void StartCooldown(Action onComplete = null)
    {
        if (!_cooldownRunning)
        {
            _cooldownRoutine = StartCoroutine(Cdloop(spellCd, onComplete));
        }
        else
        {
            Debug.Log($"Problem during coroutine {_cooldownRoutine.ToString()}");
        }
    }
    private IEnumerator Cdloop(float duration, Action onComplete)
    {
        _cooldownRunning = true;
        float timer = 0f;
        radioLoader.fillAmount = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / spellCd;
            radioLoader.fillAmount = Mathf.Lerp(0f, 1f, t);
            yield return null;
        }

        radioLoader.fillAmount = 1f;
        _cooldownRunning = false;
        onComplete?.Invoke();
    } */
}
