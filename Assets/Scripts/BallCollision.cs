using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [Header("Collision options")]
    [SerializeField] private GameManager GameManager;
    [SerializeField] private PlayerMovement PlayerMovement;

    [Space]

    [SerializeField] private ParticleSystem ExplosionFX;
    [SerializeField] private Splatter SplatterManager;
    [SerializeField] private int ballIndex;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            GameManager.IsGameOver = true;

            ExplosionFX.Play();
            SplatterManager.AddSplatter(other.transform, other.contacts[0].point, ballIndex);

            PlayerMovement.Restart();
        }
    }
}
