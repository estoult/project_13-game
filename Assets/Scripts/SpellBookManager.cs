using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpellBookManager : MonoBehaviour
{
    
    public TMP_Text uiSpell;
    public AudioSource audioSource;
    public AudioClip soundSucess;
    public AudioClip soundFail;
    public AudioClip soundCast;
    
    private readonly List<string> _spellsWording = new() {"FEUER","BLASTO","KOTORO","PROTECTIO" };
    private readonly List<SpellLetter> _currentSpell = new ();
    private int _spellIndex = 0;
    private float _score = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
       GenerateNewSpell();
    }
    
    public void GenerateNewSpell()
    {
        _score = CalculateScore(_currentSpell);
        _currentSpell.Clear();
        var word = _spellsWording[Random.Range(0, _spellsWording.Count)];
        foreach (var c in word)
        {
            _currentSpell.Add(new SpellLetter(c));
        }

        _spellIndex = 0;
        UpdateDisplay();
    }
    
    public void CheckChar(char c)
    {
        if (_spellIndex >= _currentSpell.Count)
        {
            GenerateNewSpell();
            return;
        }
        
        if (
            Char.ToUpper(c) == _currentSpell[_spellIndex].Character)
        {
            var letter = _currentSpell[_spellIndex];
            letter.State = LetterState.Correct;
            _currentSpell[_spellIndex] = letter;
            audioSource.PlayOneShot(soundSucess);
        }
        else
        {
            SpellLetter letter = _currentSpell[_spellIndex];
            letter.State = LetterState.Incorrect;
            _currentSpell[_spellIndex] = letter;
            audioSource.PlayOneShot(soundSucess);
        }
        _spellIndex++;
        UpdateDisplay();
    }
    
    public void DeleteChar()
    {
        if (_spellIndex > 0)
        {
            _spellIndex--;
            SpellLetter letter = _currentSpell[_spellIndex];
            letter.State = LetterState.None;
            _currentSpell[_spellIndex] = letter;
            UpdateDisplay();
        }
    }
    
    private void UpdateDisplay()
    {
        var result = "";
        foreach (var letter in _currentSpell)
        {
            switch (letter.State)
            {
                case LetterState.Correct:
                    result += TextHelper.Coloring(letter.Character, TextHelper.Color.Green);
                    break;
                case LetterState.Incorrect:
                    result += TextHelper.Coloring(letter.Character, TextHelper.Color.Red);
                    break;
                case LetterState.None:
                    result += TextHelper.Coloring(letter.Character, TextHelper.Color.Grey);
                    break;
                default:
                    result += letter.Character;
                    break;
            }
        }

        uiSpell.SetText(result);
    }

    private float CalculateScore(List<SpellLetter> list)
    {
        var finalScore = list.Where(letter => letter.State == LetterState.Correct)
            .Aggregate(0f, (current, letter) => current + 1);
        Debug.Log("Spell score is: "+(finalScore / _currentSpell.Count) * 100);
        return (finalScore / _currentSpell.Count) * 100;
    }
}
