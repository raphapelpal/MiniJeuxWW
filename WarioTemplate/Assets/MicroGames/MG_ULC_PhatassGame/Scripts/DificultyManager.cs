using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultyManager : MonoBehaviour
{
    //[SerializeField] private GameObject keyRightPocket, keyLeftPocket, emptyRightPocket, emptyLeftPocket;
    [SerializeField]
    private SpriteRenderer keyLeftPocket, tagKeyLeftPocket, keyRightPocket, emptyLeftPocket, emptyRightPocket;
    [SerializeField] private BoxCollider2D leftKeyCollider, rightKeyCollider;

    void Start()
    {
        if (GameController. difficulty == 1)
        {
            //keyLeftPocket.SetActive(true);
            //emptyRightPocket.SetActive(true);

            emptyLeftPocket.enabled = false;
            keyRightPocket.enabled = false;
            rightKeyCollider.enabled = false;
            
            Debug.Log("Easy Mode Active");
        }
        else if (GameController. difficulty == 2)
        {
            //keyLeftPocket.SetActive(true);
            //emptyRightPocket.SetActive(true);
            
            emptyLeftPocket.enabled = false;
            keyRightPocket.enabled = false;
            rightKeyCollider.enabled = false;
            
            Debug.Log("Normal Mode Active");
        }
        else if (GameController. difficulty == 3)
        {
            //keyRightPocket.SetActive(true);
            //emptyLeftPocket.SetActive(true);

            emptyRightPocket.enabled = false;
            keyLeftPocket.enabled = false;
            tagKeyLeftPocket.enabled = false;
            leftKeyCollider.enabled = false;
            
            Debug.Log("Hard Mode Active");

        }
    }
}
