using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    
    [SerializeField] int timesHit;
    [SerializeField] Sprite[] hitSprites;
    Level level;

    void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (tag == "Breakable")
        {
           HandleHit();

        }
       
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits  = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else{
            ShowNextHitSprites();
        }
    }

    private void ShowNextHitSprites()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null){
             GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else{
            Debug.LogError("Block Sprite is missing" + gameObject.name);
        }
       
    }

    private void DestroyBlock()
    {

        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();

    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameState>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
