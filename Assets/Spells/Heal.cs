using System;
using UnityEngine;

namespace Spells
{
    public class Heal: Spell
    {
        public override void Cast(Enemy enemy,Player sender)
        {
            throw new System.NotImplementedException();
        }

        public override void Innit()
        {
            spellname = "HEALIRINO";
            cooldown = 5f;
            isCooldownRunning = false;
        }

        public void Start()
        {
            Innit();
        }
    }
}