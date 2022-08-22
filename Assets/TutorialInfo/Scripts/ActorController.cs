using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    private Vector2 moveDir;
    public float moveSpeed;
    public void Move(Vector2 dir)
    {
        moveDir = dir;

    }
    private void Update()
    {
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }
}