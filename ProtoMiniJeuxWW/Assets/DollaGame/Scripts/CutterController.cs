using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterController : MonoBehaviour
{
    private Vector2 joystickInput;
    [SerializeField] private float speed = 5f;
    public bool isLosingQuality = false;
    [SerializeField] private int cutsLeft = 39;
    [SerializeField] private GameObject winScreen;
    public float quality = 10;
    private SpriteRenderer cutterSprite;
    private CircleCollider2D cutterCollider;
    [SerializeField] private GameObject contoursEasy, contoursMedium, contoursHard;
    public bool isEasy, isMedium, isHard;

    private void Start()
    {
        cutterSprite = GetComponent<SpriteRenderer>();
        cutterCollider = GetComponent<CircleCollider2D>();
        
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
        joystickInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.position += new Vector3(joystickInput.x, -joystickInput.y, 0) * speed * Time.fixedDeltaTime;

        if (isLosingQuality)
        {
            quality -= Time.deltaTime*6;
        }

        if (cutsLeft == 0)
        {
            winScreen.SetActive(true);
            cutterSprite.enabled = false;
            cutterCollider.enabled = false;
        }

        if (quality < 0)
        {
            //Lose
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
}
