using UnityEngine;
using UnityEngine.InputSystem;



public class TypingManager : MonoBehaviour
{

    public SpellBookManager SpellBookManager;

    
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
                SpellBookManager.DeleteChar();
                break;
            case '\r':
                SpellBookManager.GenerateNewSpell();
                break;
            default:
                SpellBookManager.CheckChar(c);
                break;
        }

    }
    
}


