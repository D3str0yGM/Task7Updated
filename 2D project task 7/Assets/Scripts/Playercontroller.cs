using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    float Horizontal;
    [Range(0, 10)]
    [SerializeField] float Speed;
    [SerializeField] Transform FirePoint;
    [SerializeField] GameObject Bullet;
    [SerializeField] float NextAttackTime;
    [SerializeField] float AttackRate;
    [SerializeField] float Second;
    bool isRight = true;




    void Update()
    {
        //transform.Rotate (Vector2.left * Time.deltaTime); 
        Horizontal = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(Horizontal * Speed, 0, 0) * Time.deltaTime;
        if (Horizontal < 0 && !isRight)
        {
            Flip();
        }
        else if (Horizontal > 0 && isRight)
        {

            Flip();
        }



        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time >= NextAttackTime)
            {
                Instantiate(Bullet, FirePoint.position, Quaternion.Euler(0, 0, 0));
                NextAttackTime = Time.time + Second / AttackRate;



            }

        }


    }
    void Flip()
    {
        isRight = !isRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    public bool IsRight()
    {
        return isRight;
    }
}
