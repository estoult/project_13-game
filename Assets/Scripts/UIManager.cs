using System;
using System.Collections.Generic;
using Spells;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private SpellBookManager _spellBookManager;
    public GameObject uiPrefab;
    public List<GameObject> childs;
    public List<GameObject> prefabs;
    
    
    public void InnitUI(List<Spell> spells)
    {
        foreach (var s in spells)
        {
            GameObject tempUI = Instantiate(uiPrefab, this.transform, true);
            childs = GetAllChildren(tempUI);
            foreach (var child in childs)
            {
                if (child.name == "Name")
                {
                    child.GetComponent<TextMeshProUGUI>().SetText(s.spellname);
                }
                if (child.name == "Icon")
                {
                    child.GetComponent<Image>().sprite = s.icon;
                    prefabs = new List<GameObject>(GameObject.FindGameObjectsWithTag("TEST"));
                    child.transform.parent.transform.parent.transform.parent.gameObject.name = s.name; // renaming the prefab parent to the name of the spell

                }
            }
        }
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    public void UpdateSpellUi(List<Spell> spells)
    {
        foreach (var spell in spells)
        {
            foreach (var p in prefabs)
            {
                if (spell.name == p.name)
                {
                    if (spell.isCooldownRunning)
                    {
                        p.GetComponent<LoadingHelper>().SetLoader(spell.normalizedtimer);
                    }
                }

            }

                //Debug.Log(spell.cooldown);
        }
    }
    
    
    List<GameObject> GetAllChildren(GameObject parent)
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in parent.transform)
        {
            children.Add(child.gameObject);
            children.AddRange(GetAllChildren(child.gameObject));
        }
        return children;
    }
}
