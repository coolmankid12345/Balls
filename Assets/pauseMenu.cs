using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public AudioSource BGM;

    public GameObject pauseMenuUI;
    //public Rigidbody2D rb;
    //Move test;

    private void Start()
    {
        //test = GetComponent<Move>();
        Time.timeScale = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.5f;
        GameIsPaused = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    //public void LoadMenu()
    //{
    //    Debug.Log("Loading menu...");
    //}
    public void QuitGame()
    {
        Debug.Log("Quiting game...");
        Application.Quit();
    }

    public void VolumeUp()
    {
        BGM.volume += (float).01;
    }

    public void VolumeDown()
    {
        BGM.volume -= (float).01;
    }

    /*
    public void ResetPos()
    {
        rb.velocity.Set(0, 0);
        rb.position.Set(test.lastPlayerPos.x, test.lastPlayerPos.y);
    }
    */
}
