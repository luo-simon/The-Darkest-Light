using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCampfire : MonoBehaviour
{
    public float range;
    public Transform player;
    public StatsManager statsManager;
    public Score score;


    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < range)
        {
            statsManager.IncreaseHunger(50);
            statsManager.IncreaseSanity(50);
            score.IncreaseScore(-100);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
