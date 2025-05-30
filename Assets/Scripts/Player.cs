using UnityEngine;

public class Player : MonoBehaviour
{

    private PlayerHealth _playerHealth;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     private void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    public void TakeDamage(float dmg)
    {
        _playerHealth.TakeDamage(dmg);
    }
}
