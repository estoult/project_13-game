using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 50f;
    
    public float attackDamage = 10f;
    
    private float _currentHealth;
    private const float MinDelay = 2f;
    private const float MaxDelay = 5f;
    private Player _player;
    private UiAtackIndicator _uiAtackIndicator;
    private Coroutine _attackLoopRoutine;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _attackLoopRoutine = StartCoroutine(AttackLoop());
    }

    private void OnEnable()
    {
        _currentHealth = maxHealth;
        _uiAtackIndicator = GetComponent<UiAtackIndicator>();
        _player = GameObject.FindWithTag("Player").GetComponent<Player>(); 
    }

    private void OnDisable()
    {
        if (_attackLoopRoutine != null)
            StopCoroutine(_attackLoopRoutine);

        if (_uiAtackIndicator != null)
            _uiAtackIndicator.StopIndicator();
    }

    public void OnTakeDamage(float dmg)
    {
        _currentHealth -= dmg;
        if (_currentHealth <= 0)
        {
            OnDeath();
        }
        Debug.Log($"Damage received { dmg } I still have { _currentHealth } hp");
    }

    private void OnDeath()
    {
        gameObject.SetActive(false);
    }

    
    // Feel clunky need help might be Enumerator problem
    IEnumerator AttackLoop()
    {
        while (_player.isActiveAndEnabled)
        {
            float delay = UnityEngine.Random.Range(MinDelay, MaxDelay);
            bool attackDone = false;
            _uiAtackIndicator.StartIndicator(delay, () =>
            {
                attackDone = true;
                OnAttack();
            });
            // Attendre que l'attaque soit déclenchée via le callback
            yield return new WaitUntil(() => attackDone);
        }

    }
    
    private void OnAttack()
    {
        // make it attack someone
        _player.TakeDamage(attackDamage);
        //_playerHealth.TakeDamage(attackDamage);
        Debug.Log($"Enemy dealt {attackDamage}");
    }
}
