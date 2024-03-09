using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Animator[] animators;

    public void SetMovementAxes(float h, float v)
    {
        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].SetFloat("hAxis", h);
            animators[i].SetFloat("vAxis", v);
        }
    }
}
