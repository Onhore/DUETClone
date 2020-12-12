using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Follow options")]
    [SerializeField] private Transform Target;
    [SerializeField] private float FollowingSpeed;

	private void LateUpdate ()
	{
		transform.position = Target.position;
	}
}
