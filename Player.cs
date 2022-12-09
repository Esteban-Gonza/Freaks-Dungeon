using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter{

    Vector3 moveDelta;
    RaycastHit2D hit;

    BoxCollider2D playerCollider;

    void Start(){
        
        playerCollider = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate() {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Reset moveDelta
        moveDelta = new Vector3(x, y, 0);

        //Swap sprite direction
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if(moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        //Make sure we can move by cast a box. y coordinates
        hit = Physics2D.BoxCast(transform.position,playerCollider.size, 0, new Vector2(0, moveDelta.y), 
            Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Character","Blocking"));

        if(hit.collider == null){

            //Movement
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        //Make sure we can move by cast a box. x coordinates
        hit = Physics2D.BoxCast(transform.position, playerCollider.size, 0, new Vector2(moveDelta.x, 0),
            Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Character", "Blocking"));

        if (hit.collider == null){

            //Movement
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}