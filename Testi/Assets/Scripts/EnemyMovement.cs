using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveTime = 4f;
    [SerializeField] float yPos = 10f;
    [SerializeField] float xPos = 10f;

    public bool xMovement = false;
    public bool yMovement = false;

    // Start is called before the first frame update
    void Start()
    {
        if (xMovement == true && yMovement == true)
        {
            transform.DOLocalMoveX(xPos, moveTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
            transform.DOLocalMoveY(yPos, moveTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
        else if (xMovement == true)
        {
            transform.DOLocalMoveX(xPos, moveTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }

        else if(yMovement == true)
        {
            transform.DOLocalMoveY(yPos, moveTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}