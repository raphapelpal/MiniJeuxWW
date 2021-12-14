using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerScript : MonoBehaviour
{
    [SerializeField] private CutterController cutterController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CornerBill"))
        {
            cutterController.cornersReached++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("CornerBill"))
        {
            cutterController.cornersReached--;
        }
    }
}
