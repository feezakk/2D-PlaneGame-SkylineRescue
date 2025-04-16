using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdObstacle : MonoBehaviour
{
    public float speed = 2f; // Speed of the background

    private void Update()
    {
        // Move the bird to the left at the same speed as the background
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Destroy the bird if it goes off-screen
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
