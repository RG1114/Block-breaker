using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;


    //cached reference
    level level;

    //state variables
    [SerializeField] int timesHit; //serialized bcoz of debug purpose
    

    private void Start()
    {
        level=FindObjectOfType<level>();
        if (tag=="Breakable")
        {  
            
            level.CountBreakableBlocks();
            
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag=="Breakable")
        {  
            HandHit();
        }
    }
    private void Destroyblock()
    {
        AudioSource.PlayClipAtPoint(breakSound,Camera.main.transform.position);
        level.ReduceBreakableBlock();
        FindObjectOfType<GameStatus>().scoreAdder();
        TriggerSparklesVFX();
        
        Destroy(gameObject);  
    }
    private void TriggerSparklesVFX()
    {
        GameObject sparkles=Instantiate(blockSparklesVFX,transform.position,transform.rotation);
        Destroy(sparkles,2f);
    }
    private void HandHit()
    {
        timesHit++;
        if(timesHit>=maxHits)
        {
            Destroyblock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }
    private void ShowNextHitSprite()
    {
        int spriteIndex=timesHit-1;
        if(hitSprites[spriteIndex]!=null)
        {
            GetComponent<SpriteRenderer>().sprite=hitSprites[spriteIndex];
        }
        else
        {

            Debug.LogError("BLOCK SPRITE IS MISSING FROM ARRAY"+ gameObject.name);
        }
    }


}
