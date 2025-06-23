using System;
using UnityEngine;

namespace Spells
{
    public class Fire : Spell
    {
        
        public override void Cast(Enemy enemy,Player sender)
        {
            
            throw new System.NotImplementedException();
        }

        public override void Innit()
        {
            spellname = "FUEUR";
            cooldown = 3f;
            isCooldownRunning = false;
        }

        private void Start()
        {
            Innit();
        }
    }
}