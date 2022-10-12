using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float Horizontal;
    [SerializeField] int BulletDamage = 5;
    Rigidbody2D rb;
    [SerializeField] float BulletForce = 5f;
    Playercontroller PlayerScript;
    void Start()
    {
        PlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Playercontroller>();
        Horizontal = Input.GetAxis("Horizontal");
        rb = GetComponent<Rigidbody2D>();
        if (!PlayerScript.IsRight())
        {



            rb.AddForce(Vector2.right * BulletForce, ForceMode2D.Impulse);
        }
        else
        {

            rb.AddForce(Vector2.left * BulletForce, ForceMode2D.Impulse);
        }

Destroy(gameObject,5f);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Object"))
        {
            other.transform.GetComponent<cube>().GetDamage(BulletDamage);
            Destroy(gameObject);



        }
    }


}
