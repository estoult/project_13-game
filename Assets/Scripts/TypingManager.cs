using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


public class TypingManager : MonoBehaviour
{

    public SpellBookManager spellBookManager;

    
    //Sub to event on enable 
    private void OnEnable()
    {
        if (Keyboard.current != null)
        {
            Keyboard.current.onTextInput += OnTextInput;
        }
    }
    //Unsub to event on enable 
    private void OnDisable()
    {
        if (Keyboard.current != null)
        {
            Keyboard.current.onTextInput -= OnTextInput;
        }
            
    }

    private void OnTextInput(char c)
    {
        //Debug.Log(c);
        switch (c)
        {
            case '\b':
                spellBookManager.DeleteChar();
                break;
            case '\r':
                spellBookManager.GenerateNewSpell();
                break;
            default:
                spellBookManager.CheckChar(c);
                break;
        }

    }
    
}


