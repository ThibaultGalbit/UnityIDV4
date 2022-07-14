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
        _damageText.text = (-damage).ToString();
        damageAnimator.Play("Damage", -1, 0f);

    }

    public void resetHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);

    }
}
