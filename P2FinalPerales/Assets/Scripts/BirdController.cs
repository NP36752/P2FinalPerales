using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float upForce = 200f;

    public AudioClip Death;
    public AudioClip Flap;
    AudioSource audioSource;

    private bool isDead = false;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent <AudioSource>();
    }

    
    void Update()
    {
        if(isDead == false)
        {
            if(Input.GetMouseButtonDown (0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                PlaySound(Flap);
            }
        }
    }
    
    void OnCollisionEnter2D()
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        PlaySound(Death);
        GameControl.Instance.BirdDied();
    }
    
    
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

}
