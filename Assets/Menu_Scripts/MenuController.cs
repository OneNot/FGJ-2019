using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    //Automatically handled lists
    public List<string> canvasList;
    public List<string> hideableButtons;
    public List<GameObject> destroyableObjects;

    //Set this false in code if you want cancel to operate something else than pause. For example close a dialogue box
    public bool cancelAvailable = true;

    public bool gamePaused = true;

    //defaults to Canvas named Settings
    public string canvasToOpenWhenPaused;

    //defaults to Canvas named Mainmenu
    public string mainMenu;

    public bool inMainMenu = true;

    // Use this for initialization
    void Start () {

        

        if (canvasToOpenWhenPaused == "")
            canvasToOpenWhenPaused = "Settings";

        if (mainMenu == "")
            mainMenu = "Mainmenu";

    }
	
	// Update is called once per frame
	void Update () {


        if (gamePaused == false && Input.GetButtonDown("Cancel") && cancelAvailable == true && inMainMenu == false)
            PauseGame();

        else if (gamePaused == true && Input.GetButtonDown("Cancel") && cancelAvailable == true && inMainMenu == false)
            ResumeGame();

    }

   


    public void OpenCanvas(string canvas)
    {
        foreach (string c in canvasList)
        {
            if(c == canvas)
            {
                GameObject.Find(c).GetComponent<Canvas>().enabled = true;
            }

            else
                GameObject.Find(c).GetComponent<Canvas>().enabled = false;
        }

    }

    public void PauseGame(bool normal = true)
    {
        gamePaused = true;

        if (normal)
        {
            foreach (string b in hideableButtons)
            {
                if (GameObject.Find(b).GetComponent<HideWhenPaused>().hideWhenPaused == true)
                    GameObject.Find(b).GetComponent<HideWhenPaused>().NullifyScales();
            }

            foreach (string b in hideableButtons)
            {
                if (GameObject.Find(b).GetComponent<HideWhenPaused>().hideWhenPaused == false)
                    GameObject.Find(b).GetComponent<HideWhenPaused>().SetScales();
            }
        }

        Time.timeScale = 0.00001f;

        if(normal)
        OpenCanvas(canvasToOpenWhenPaused);

      
    }

    public void ResumeGame()
    {
        gamePaused = false;

        foreach (string b in hideableButtons)
        {
            if (GameObject.Find(b).GetComponent<HideWhenPaused>().hideWhenPaused == true)
                GameObject.Find(b).GetComponent<HideWhenPaused>().SetScales();
        }

        foreach (string b in hideableButtons)
        {
            if (GameObject.Find(b).GetComponent<HideWhenPaused>().hideWhenPaused == false)
                GameObject.Find(b).GetComponent<HideWhenPaused>().NullifyScales();
        }

        CloseEveryCanvas();

        Time.timeScale = 1f;

        
    }

    public void CloseEveryCanvas()
    {
        foreach (string c in canvasList)
        {
                GameObject.Find(c).GetComponent<Canvas>().enabled = false;
        }

        inMainMenu = false;
            
    }

    public void ReturnToMainMenu()
    {
        inMainMenu = true;
        PauseGame(false);

        foreach (string b in hideableButtons)
        {
            if (GameObject.Find(b).GetComponent<HideWhenPaused>().hideWhenPaused == true)
                GameObject.Find(b).GetComponent<HideWhenPaused>().SetScales();

            if (GameObject.Find(b).GetComponent<HideWhenPaused>().hideWhenPaused == false)
                GameObject.Find(b).GetComponent<HideWhenPaused>().NullifyScales();
        }

        OpenCanvas(mainMenu);
    }
}
