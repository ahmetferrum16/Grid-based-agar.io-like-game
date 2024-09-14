using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class GridMovement : MonoBehaviour
{

    private bool isMoving = false;
    private Vector3 orjPos, targetPos;
    private float timeToMove = 0.2f;
    public static int MoveCount = 0;

    public delegate void PlayerMoved();
    public static event PlayerMoved OnPlayerMoved;

    

    void Start()
    {
        
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !isMoving && inBoard())
        {
            StartCoroutine(PlayerMove(Vector3.up));
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !isMoving && inBoard())
        {
            StartCoroutine(PlayerMove(Vector3.left));
        }
        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !isMoving && inBoard())
        {
            StartCoroutine(PlayerMove(Vector3.down));
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !isMoving && inBoard())
        {
            StartCoroutine(PlayerMove(Vector3.right));
        }
    }

    public bool inBoard()
    {
        if (transform.position.x >= 0 && transform.position.x <= 14 && transform.position.y >= 0 && transform.position.y <= 8)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerator PlayerMove(Vector3 vector3)
    {
        isMoving = true;

        MoveCount++;

        float elapsedTime = 0f;

        orjPos = transform.position;
        targetPos = orjPos + vector3;

        while (elapsedTime< timeToMove*2.5)
        {
            transform.position = Vector3.Lerp(orjPos, targetPos, elapsedTime / timeToMove);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;

        OnPlayerMoved?.Invoke();
    }

    
}


