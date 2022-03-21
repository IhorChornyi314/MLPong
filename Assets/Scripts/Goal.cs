using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public PaddleAgent myPaddle, otherPaddle;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            myPaddle.AddReward(-1);
            myPaddle.EndEpisode();
            otherPaddle.EndEpisode();
        }
    }
}
