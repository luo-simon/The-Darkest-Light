using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerItem : MonoBehaviour
{
    public int hungerValue;

    private Collider2D col;
    private StatsUpdater playerStatsUpdater;

    [SerializeField] private bool inRange = false;

    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (!inRange)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerStatsUpdater.IncreaseHunger(hungerValue);
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            // Player in range to pick up food item (this item)
            inRange = true;
            if (playerStatsUpdater == null)
                playerStatsUpdater = other.GetComponent<StatsUpdater>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player left range
            inRange = false;
        }
    }
}
