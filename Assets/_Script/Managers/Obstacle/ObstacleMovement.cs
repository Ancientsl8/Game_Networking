using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleMovement : MonoBehaviour
{
    public Vector3 Rotation;
    public float SpinDuration;
    public int LoopCount;
    public LoopType Loop;

    public Vector3 StartPosition;
    public Vector3 EndPosition;
    public float LRDuration;

    void Start()
    {
        transform.DOLocalRotate(Rotation, SpinDuration, RotateMode.LocalAxisAdd).SetLoops(LoopCount, Loop).SetEase(Ease.Linear);

        StartMovement();
    }

    void Update()
    {

    }

    public void StartMovement()
    {
        transform.DOLocalMove(EndPosition, LRDuration).OnComplete(() => RestartMovement()).SetEase(Ease.Linear);
    }

    public void RestartMovement()
    {
        transform.DOLocalMove(StartPosition, LRDuration).OnComplete(() => StartMovement()).SetEase(Ease.Linear);
    }
}
