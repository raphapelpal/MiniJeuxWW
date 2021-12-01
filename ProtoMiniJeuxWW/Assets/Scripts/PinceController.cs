using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PinceController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 joystickInput;
    [SerializeField] private bool canTakeKey = false, hasPinched = false;
    public Sprite neutralPince, readyPince;
    [SerializeField] private SpriteRenderer thisSpriteRenderer;
    [SerializeField] private Animator phatassAnimator;
    
    void FixedUpdate()
    {
        joystickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        transform.position += new Vector3(joystickInput.x, -joystickInput.y, 0) * speed * Time.fixedDeltaTime;
        
        if (Input.GetButton("AButton") && canTakeKey && !hasPinched)
        {
            phatassAnimator.SetTrigger("SnipTheKey");
            thisSpriteRenderer.enabled = false;
            hasPinched = true;
        }
        else if (Input.GetButton("AButton") && !canTakeKey && !hasPinched)
        {
            phatassAnimator.SetTrigger("OhYeahPinchIt");
            thisSpriteRenderer.enabled = false;
            hasPinched = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("clef"))
        {
            canTakeKey = true;
            thisSpriteRenderer.sprite = readyPince;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("clef"))
        {
            canTakeKey = false;
            thisSpriteRenderer.sprite = neutralPince;
        }
    }
}
