using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            ball.Bounce(new Vector2(1, -1), Vector2.zero);
        }
    }
}
