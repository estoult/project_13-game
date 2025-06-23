using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace Spells
{
    public abstract class Spell : MonoBehaviour
    {
        public float cooldown;
        public string spellname;
        public Sprite icon;
        public bool isCooldownRunning = false;
        public float normalizedtimer = 0f;
        
        private float _timer = 0f;
        private Coroutine _cooldownRoutine;
        public abstract void Cast(Enemy enemy,Player sender);

        public abstract void Innit();



        public void StartCooldown(Action onComplete = null)
        {
            if (!isCooldownRunning)
            {
                _cooldownRoutine = StartCoroutine(Cdloop(cooldown, onComplete));
            }
            else
            {
                Debug.Log($"Problem during coroutine {_cooldownRoutine.ToString()}");
            }
        }
        
        private IEnumerator Cdloop(float duration, Action onComplete)
        {
            isCooldownRunning = true;
            _timer = 0f;
            while (_timer < duration)
            {
                _timer += Time.deltaTime;
                normalizedtimer = _timer / cooldown;
                yield return null;
            }
            isCooldownRunning = false;
            Debug.Log($"I finished my cd {spellname}");
            onComplete?.Invoke();
        } 

    }
}
