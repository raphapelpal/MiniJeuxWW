using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollaBillScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CutterController>())
        {
            other.GetComponent<CutterController>().isLosingQuality = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<CutterController>())
        {
            other.GetComponent<CutterController>().isLosingQuality = false;
        }
    }
}
