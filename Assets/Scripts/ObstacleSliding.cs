using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleSliding : MonoBehaviour
{
    [Header("Sliding options")]
    [SerializeField] private float SlideDistance;
    [SerializeField] private float SlideDuration;

    private void Start()
    {
        transform.DOLocalMoveX(SlideDistance, SlideDuration)
                 .SetLoops(-1, LoopType.Yoyo)
                 .SetEase(Ease.InOutBack);
    }
}
