using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesManager : MonoBehaviour
{
    public GameObject helpPanel;

    public void ShowHelpPanel()
    {
        helpPanel.SetActive(!helpPanel.activeSelf);
    }

    public void SelectFeeding()
    {
        SceneManager.LoadScene("Feeding");
    }

    public void SelectGatchTheBall()
    {
        SceneManager.LoadScene("GoodBoy");
    }

}
