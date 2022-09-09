using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private string COLLECTOR_TAG = "Collector";
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag(COLLECTOR_TAG))
            Destroy(col.gameObject);
    }
}
