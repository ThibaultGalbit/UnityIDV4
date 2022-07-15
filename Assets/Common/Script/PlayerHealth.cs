using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;

    public int currentHealth;

    public HealthBar healthBar;


    [SerializeField]
    private Text _damageText;

    Animator damageAnimator;

    public static PlayerHealth instance;

    // Start is called before the first frame update
    void Start()
    {
        damageAnimator = _damageText.GetComponent<Animator>();
        _damageText.text = "";
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
        _damageText.text = (-damage).ToString();
        damageAnimator.Play("Damage", -1, 0f);

    }

    public void Die()
    {
        Debug.Log("Player est mort");
        GameOverManager.instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        Debug.Log("CAMILO");
        PlayerMovement.instance.enabled = true;
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;

        resetHealth();

        healthBar.SetHealth(currentHealth);

    }

    public void resetHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);

    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }
}
