using UnityEngine;

public class test : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Get input from the horizontal and vertical axes
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Create a new vector for movement direction
        Vector3 moveDirection = new Vector3(moveX, moveY, 0f);

        // Normalize the movement direction to ensure consistent speed
        moveDirection.Normalize();

        // Move the player based on the move direction and speed
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
