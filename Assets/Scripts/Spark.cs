using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour
{
    public int sparkRotation;
    public float sparkSpeed;
    private Rigidbody2D sparkRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        sparkRigidbody = GetComponent<Rigidbody2D>();
        sparkSpeed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 pos = Camera.main.WorldToViewportPoint(transform.position);
        var rat = GameObject.Find("Rat").GetComponent<Rat>();
        if (pos.x < 0.0)
        {
            transform.position = new Vector2(5, transform.position.y);
            sparkRotation++;
            sparkSpeed += .02f * rat.ChewCounter / 2;
        }
        else if (rat.isHardDiff && transform.position.x < rat.transform.position.x)
        {
            sparkRigidbody.velocity = new Vector2(-sparkSpeed*5, 0);
        }
        else
        {
            sparkRigidbody.velocity = new Vector2(-sparkSpeed, 0);
        }

    }

    public void StartAtBeginingAndUpSpeed()
    {
        transform.position = new Vector2(5, transform.position.y);
        sparkRotation++;
        sparkSpeed += .2f;
    }
}