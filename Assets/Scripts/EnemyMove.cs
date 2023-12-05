using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

public class EnemyMove : MonoBehaviour
{
    private static string ATTACK = "Attack"; 
    private static string WALK = "Walk";

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float currentSpeed;
    [SerializeField] private Transform player;

    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 directionToPlayer = player.position - transform.position;
            directionToPlayer.Normalize();         

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // ���� ���������� �� ������ ������ ������������� ��������, �������� �����
            if (distanceToPlayer < 2.5f)
            {
                animator.SetTrigger(ATTACK);
            }
            else
            {
                // ���������� NPC � ����������� ������, ���� ���������� ���������� �������
                transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime);
                animator.SetTrigger(WALK);
                if (player.position.x > transform.position.x)
                {
                    //������� ������ ����� 
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                }
                else
                {
                    //������� ������ ����� 
                    transform.localScale = new Vector3(1f, 1f, 1f);
                }
            }
        }
        else
        {
            Debug.LogWarning("Player object is not assigned to the NPC controller!");
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        PlayerManager playerManager = other.gameObject.GetComponent<PlayerManager>();

        if (playerManager != null)
        {
            playerManager.ChangeHealth(-2);
            //Debug.Log(player.health + "/" + player.healthMax);
        }
    }
}
