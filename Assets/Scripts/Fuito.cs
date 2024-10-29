using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Fuito : Enemy
{
    public override void Start()
    {
        base.Start();
        StartCoroutine(MoveSideToSide());
    }
    IEnumerator MoveSideToSide()
    {
        transform.DOMoveX(-2f, 4.2f).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(4.2f);
        transform.DOMoveX(2f, 4.2f).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(4.2f);
        StartCoroutine(MoveSideToSide());
    }
}
