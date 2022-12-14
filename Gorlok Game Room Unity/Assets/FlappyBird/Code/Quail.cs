using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quail : MonoBehaviour
{
    public float jumpVelocity;
    public AudioSource jumpSound;
    public AudioSource hurtSound;
    Rigidbody2D rigidBody2D;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        foreach (Touch touch in Input.touches)
        {
            if (touch.fingerId == 0 && Time.timeScale == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    Jump();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Lose();
    }

    void Jump()
    {
        rigidBody2D.velocity = Vector2.up * jumpVelocity;
        jumpSound.Play();
    }

    void Lose()
    {
        hurtSound.Play();
        GameManager.Instance.GameOver();
    }
}
