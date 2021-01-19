using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;
    public float attackInterval;
    private float nextAttack;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("LeftClick") && Time.time > nextAttack)
        {
            Attack(false, "AttackLeft");
        }

        if(Input.GetButtonDown("RightClick") && Time.time > nextAttack)
        {
            Attack(true, "AttackRight");
        }
    }      

void Attack(bool facingRight,string clickAction)
{
        Flip(facingRight, clickAction);
        nextAttack = Time.time + attackInterval;
        anim.SetTrigger(clickAction);
    }

void Flip(bool pressedRight, string clickAction)
{
    if (facingRight != pressedRight)
    {
        facingRight = pressedRight;
        Vector3 mScale = transform.localScale;
        mScale.x *= -1;
        transform.localScale = mScale;
    }
}

}
