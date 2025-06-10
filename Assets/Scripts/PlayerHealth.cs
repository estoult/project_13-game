using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 10;
    public bool Is_Dead = false;
    

    public void TakeDamage(float dmg)
    {
        Health = Health - dmg;
        Debug.Log(Health);
        if (Health < 0)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        Is_Dead = true;
        this.gameObject.SetActive(false);
        
        Debug.Log("Combat perdu");
    }
    
    
}
