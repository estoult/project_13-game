using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadingHelper : MonoBehaviour
{
    public Image RadioLoader;
    public float SpellCd;
    public float timePassed = 0;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RadioLoader.fillMethod = Image.FillMethod.Radial360;
        RadioLoader.fillClockwise = true;
        RadioLoader.fillAmount = 0;
        SpellCd = UnityEngine.Random.Range(2f, 10f);
        // ???? RadioLoader.fillOrigin
    }

    // Update is called once per frame
    void Update()
    {
        if (RadioLoader.fillAmount>=1)
        {
            Reset();
        }
        else
        {
            timePassed += Time.deltaTime;
            float t = timePassed / SpellCd;
            RadioLoader.fillAmount = Mathf.Lerp(0f, 1f, t);
        }
    }

    private void Reset()
    {
        timePassed = 0f;
        RadioLoader.fillAmount = 0f;
        //Debug.Log(this.name +" RESET");
    }
}
