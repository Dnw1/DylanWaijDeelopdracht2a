using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

    public void ReturnButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ControlsButton()
    {
        SceneManager.LoadScene("Controls");
    }
    public void StartButton()
    {
        SceneManager.LoadScene("Game");
    }
}
