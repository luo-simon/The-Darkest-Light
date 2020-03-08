using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatItem : MonoBehaviour
{
    public int hungerValue;
    public int sanityValue;
    public int scoreValue;

    private Collider2D col;
    private StatsUpdater playerStatsUpdater;

    public Animator anim;

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
            playerStatsUpdater.IncreaseSanity(sanityValue);
            GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().IncreaseScore(scoreValue);
            anim.enabled = true;
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

    void Destroy()
    {
        Destroy(gameObject);
    }
}
