using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public List<SpriteRenderer> Spriterenderers;
    public Color color = Color.red;
    public float duration = .3f;

    private Tween _CurrentTween;

    private void OnValidate()
    {
        Spriterenderers = new List<SpriteRenderer>();
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            Spriterenderers.Add(child);
        }
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Flash();
        }
    }
    public void Flash()
    {

        if(_CurrentTween!= null)
        {
            _CurrentTween.Kill();
            Spriterenderers.ForEach(i => i.color = Color.white);
        }

        foreach (var s in Spriterenderers)
        {
            _CurrentTween = s.DOColor(color, duration).SetLoops(2, LoopType.Yoyo);
        }
    }

}
