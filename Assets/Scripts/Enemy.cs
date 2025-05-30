using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health=0f;
    public float Damage = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void OnTakeDamage(float Dmg)
    {
        Health -= Dmg;
        if (Health <= 0)
        {
            OnDeath();
        }
        
        Debug.Log(Health);
    }

    private void OnDeath()
    {
        this.gameObject.SetActive(false);
    }
}
