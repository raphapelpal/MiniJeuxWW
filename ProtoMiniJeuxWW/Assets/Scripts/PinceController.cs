using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PinceController : MonoBehaviour
{   
    [SerializeField] private float speed = 5f;
    private Vector2 joystickInput;
    [SerializeField] private bool canTakeKey = false, hasPinched = false;
    public Sprite neutralPince, readyPince;
    [SerializeField] private SpriteRenderer thisSpriteRenderer;
    [SerializeField] private PlayableDirector soundDirector;
    [SerializeField] private Animator phatassAnimator;
    // Fail Audio Clips
    [SerializeField] AudioClip screamingSquirel, wilhelmScream, jojoReference;
    // Success Audio Clips
    [SerializeField] AudioClip  gtaMissionPassed, gotchaBitch;
    AudioSource ahhhhSource;
    
    void FixedUpdate()
    {
        joystickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        ahhhhSource = GetComponent<AudioSource>();
        transform.position += new Vector3(joystickInput.x, -joystickInput.y, 0) * speed * Time.fixedDeltaTime;
        
        if (Input.GetButton("AButton") && canTakeKey && !hasPinched)
        {
            int randomValue = UnityEngine.Random.Range(1, 3);
            if (randomValue == 1)
            {
                phatassAnimator.SetTrigger("RespecMaDude");
                ahhhhSource.clip = gtaMissionPassed;
                
            }
            else if (randomValue == 2)
            {
                phatassAnimator.SetTrigger("SnipTheKey");
                ahhhhSource.clip = gotchaBitch;
            }
            Debug.Log(randomValue);

            ahhhhSource.Play();

            thisSpriteRenderer.enabled = false;
            hasPinched = true;
            soundDirector.enabled = false;
        }
        else if (Input.GetButton("AButton") && !canTakeKey && !hasPinched)
        {

            int randomValue = UnityEngine.Random.Range(1, 4);
            if(randomValue == 1)
            {
                phatassAnimator.SetTrigger("OhYeahPinchIt");
                ahhhhSource.clip = screamingSquirel;
            }            
            else if(randomValue == 2)
            {
                phatassAnimator.SetTrigger("OhYeahPinchIt");
                ahhhhSource.clip = wilhelmScream;
            }
            
            else if(randomValue == 3)
            {
                phatassAnimator.SetTrigger("ToBeContinued");
                ahhhhSource.clip = jojoReference;
            }
            Debug.Log(randomValue);
            
            ahhhhSource.Play();
            thisSpriteRenderer.enabled = false;
            hasPinched = true;
            soundDirector.enabled = false;
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
