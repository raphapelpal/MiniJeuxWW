using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContourScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CutterController>())
        {
            other.GetComponent<CutterController>().isLosingQuality = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<CutterController>())
        {
            other.GetComponent<CutterController>().isLosingQuality = true;
        }
    }
}
