using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public Sprite flatSprite;
    public AnimatedSprite dying;
    public AudioSource deathSound;

    private void OnCollisionEnter2D(Collision2D collision){
        
        if(collision.gameObject.CompareTag("Player")){
            Player player = collision.gameObject.GetComponent<Player>();

            if(collision.transform.DotTest(transform, Vector2.down)){
                deathSound.Play();
                Flatten();
            } else{
                player.Hit();
            }
        }

    }

    private void Flatten(){
        dying.enabled = true;
        Destroy(gameObject, 1f);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EntityMovement>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
    }
}
