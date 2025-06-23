using UnityEngine;

namespace Spells
{
    [CreateAssetMenu(fileName = "NewSpell", menuName = "Spell Data")]
    public class SpellDataSO : ScriptableObject
    {
        public string spellName = "PlaceHolder";
        [Tooltip("Sprite utilisé comme icône du sort")]
        public Sprite icon;
        [TextArea]
        public string description;
        public AnimationClip animation;
        public int damage;
        public int healing;
        public GameObject effectPrefab;
        public float cooldown = 3f;
    }
}