using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject FinishedLevel;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player")){
            FinishedLevel.SetActive(true);
        }
    }

}
