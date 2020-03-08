using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsUpdater : MonoBehaviour
{
    public StatsManager statsManager;

    public void IncreaseHunger(int amount)
    {
        statsManager.IncreaseHunger(amount);
    }

    public void IncreaseSanity(int amount)
    {
        statsManager.IncreaseSanity(amount);
    }
}
