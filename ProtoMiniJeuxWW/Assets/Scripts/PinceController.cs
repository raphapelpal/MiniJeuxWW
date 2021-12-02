using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinceController : MonoBehaviour
{   
    [SerializeField] private float speed = 5f;
    private Vector2 joystickInput;
    [SerializeField] private bool canTakeKey = false, hasPinched = false;
    public Sprite neutralPince, readyPince;
    [SerializeField] private SpriteRenderer thisSpriteRenderer;
    [SerializeField] private Animator phatassAnimator;
    // Fail Audio Clips
    [SerializeField] AudioClip screamingSquirel, screamingMan, wilhelmScream;
    // Success Audio Clips
    [SerializeField] AudioClip  gtaMissionPassed, gotchaBitch, jojoYareYare;
    AudioSource ahhhhSource;
    
    void FixedUpdate()
    {
        joystickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        ahhhhSource = GetComponent<AudioSource>();
        transform.position += new Vector3(joystickInput.x, -joystickInput.y, 0) * speed * Time.fixedDeltaTime;
        
        if (Input.GetButton("AButton") && canTakeKey && !hasPinched)
        {
            phatassAnimator.SetTrigger("SnipTheKey");
            int randomValue = UnityEngine.Random.Range(1, 4);
            if (randomValue == 1)
            {
                ahhhhSource.clip = gtaMissionPassed;
            }
            else if (randomValue == 2)
            {
                ahhhhSource.clip = gotchaBitch;
            }
            else if (randomValue == 3)
            {
                ahhhhSource.clip = jojoYareYare;
            }

            ahhhhSource.Play();

            thisSpriteRenderer.enabled = false;
            hasPinched = true;
        }
        else if (Input.GetButton("AButton") && !canTakeKey && !hasPinched)
        {
            phatassAnimator.SetTrigger("OhYeahPinchIt");
            int randomValue = UnityEngine.Random.Range(1, 4);
            if(randomValue == 1)
            {
                ahhhhSource.clip = screamingSquirel;
            }            
            else if(randomValue == 2)
            {
                ahhhhSource.clip = screamingMan;
            }
            else if(randomValue == 3)
            {
                ahhhhSource.clip = wilhelmScream;
            }

            ahhhhSource.Play();
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
