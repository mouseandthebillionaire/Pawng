using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float ballSpeed;
    public float maxSpeed = 10f;
    public float minSpeed = 1f;

    public AudioSource scoreSound, blip;
    
    
    private int[] dirOptions = {-1, 1};
    private int hDir, vDir;
    
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Launch"); // StartCoroutine(Launch());
    }


    // Start the Ball Moving
    public IEnumerator Launch() {
        yield return new WaitForSeconds(1.5f);
        
        // Figure out directions
        hDir = dirOptions[Random.Range(0, dirOptions.Length)];
        vDir = dirOptions[Random.Range(0, dirOptions.Length)];
        
        // Add a horizontal force
        rb.AddForce(transform.right * ballSpeed * hDir); // 1,0
        // Add a vertical force
        rb.AddForce(transform.up * ballSpeed * vDir); // 0,1
    }

    private void Reset()
    {
        transform.position = new Vector2(0, 0);
        rb.velocity = Vector2.zero;
        StartCoroutine("Launch");
    }
    
    // if the ball goes out of bounds
    private void OnCollisionEnter2D(Collision2D other)
    {
        // did we hit a wall?
        if (other.gameObject.tag == "wall")
        {
            // make pitch higher?
            blip.pitch = 0.75f;
            blip.Play();
            
        }

        // did we hit a paddle?
        if (other.gameObject.tag == "paddle")
        {
            // make pitch higher?
            blip.pitch = 1f;
            blip.Play();
        }


        // Prevent ball from going too fast
        if (Mathf.Abs(rb.velocity.x) > maxSpeed) rb.velocity = new Vector2(rb.velocity.x * 0.9f, rb.velocity.y);
        if (Mathf.Abs(rb.velocity.y) > maxSpeed) rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.9f);
        
        if (Mathf.Abs(rb.velocity.x) < minSpeed) rb.velocity = new Vector2(rb.velocity.x * 1.1f, rb.velocity.y);
        if (Mathf.Abs(rb.velocity.y) < minSpeed) rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 1.1f);
        
        // // Too Sharp an angle
        // if (Mathf.Abs(rb.velocity.x) < minSpeed)
        // {
        //     if(rb.velocity.x < 0) rb.velocity = new Vector2(minSpeed, rb.velocity.y);
        //     else rb.velocity = new Vector2(minSpeed, rb.velocity.y);
        // }
        //
        // if (rb.velocity.y) < minSpeed) rb.velocity = new Vector2(rb.velocity.x, minSpeed);

        // if wall
        if (other.gameObject.tag == "LeftBounds")
        {
            // Point for the right
            scoreSound.Play();
            ScoreScript.S.UpdateScore(1);
            // Reset the Ball
            Reset();
        }
        if (other.gameObject.tag == "RightBounds")
        {
            // Point for the left
            scoreSound.Play();
            ScoreScript.S.UpdateScore(0);
            // Reset the Ball
            Reset();
        }
        
        Debug.Log(rb.velocity);
    }


}
