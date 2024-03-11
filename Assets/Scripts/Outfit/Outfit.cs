using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This scripts represents the actual outfit the player uses in the world
[RequireComponent(typeof(Animator))]
public class Outfit : MonoBehaviour
{
    private PlayerView _view;
    private Animator _anim;

    private void Awake()
    {
        _view = GetComponentInParent<PlayerView>();
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        if(_view != null && _anim != null)
            _view.AddAnimator(_anim);
    }
}
