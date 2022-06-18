using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;

    public int currentHealth;

    public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //Code de test
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(30);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
