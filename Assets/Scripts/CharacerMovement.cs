using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * move * speed * Time.deltaTime);
    }
}