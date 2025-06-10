using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float Max_Health;
    public Slider Ui_Atack_Indicator;
    public float Attack_Damage;
    
    private float _Current_Health;
    private float _Min_Delay = 2f;
    private float _Max_Delay = 5f;
    private PlayerHealth _Player_Health;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StartCoroutine(AttackLoop());
    }

    private void OnEnable()
    {
        _Current_Health = Max_Health;
        _Player_Health = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>(); 
    }
    

    public void OnTakeDamage(float Dmg)
    {
        _Current_Health -= Dmg;
        if (_Current_Health <= 0)
        {
            OnDeath();
        }
        
        Debug.Log("dégâts reçu "+Dmg+" il me reste "+_Current_Health);
    }

    private void OnDeath()
    {
        this.gameObject.SetActive(false);
    }

    
    // Feel clunky need help might be Enumerator problem
    IEnumerator AttackLoop()
    {
        while (true && !_Player_Health.Is_Dead)
        {
            float delay = UnityEngine.Random.Range(_Min_Delay, _Max_Delay);
            if (Ui_Atack_Indicator != null)
            {
                Ui_Atack_Indicator.maxValue = delay;
                Ui_Atack_Indicator.value = 0f;
                yield return null;
            }
            yield return new WaitForSeconds(delay);
            float timer = 0f;
            while (timer < delay)
            {
                timer += Time.deltaTime;

                if (Ui_Atack_Indicator != null)
                {
                    Ui_Atack_Indicator.value = timer;
                }
                
                yield return null; // attendre une frame
            }
            OnAttack();
        }

    }
    
    private void OnAttack()
    {
        // make it attack someone
        _Player_Health.TakeDamage(Attack_Damage);
        Debug.Log("enemy inflige " + Attack_Damage);
    }
}
