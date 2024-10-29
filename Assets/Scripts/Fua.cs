using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Fua : Enemy
{
    public override void Start()
    {
        base.Start();
        StartCoroutine(MoveInDiamond());
    }
    IEnumerator MoveInDiamond()
    {
        transform.DOMoveX(.8f, 1.5f).SetEase(Ease.OutCirc);
        transform.DOMoveY(3.2f, 1.5f).SetEase(Ease.OutCirc);
        yield return new WaitForSeconds(2f);
        transform.DOMoveX(0f, 1.5f).SetEase(Ease.OutCirc);
        transform.DOMoveY(2.7f, 1.5f).SetEase(Ease.OutCirc);
        yield return new WaitForSeconds(2f);
        transform.DOMoveX(-.8f, 1.5f).SetEase(Ease.OutCirc);
        transform.DOMoveY(3.2f, 1.5f).SetEase(Ease.OutCirc);
        yield return new WaitForSeconds(2f);
        transform.DOMoveX(0f, 1.5f).SetEase(Ease.OutCirc);
        transform.DOMoveY(3.7f, 1.5f).SetEase(Ease.OutCirc);
        yield return new WaitForSeconds(2f);
        StartCoroutine(MoveInDiamond());
    }
}
