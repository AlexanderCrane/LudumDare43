﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when something enters the button's radius
public class DoorCode : MonoBehaviour
{
    // Use this for initialization
    public float moveSpeed;
    public bool Dooropen;

    public void doorUnlocked()
    {
        Dooropen = true;
        ChangeTheDamnSprite(); // call method to change sprite
    }

    private void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "Player" && Dooropen)
        {
            //you win
        }
    }

    //button changing when pressed
    public Sprite sprite1; // Drag your first sprite here
    public Sprite sprite2; // Drag your second sprite here

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = sprite1; // set the sprite to sprite1
    }


    void ChangeTheDamnSprite()
    {
        if (spriteRenderer.sprite == sprite1) // if the spriteRenderer sprite = sprite1 then change to sprite2
        {
            spriteRenderer.sprite = sprite2;
        }
        else
        {
            spriteRenderer.sprite = sprite1; // otherwise change it back to sprite1
        }
    }
}