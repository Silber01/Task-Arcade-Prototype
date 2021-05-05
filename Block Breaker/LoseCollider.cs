using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] Ball ball;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (ball.EnableLoseCollider() == true)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
