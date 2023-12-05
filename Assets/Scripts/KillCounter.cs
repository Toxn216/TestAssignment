using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    private int killedEnemies;

    [SerializeField] private TextMeshProUGUI killsScoreText;
    [SerializeField] private TextMeshProUGUI killsScoreMenuText;

    private void Start()
    {
        killedEnemies = 0;
    }

    public void IncreaseKilledEnemies()
    {
        killedEnemies++;
        killsScoreText.text = "Score: " + killedEnemies;
        killsScoreMenuText.text = "You score: " + killedEnemies;
    }
}
