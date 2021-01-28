using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rat: MonoBehaviour
{

    public static event Action<int> RatChewed = delegate { };
    public int randomScore;
    public bool alive;
    public bool HasRatChewed;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (hasRatBitten)
        {
            Vector2 position = transform.position;
            position.y = position.y - 1f;
            transform.position = position;
            hasRatBitten = false;
        }*/
        if (Input.GetKeyDown("space"))
        {
            // Move rat forward and check for point

            if (alive)
            {
                StartCoroutine(waiter());
            }

            var spark = GameObject.Find("Spark").GetComponent<Spark>();
            
            if ((spark.transform.position.x - .3f <= transform.position.x) && (spark.transform.position.x + .3f >= transform.position.x))
            {
                // Rat dies, game over screen pops up.
                ChangeSprite();
                alive = false;
                Time.timeScale = 0;
            }
            else
            {
                RatChewedSuccessfully();
            }
            
        }
        
    }

    public void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
    }

    IEnumerator waiter()
    {
        Vector2 position = transform.position;
        position.y = position.y + .2f;
        transform.position = position;
        yield return new WaitForSeconds(0.2f);
        Vector2 position2 = transform.position;
        position2.y = position2.y - .2f;
        transform.position = position2;
    }

    public void RatChewedSuccessfully()
    {
        randomScore = UnityEngine.Random.Range(1, 5);
        RatChewed(randomScore);
    }

}

