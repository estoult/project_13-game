using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public bool isDead = false;
    

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health < 0)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        isDead = true;
        this.gameObject.SetActive(false);
        Debug.Log("Combat perdu");
    }
    
    
}
