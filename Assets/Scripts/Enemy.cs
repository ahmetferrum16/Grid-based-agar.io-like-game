using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    private bool isMoving = false;
    private float timeToMove = 0.2f;

    void OnEnable()
    {
        GridMovement.OnPlayerMoved += MoveTowardsPlayer;
    }

    void OnDisable()
    {
        GridMovement.OnPlayerMoved -= MoveTowardsPlayer;
    }

    void MoveTowardsPlayer()
    {
        if (!isMoving)
        {
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        isMoving = true;

        Vector3 orjPos = transform.position;
        Vector3 direction = GetDirectionTowardsPlayer();
        Vector3 targetPos = orjPos + direction;

        float elapsedTime = 0f;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(orjPos, targetPos, elapsedTime / timeToMove);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    Vector3 GetDirectionTowardsPlayer()
    {
        Vector3 direction = Vector3.zero;
        Vector3 playerPos = playerTransform.position;

        float deltaX = playerPos.x - transform.position.x;
        float deltaY = playerPos.y - transform.position.y;

        if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
        {
            // Move horizontally
            direction.x = deltaX > 0 ? 1 : -1;
        }
        else
        {
            // Move vertically
            direction.y = deltaY > 0 ? 1 : -1;
        }

        return direction;
    }
}
