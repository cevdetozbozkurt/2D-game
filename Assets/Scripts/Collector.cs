using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private string ENEMY_TAG = "Enemy";
    private string PLAYER_TAG = "Player";
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag(ENEMY_TAG) || col.CompareTag(PLAYER_TAG))
            Destroy(col.gameObject);
    }
}
