using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatsManager : MonoBehaviour
{
    public Image sanityBar;
    public Image hungerBar;

    public float sanity;
    public float hunger;

    [SerializeField] private float currentSanity;
    [SerializeField] private float currentHunger;

    public float sanityDecreaseRate;
    public float hungerDecreaseRate;

    public GameObject player;
    public GameObject deathScreen;

    public bool gameEnd = false;

    void Start()
    {
        Time.timeScale = 1;
        currentSanity = sanity;
        currentHunger = hunger;
    }

    void Update()
    {
        if (gameEnd == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            return;
        } else
        {
            currentSanity -= sanityDecreaseRate * Time.deltaTime;
            currentHunger -= hungerDecreaseRate * Time.deltaTime;
        } 

        currentSanity = Mathf.Clamp(currentSanity, 0, sanity);
        currentHunger = Mathf.Clamp(currentHunger, 0, hunger);

        sanityBar.fillAmount = Mathf.MoveTowards(sanityBar.fillAmount, currentSanity / sanity, Time.deltaTime);
        hungerBar.fillAmount = Mathf.MoveTowards(hungerBar.fillAmount, currentHunger / hunger, Time.deltaTime);

        if (currentHunger == 0 || currentSanity == 0)
        {
            // Player loses - enable death screen, disable movement, redirect to scene manager.
            player.GetComponent<PlayerMovement>().canMove = false;
            deathScreen.SetActive(true);
            gameEnd = true;
            Time.timeScale = 0; 
        }
    }

    public void IncreaseSanity(int amount)
    {
       currentSanity += amount;
    }

    public void IncreaseHunger(int amount)
    {
        currentHunger += amount;
    }
}
