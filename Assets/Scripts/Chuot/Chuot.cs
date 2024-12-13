using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chuot : MonoBehaviour
{
    public Animator anim;
    
    private void OnTriggerEnter2D(Collider2D other) {
           if(other.tag == Tags.HOOK)
           {
               anim.SetBool("ChuotThuong", true);
           } 
    }
}
