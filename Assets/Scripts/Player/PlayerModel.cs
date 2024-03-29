using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] Transform basePlayer;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    
    public void Move(float h, float v)
    {
        Vector3 newDir = new Vector3(h, v).normalized;
        rb.velocity = newDir * (speed * Time.deltaTime);
    }
}