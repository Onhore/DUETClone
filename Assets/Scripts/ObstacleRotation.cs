using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleRotation : MonoBehaviour
{
    [Header("Rotation options")]
    [SerializeField] private float RotationDuration;
    private void Start()
    {
        transform.DORotate(new Vector3(0f, 0f, 1f), RotationDuration)
                 .SetLoops(-1, LoopType.Incremental);
    }
}
