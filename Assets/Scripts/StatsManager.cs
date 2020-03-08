using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
//using UnityEngine.Rendering.PostProcessing;

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

    public Volume volume;

    public bool gameEnd = false;

    public bool paused = false;
    public GameObject pauseScreen;

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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            if (Input.GetKey(KeyCode.M))
                SceneManager.LoadScene(0);
            return;
        } else
        {
            currentSanity -= sanityDecreaseRate * Time.deltaTime;
            currentHunger -= hungerDecreaseRate * Time.deltaTime;
        }

        CheckPause();

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

        UpdatePostprocessing();
        
    }

    public void IncreaseSanity(int amount)
    {
       currentSanity += amount;
    }

    public void IncreaseHunger(int amount)
    {
        currentHunger += amount;
    }

    private void UpdatePostprocessing()
    {
        volume.profile.TryGet<ColorAdjustments>(out ColorAdjustments colorAdjustments);
        float huevalue = Mathf.Clamp(180 - ((currentSanity / sanity) * 360), 0, 180);
        colorAdjustments.hueShift.value = Mathf.MoveTowards(colorAdjustments.hueShift.value, huevalue, Time.deltaTime * 500);

        volume.profile.TryGet<FilmGrain>(out FilmGrain filmGrain);
        filmGrain.intensity.value = Mathf.MoveTowards(filmGrain.intensity.value, (float)1 - ((currentSanity / sanity) * (float)0.8), Time.deltaTime * 250);

        volume.profile.TryGet<ChromaticAberration>(out ChromaticAberration chromaticAberration);
        float value = Mathf.Clamp01((0.5f - (currentSanity / sanity) * 0.8f));
        chromaticAberration.intensity.value = Mathf.MoveTowards(filmGrain.intensity.value, value, 5);
    }

    private void CheckPause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (paused)
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 1f;
                paused = false;
                
            } else
            {
                pauseScreen.SetActive(true);
                Time.timeScale = 0f;
                paused = true;
            }
        }
    }
}