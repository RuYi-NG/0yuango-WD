using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthController : MonoBehaviour
{
    [Header("Player Health Amount")]
    public float currentPlayerHealth = 100.0f;
    [SerializeField] private float maxPlayerHealth = 100.0f;
    [SerializeField] private int regenRate = 3;
    private bool canRegen = false;

    [Header("Hurt Image")]
    [SerializeField] private Image hurtImage = null;

    [Header("Hurt Audio")]
    [SerializeField] private AudioClip hurtAudio = null;
    private AudioSource healthAudioSource;

    [Header("Heal Timer")]
    [SerializeField] private float healCooldown = 3.0f;
    [SerializeField] private float maxHealCooldown = 3.0f;
    [SerializeField] private bool startCooldown = false;

    private void Start()
    {
        healthAudioSource = GetComponent<AudioSource>();
    }
    void UpdateHealth()
    {
        Color hurtAlpha = hurtImage.color;
        hurtAlpha.a = 1 - (currentPlayerHealth / maxPlayerHealth);
        hurtImage.color = hurtAlpha;
    }
    public void TakeDamage()
    {
        if (currentPlayerHealth >= 0)
        {
            canRegen = false;
            UpdateHealth();
            healCooldown = maxHealCooldown;
            startCooldown = true;
        }
    }
    public void Update()
    {
        if (startCooldown)
        {
            healCooldown -= Time.deltaTime;
            if(healCooldown <= 0)
            {
                canRegen = true;
                startCooldown = false;
            }
        }
        if (canRegen)
        {
            if (currentPlayerHealth <= maxPlayerHealth - 0.01)
            {
                currentPlayerHealth += Time.deltaTime * regenRate;
                UpdateHealth();
            }
            else
            {
                currentPlayerHealth = maxPlayerHealth;
                healCooldown = maxHealCooldown;
                canRegen = false;
            }
        }
    }
}

