using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    [SerializeField] AudioClip FruitSound;
    [SerializeField] int PointPerFruit = 100;

    //Player playerBody;

    bool collectFruits = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var playerBody = FindObjectOfType<Player>().GetComponent<CapsuleCollider2D>();
        if ( collision == playerBody)
        {
            FindObjectOfType<GameSession>().AddToScore(PointPerFruit);
            AudioSource.PlayClipAtPoint(FruitSound, Camera.main.transform.position);
            Destroy(gameObject);
        }
        
    }
}
