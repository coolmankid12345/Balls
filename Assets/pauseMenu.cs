using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    //public Rigidbody2D rb;
    //Move test;

    //private void Start()
    //{
    //    test = GetComponent<Move>();
    //}

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
    
    /*
    void Start()
    {
        PausePanel.SetActive(false);
    }
    */

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
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
        
    }

    public void VolumeDown()
    {

    }

    /*
    public void ResetPos()
    {
        rb.velocity.Set(0, 0);
        rb.position.Set(test.lastPlayerPos.x, test.lastPlayerPos.y);
    }
    */
}
