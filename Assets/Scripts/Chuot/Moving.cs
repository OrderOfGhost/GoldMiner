using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;
    public bool MoveB = true;
    public Animator anim;

    void Update() {
        Move();
        if (anim.GetBool("ChuotThuong")==true)
        {
             MoveB = true;
        }
    }

    void Move()
    {
        if(MoveB)
        {
            if(!movingRight)
            {
                transform.Translate (new Vector3(speed * Time.deltaTime,0f,0f));
            }
            else
            {
                transform.Translate (new Vector3(-speed * Time.deltaTime,0f,0f));
            }
        }
    }

    public void Flip()
    {
        movingRight = !movingRight;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1; 
        transform.localScale = Scale;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == Tags.MAP1)
        {
            Flip();
        }
        if (other.tag == Tags.MAP2)
        {
            Flip();
        }
        if (other.tag == Tags.HOOK)
        {
            MoveB = false;
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
