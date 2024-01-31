using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveTime = 4;
    [SerializeField] float yPos = 10;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalMoveY(yPos, moveTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
