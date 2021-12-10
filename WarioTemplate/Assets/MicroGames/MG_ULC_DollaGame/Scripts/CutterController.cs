using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutterController : MonoBehaviour, ITickable
{
    private Vector2 joystickInput;
    [SerializeField] private float speed = 5f;
    public bool isLosingQuality = false, hasFinishedGame;
    [SerializeField] private int cutsLeft = 39;
    public float currentQuality, maxQuality;
    private SpriteRenderer cutterSprite;
    private CircleCollider2D cutterCollider;
    [SerializeField] private GameObject contoursEasy, contoursMedium, contoursHard, winScreen, loseScreen, canvasObj;
    public bool isEasy, isMedium, isHard;
    [SerializeField] private RectTransform qualityBarTransform;
    [SerializeField] private Image qualityBarImage;
    [SerializeField] private Color goodQualityColor, badQualityColor;

    private void Start()
    {
        //Intégration au Macro Jeu
        GameManager.Register(); //Mise en place du Input Manager, du Sound Manager et du Game Controller
        GameController.Init(this); //Permet a ce script d'utiliser le OnTick
        
        
        cutterSprite = GetComponent<SpriteRenderer>();
        cutterCollider = GetComponent<CircleCollider2D>();
        currentQuality = maxQuality;
        hasFinishedGame = false;
        
        if (isEasy)
        {
            contoursEasy.SetActive(true);
            cutsLeft = 24;
        }
        else if (isMedium)
        {
            contoursMedium.SetActive(true);
            cutsLeft = 40;
        }
        else if(isHard)
        {
             contoursHard.SetActive(true);
             cutsLeft = 36;
        }
    }

    void FixedUpdate()
    {
        if (!hasFinishedGame)
        {
            //Joystick Input
            joystickInput = new Vector2(InputManager.GetAxis(ControllerAxis.LEFT_STICK_HORIZONTAL),
                -InputManager.GetAxis(ControllerAxis.LEFT_STICK_VERTICAL));
            transform.position += new Vector3(joystickInput.x, -joystickInput.y, 0) * speed * Time.fixedDeltaTime;
        
            //Quality Bar Feedback
            qualityBarTransform.localScale = new Vector2(currentQuality / maxQuality * 15, 1f);
            qualityBarImage.color = Color.Lerp( badQualityColor, goodQualityColor, currentQuality / maxQuality);

            if (isLosingQuality)
            {
                currentQuality -= Time.deltaTime*6;
            }
        }

        if (cutsLeft == 0)
        {
            canvasObj.SetActive(false);
            winScreen.SetActive(true);
            cutterSprite.enabled = false;
            cutterCollider.enabled = false;
            hasFinishedGame = true;
        }

        if (currentQuality < 0)
        {
            canvasObj.SetActive(false);
            loseScreen.SetActive(true);
            cutterSprite.enabled = false;
            cutterCollider.enabled = false;
            hasFinishedGame = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("p"))
        {
            other.GetComponent<SpriteRenderer>().color = Color.black;
            other.GetComponent<BoxCollider2D>().enabled = false;
            cutsLeft--;
            Debug.Log("colision with a pontilhado");
        }
    }
    
    public void OnTick()
    {
        if (GameController.currentTick == 5)
        {
            //Le jeu se finit, il nous reste 3 ticks pour afficher le résultat
        }

        if (GameController.currentTick == 8)
        {
            //Le jeu se décharge
            GameController.FinishGame(true);
        }
    }
}
