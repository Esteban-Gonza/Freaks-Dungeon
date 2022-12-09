using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable{

    [SerializeField] Sprite emptyChest;
    public int pesosAmaount = 5;

    protected override void OnCollect(){

        if (!collected){

            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.ShowText("+$"+ pesosAmaount, 25, Color.yellow, transform.position, Vector3.up * 25, 1f) ;
        }
    }
}