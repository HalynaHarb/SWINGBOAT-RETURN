using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SartTutorial : MonoBehaviour
{
   public void Start()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {

        Application.Quit();
    }
}
