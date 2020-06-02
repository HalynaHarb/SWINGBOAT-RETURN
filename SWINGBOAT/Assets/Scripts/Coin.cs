using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public bool trigger = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (trigger == false)
            {
                FindObjectOfType<Audiio>().Play("Coin");
                ScoreManager.instance.ChangeScore(coinValue);
            }
        }
    }
}
