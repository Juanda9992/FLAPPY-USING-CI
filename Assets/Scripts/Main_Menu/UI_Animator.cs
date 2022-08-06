using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI_Animator : MonoBehaviour
{
    public void ShrinkOut(GameObject objectToShrink)
    {
        objectToShrink.transform.DOScale(Vector2.zero,0.3f).OnComplete(()=> objectToShrink.gameObject.SetActive(false));
    }

    public void ShrinkIn(GameObject objectToShrink)
    {
        objectToShrink.gameObject.SetActive(true);
        objectToShrink.transform.DOScale(Vector2.one,0.3f);
    }
}
