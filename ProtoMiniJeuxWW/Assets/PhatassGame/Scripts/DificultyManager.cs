using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultyManager : MonoBehaviour
{
    //[SerializeField] private GameObject keyRightPocket, keyLeftPocket, emptyRightPocket, emptyLeftPocket;
    [SerializeField]
    private SpriteRenderer keyLeftPocket, tagKeyLeftPocket, keyRightPocket, emptyLeftPocket, emptyRightPocket;

    [SerializeField] private BoxCollider2D leftKeyCollider, rightKeyCollider;
    [SerializeField] private bool isEasy, isNormal, isHard;
    private float animSpeedControl;
    private Animator phatassAnimator;
    
    void Start()
    {
        phatassAnimator = GetComponent<Animator>();
        if (isEasy)
        {
            animSpeedControl = 1f;
            //keyLeftPocket.SetActive(true);
            //emptyRightPocket.SetActive(true);

            emptyLeftPocket.enabled = false;
            keyRightPocket.enabled = false;
            rightKeyCollider.enabled = false;
            
            Debug.Log("Easy Mode Active");
        }
        else if (isNormal)
        {
            animSpeedControl = 2f;
            //keyLeftPocket.SetActive(true);
            //emptyRightPocket.SetActive(true);
            
            emptyLeftPocket.enabled = false;
            keyRightPocket.enabled = false;
            rightKeyCollider.enabled = false;
            
            Debug.Log("Normal Mode Active");
        }
        else if (isHard)
        {
            animSpeedControl = 2.5f;
            //keyRightPocket.SetActive(true);
            //emptyLeftPocket.SetActive(true);

            emptyRightPocket.enabled = false;
            keyLeftPocket.enabled = false;
            tagKeyLeftPocket.enabled = false;
            leftKeyCollider.enabled = false;
            
            Debug.Log("Hard Mode Active");

        }
        phatassAnimator.SetFloat("animSpeed", animSpeedControl);
        phatassAnimator.enabled = true;
    }
}
