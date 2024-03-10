using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private List<Animator> animators;
    [SerializeField] private bool isPlayer;

    private void Update()
    {
        if (!isPlayer)
        {
            SetMovementAxes(0, -0.1f);
        }
    }

    public void AddAnimator(Animator anim)
    {
        // if (!isPlayer) return;
        
        if (!animators.Contains(anim))
        {
            animators.Add(anim);
            foreach (var a in animators)
            {
                a.SetTrigger("Restart");
            }
        }
    }

    public void SetMovementAxes(float h, float v)
    {
        // if (!isPlayer) return;

        for (int i = 0; i < animators.Count; i++)
        {
            if (animators[i] == null)
            {
                animators.RemoveAt(i);
                i--;
                continue;
            }
            
            animators[i].SetFloat("hAxis", h);
            animators[i].SetFloat("vAxis", v);
        }
    }
}
