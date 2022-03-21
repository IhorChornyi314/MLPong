using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rect bounds;
    private Rigidbody2D _rb;

    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Bounce(Vector2 direction, Vector2 boost)
    {
        Vector2 velocity = _rb.velocity;
        _rb.velocity = (new Vector2(velocity.x * direction.x, velocity.y * direction.y) + boost).normalized * speed;
    }

    public void Reset()
    {
        _rb.velocity = new Vector2(Random.value - 0.5f, (Random.value - 0.5f) / 5f).normalized * speed;
        transform.localPosition =
            new Vector3(Random.Range(bounds.xMin, bounds.xMax), Random.Range(bounds.yMin, bounds.yMax));
    }
}
