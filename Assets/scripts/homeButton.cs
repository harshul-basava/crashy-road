using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class homeButton : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
