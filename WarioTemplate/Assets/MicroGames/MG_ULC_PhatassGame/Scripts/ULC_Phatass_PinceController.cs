using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ULC_Phatass_PinceController : MonoBehaviour, ITickable
{   
    [SerializeField] private float speed = 5f;
    private Vector2 joystickInput;
    [SerializeField] private bool canTakeKey = false, hasPinched = false, bestEnding, canInput;
    public bool phatassSuccess;
    [SerializeField] Sprite neutralPince, readyPince;
    [SerializeField] private SpriteRenderer thisSpriteRenderer;
    [SerializeField] private PlayableDirector soundDirector;
    [SerializeField] private Animator phatassAnimator;
    // Fail Audio Clips
    [SerializeField] AudioClip screamingSquirel, wilhelmScream;
    // Success Audio Clips
    [SerializeField] AudioClip gotchaBitch;
    [SerializeField] private PlayableDirector gtaMissionPassed, jojoReference;
    AudioSource ahhhhSource;


    private void Start()
    {
        canInput = true;
        bestEnding = true;
        ahhhhSource = GetComponent<AudioSource>();
        GameManager.Register(); //Mise en place du Input Manager, du Sound Manager et du Game Controller
        GameController.Init(this); //Permet a ce script d'utiliser le OnTick
    }

    void Update()
    {
        if (canInput)
        {
            //joystickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
             joystickInput = new Vector2(InputManager.GetAxis(ControllerAxis.LEFT_STICK_HORIZONTAL),-InputManager.GetAxis(ControllerAxis.LEFT_STICK_VERTICAL));
        
            transform.position += new Vector3(joystickInput.x, -joystickInput.y, 0) * speed * Time.fixedDeltaTime;
        
            if (InputManager.GetKeyDown(ControllerKey.A) && canTakeKey && !hasPinched) 
            {
                phatassSuccess = true;
                if (bestEnding)
                {
                phatassAnimator.SetTrigger("RespecMaDude");
                gtaMissionPassed.enabled = true;
                //ahhhhSource.clip = gtaMissionPassed;
                //ahhhhSource.Play();
                
                thisSpriteRenderer.enabled = false;
                hasPinched = true;
                soundDirector.enabled = false;
                
                }
                else
                {
                phatassAnimator.SetTrigger("SnipTheKey");
                ahhhhSource.clip = gotchaBitch;
                ahhhhSource.Play();
                thisSpriteRenderer.enabled = false;
                hasPinched = true;
                soundDirector.enabled = false;
                StartCoroutine(HolupALilBit(1.5f));
                } 
            }
        else if (InputManager.GetKeyDown(ControllerKey.A) && !canTakeKey && !hasPinched)
        {
            phatassSuccess = false;
            if (bestEnding)
            {
                phatassAnimator.SetTrigger("ToBeContinued");
                jojoReference.enabled = true;
                //ahhhhSource.clip = jojoReference;
                //ahhhhSource.Play();
                
                thisSpriteRenderer.enabled = false;
                hasPinched = true;
                soundDirector.enabled = false;
            }
            else
            {
                int randomValue = UnityEngine.Random.Range(1, 3);
                if(randomValue == 1)
                {
                    phatassAnimator.SetTrigger("OhYeahPinchIt");
                    ahhhhSource.clip = screamingSquirel;
                    ahhhhSource.Play();
                    thisSpriteRenderer.enabled = false;
                    hasPinched = true;
                    soundDirector.enabled = false;
                    StartCoroutine(HolupALilBit(3f));
                }            
                else if(randomValue == 2)
                {
                    phatassAnimator.SetTrigger("OhYeahPinchIt");
                    ahhhhSource.clip = wilhelmScream;
                    ahhhhSource.Play();
                    thisSpriteRenderer.enabled = false;
                    hasPinched = true;
                    soundDirector.enabled = false;
                    StartCoroutine(HolupALilBit(2f));
                }
            }
        }
        } 
    }

    IEnumerator HolupALilBit(float yieldTime)
    {
        yield return new WaitForSeconds(yieldTime);
        GameController.FinishGame(phatassSuccess);
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
    
    public void OnTick()
    {
        if (GameController.currentTick == 3) //NO MORE LONG ENDINGS
        {
            bestEnding = false;
        }
        
        if (GameController.currentTick == 5) //NO MORE INPUT
        {
            soundDirector.enabled = false;
            canInput = false;
            phatassAnimator.SetTrigger("WalkAway");
            Debug.Log("No more Input");
            // Play ending where the guard walks away
        }

        if (GameController.currentTick == 8) //FINISH GAME
        {
            GameController.FinishGame(phatassSuccess);
        }
    }
}
