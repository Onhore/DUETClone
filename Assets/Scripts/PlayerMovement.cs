using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement options")]
    [SerializeField] private float Speed;
    [SerializeField] private float RotationSpeed;
    
    [Header("Restarting options")]
    [SerializeField] private Collider2D RedBallCollider;
    [SerializeField] private Collider2D BlueBallCollider;
    
    [Space]

    [SerializeField] private GameManager GameManager;

    private Vector3 startPosition;
    private Rigidbody2D rigidBody;
    private float touchPositionX;

    private void Start()
    {
        startPosition = transform.position;
        rigidBody = GetComponent<Rigidbody2D>();
        MoveUp();
    }

    private void Update()
    {
        if (!GameManager.IsGameOver)
        {

            if (Input.GetMouseButtonDown(0))
                touchPositionX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

            if (Input.GetMouseButton(0))
            {
                if (touchPositionX > 0.01f)
                    RotateRight();
                else
                    RotateLeft();
            }
            else
                rigidBody.angularVelocity = 0f;
            
            #if UNITY_EDITOR

            if (Input.GetKeyDown(KeyCode.LeftArrow))
                RotateLeft();
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                RotateRight();
        
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
                rigidBody.angularVelocity = 0f;

            #endif
        }
    }

    private void MoveUp()
    {
        rigidBody.velocity = Vector2.up * Speed;
    }
    private void RotateLeft()
    {
        rigidBody.angularVelocity = RotationSpeed;
    }
    private void RotateRight()
    {
        rigidBody.angularVelocity = -RotationSpeed;
    }

    public void Restart()
    {
        RedBallCollider.enabled = false;
        BlueBallCollider.enabled = false;
        rigidBody.angularVelocity = 0f;
        rigidBody.velocity = Vector2.zero;

        transform.DORotate(Vector2.zero, 1f)
                 .SetDelay(1f)
                 .SetEase(Ease.InOutBack);

        transform.DOMove(startPosition, 1f)
                 .SetDelay(1f)
                 .SetEase(Ease.OutFlash)
                 .OnComplete (() => 
                 {
                    RedBallCollider.enabled = true;
                    BlueBallCollider.enabled = true;

                    GameManager.IsGameOver = false;

                    MoveUp();
                 });
    }

    void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("LevelEnd")) 
        {
			Destroy (other.gameObject);
			Debug.Log ("Win");

			var currentLevelIndex = SceneManager.GetActiveScene ().buildIndex;

			if (currentLevelIndex < SceneManager.sceneCountInBuildSettings)
				SceneManager.LoadSceneAsync (++currentLevelIndex);
		}
	}
}