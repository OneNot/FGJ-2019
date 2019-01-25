using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Script : MonoBehaviour {

    public GameObject menuController;
    public string parameter;

	// Use this for initialization
	void Start () {
		if(menuController == null)
        {
            menuController = GameObject.Find("MenuController");
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenCanvas(string _parameter)
    {
        _parameter = parameter;
        menuController.GetComponent<MenuController>().OpenCanvas(_parameter);
    }

    public void LoadLevel(string _parameter = "")
    {
        _parameter = parameter;

        menuController.GetComponent<MenuController>().inMainMenu = false;

        if (_parameter != "")
            SceneManager.LoadScene(_parameter);
        else
            SceneManager.LoadScene(1);

        menuController.GetComponent<MenuController>().ResumeGame();
    }

    public void LoadNextLevel()
    {
        menuController.GetComponent<MenuController>().inMainMenu = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        menuController.GetComponent<MenuController>().ResumeGame();
    }

    public void ExitGame() { Application.Quit(); }

    public void ResumeGame() { menuController.GetComponent<MenuController>().ResumeGame(); }

    public void PauseGame() { menuController.GetComponent<MenuController>().PauseGame(); }

    public void ReturnToMainMenu() { menuController.GetComponent<MenuController>().ReturnToMainMenu(); }
}
