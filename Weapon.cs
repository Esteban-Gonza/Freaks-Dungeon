using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable{

    [Header("Damage")]
    public int damagePoint = 1;
    public float pushForce = 2f;

    [Space][Header("Upgrade")]
    public int weaponLevel = 0;
    SpriteRenderer rend;

    [Space]
    float cooldown = 0.5f;
    float lastSwing;

    protected override void Start(){

        base.Start();
        rend = GetComponent<SpriteRenderer>();
    }

    protected override void Update(){

        base.Update();

        if (Input.GetKeyDown(KeyCode.Space)){

            if(Time.time -lastSwing > cooldown){

                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D coll){

        if(coll.tag == "Fighter"){

            if (coll.name == "Player")
                return;

            Damage dmg = new Damage{

                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("ReceiveDamage", dmg);
        }
    }

    void Swing(){

        Debug.Log("Swing");
    }
}