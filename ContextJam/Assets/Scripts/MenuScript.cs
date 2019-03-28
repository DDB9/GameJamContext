using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject iMenu;
    public Button instructButton;

    bool instIsOpen;

    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void Play()
    {
        SceneManager.LoadScene("Farm");
    }

    public void Instructions()
    {
        if (!instIsOpen)
        {
            Text buttonText = instructButton.transform.GetChild(0).GetComponent<Text>();

            iMenu.SetActive(true);
            instIsOpen = true;
            Debug.Log(instIsOpen);

            buttonText.text = "BACK";
        }

        else if (instIsOpen)
        {
            Text buttonText = instructButton.transform.GetChild(0).GetComponent<Text>();

            iMenu.SetActive(false);
            instIsOpen = false;

            buttonText.text = "INSTRUCTIONS";
        }
    }
}
