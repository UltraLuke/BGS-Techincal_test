using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private List<Animator> animators;

    private void Awake()
    {
        RefreshAnimatorReferences();
    }

    private void RefreshAnimatorReferences()
    {
        animators = GetComponentsInChildren<Animator>().ToList();
    }

    public void AddAnimator(Animator anim)
    {
        if(!animators.Contains(anim))
            animators.Add(anim);
    }

    public void SetMovementAxes(float h, float v)
    {
        for (int i = 0; i < animators.Count; i++)
        {
            if(!animators[i])
                continue;
            
            animators[i].SetFloat("hAxis", h);
            animators[i].SetFloat("vAxis", v);
        }
    }
}
