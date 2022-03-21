using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class PaddleAgent : Agent
{
    private Rigidbody2D _rb;
    [SerializeField] private float speed;
    public Ball ballRef;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public override void OnEpisodeBegin()
    {
        _rb.velocity = Vector2.zero;
        transform.localPosition = new Vector3(transform.localPosition.x, 0f, 0f);
        ballRef.Reset();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition.y);
        sensor.AddObservation(ballRef.transform.localPosition);
        sensor.AddObservation(ballRef.GetComponent<Rigidbody2D>().velocity);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        _rb.velocity = new Vector2(0, actions.ContinuousActions[0] * speed);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var a = actionsOut.ContinuousActions;
        a[0] = Input.GetAxisRaw("Vertical");
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            ball.Bounce(new Vector2(-1, 1), _rb.velocity);
            AddReward(1);
        }
    }
}
