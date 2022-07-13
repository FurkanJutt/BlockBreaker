using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Configuration Paramaters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject sparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] sprites;

    // Cached Reference
    Level level;
    GameStatus gameStatus;

    // State Variable
    [SerializeField] int timesHit; // Serialized for debugging

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        if (tag == "Breakable")
        {
            level.CountBreakAbleBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        if (tag == "Breakable")
        {
            timesHit++;
            maxHits = sprites.Length + 1;
            if (timesHit >= maxHits)
            {
                TriggerVFX();
                DestroyBlock();
                gameStatus.AddPlayerScore();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (sprites[spriteIndex] != null)
        { 
            GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex]; 
        }
        else
        {
            Debug.LogError("Sprite is missing from ' " + gameObject.name + " '");
        }
    }

    private void DestroyBlock()
    {
        Destroy(gameObject);
        level.BlockDestroyed();
    }

    private void TriggerVFX()
    {
        GameObject sparkles = Instantiate(sparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
