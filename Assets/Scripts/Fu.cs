using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fu : Enemy
{
    public override void Start()
    {
        base.Start();
        StartCoroutine(MoveCrescent());
    }
    IEnumerator MoveCrescent()
    {
        transform.DOMoveX(1.85f, 3f);
        transform.DOMoveY(1.2f, .3f);
        yield return new WaitForSeconds(2f);
        transform.DOMoveY(2.2f, .3f);
        yield return new WaitForSeconds(1.5f);
        transform.DOMoveX(-1.85f, 3f);
        transform.DOMoveY(1.2f, .3f);
        yield return new WaitForSeconds(2f);
        transform.DOMoveY(2.2f, .3f);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(MoveCrescent());
    }
}
