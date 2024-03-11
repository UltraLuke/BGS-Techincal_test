using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private List<Animator> animators;
    [SerializeField] private bool isPlayer;

    private void OnEnable()
    {
        EventsManager.SubscribeToEvent("EV_RESUME_GAME", ResetAnimations);
    }
    private void OnDisable()
    {
        EventsManager.UnsubscribeToEvent("EV_RESUME_GAME", ResetAnimations);
    }
    
    private void Update()
    {
        if (!isPlayer)
        {
            SetMovementAxes(0, -0.1f);
        }
    }

    public void AddAnimator(Animator anim)
    {
        if (!animators.Contains(anim))
        {
            animators.Add(anim);
            ResetAnimations();
        }
    }

    public void SetMovementAxes(float h, float v)
    {
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
    
    //Resets the animators to sync all the animations.
    private void ResetAnimations()
    {
        CheckAndRemoveNullReferences();
        
        foreach (var a in animators)
        {
            a.SetTrigger("Restart");
        }
    }

    private void CheckAndRemoveNullReferences()
    {
        for (int i = 0; i < animators.Count; i++)
        {
            if (animators[i] == null)
            {
                animators.RemoveAt(i);
                i--;
            }
        }
    }
}
