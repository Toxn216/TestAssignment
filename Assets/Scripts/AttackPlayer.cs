using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private KeyCode attackKey = KeyCode.C;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPos;
    [SerializeField] private int damage = 2;

    private void Awake()
    {
        animator = GetComponent<Animator>();   
    }
    void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            animator.SetBool("Attack", true);
            PerformMeleeAttack();
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }

    void PerformMeleeAttack()
    {

        // Проверяем врагов в указанной области
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayer);
        for(int i = 0; i < hitEnemies.Length; i++)
        {
            hitEnemies[i].GetComponent<EnemyHealth>().TakeDamage(damage);
        }

        // Наносим врагу урон
        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(2);
            }            
        }
    }

    // Визуализация области атаки
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
