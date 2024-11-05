using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");

        if(!PlayerPrefs.HasKey("scoreFirstTime") || PlayerPrefs.GetInt("scoreFirstTime") != 1)
        {
            PlayerPrefs.SetInt("scoreFirstTime", 1);
            PlayerPrefs.SetInt("hs", 0);
            PlayerPrefs.SetInt("coinCount", 0);
            PlayerPrefs.Save();
        }
    }
}
