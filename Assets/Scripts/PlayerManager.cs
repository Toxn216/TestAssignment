using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool isInvincible;
    [SerializeField] private float timeInvincible = 2.0f;
    [SerializeField] private float invincibleTimer;
    public int health { get { return currentHealth; } }
    [SerializeField] private int currentHealth;
    public int healthMax { get { return maxHealth; } }
    [SerializeField] private int maxHealth = 30;
    public bool isGameActive = true;
    public GameObject menuUI;

    private void Awake()
    {
        Hide();
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        if(isGameActive == false)
        {
            Show();
        }
    }
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            isInvincible = true;
            invincibleTimer = timeInvincible;

        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);//Гаранти того что здоровье не будет выше макс хелтх и не ниже нуля
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
        if (currentHealth <= 0)
        {
            isGameActive = false;
        }
    }
    private void Hide()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Show()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
