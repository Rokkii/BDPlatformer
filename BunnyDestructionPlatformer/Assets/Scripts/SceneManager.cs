using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {


    public void LoadScene(int level)
    {
        Application.LoadLevel(level);
        Time.timeScale = 1f;
    }


    /*Quit game script*/
    public void QuitGame()
    {
        Debug.Log("Y U QUIT MY GAME :(");
        Application.Quit(); /*Quit game when called*/
    }


}
