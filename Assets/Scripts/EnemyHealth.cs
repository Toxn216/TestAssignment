using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 4;
    [SerializeField] private GameObject bloodEffect;
    private float deltaY = 1f;
    private KillCounter killCounter;

    private void Start()
    {
        killCounter = GameObject.FindObjectOfType<KillCounter>();

    }
    public void TakeDamage(int damage)
    {

        if (bloodEffect == null)
        {
            Debug.LogError("Blood effect is not assigned!");
            return;
        }
        GameObject bloodEffectInstance = Instantiate(bloodEffect, transform.position, Quaternion.identity);
        ParticleSystem particleSystem = bloodEffectInstance.GetComponent<ParticleSystem>();

        if (particleSystem != null)
        {
            // ”станавливаем новую позицию дл€ системы частиц
            Vector3 newPosition = bloodEffectInstance.transform.position + new Vector3(0, deltaY, 0);
            bloodEffectInstance.transform.position = newPosition;

            health -= damage;
            Debug.Log(health);

            if (health <= 0)
            {
                killCounter.IncreaseKilledEnemies();
                Destroy(gameObject);
            }
        }

    }
}
