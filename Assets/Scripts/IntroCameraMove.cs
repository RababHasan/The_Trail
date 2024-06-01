using UnityEngine;

public class IntroCameraMove : MonoBehaviour
{
    public Transform target; // Assign the newspaper transform in the inspector
    public float speed = 1f;
    private bool shouldMove = true;

    void Update()
    {
        if (shouldMove)
        {
            // Move the camera towards the newspaper's position
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            // Check if the camera has reached the newspaper's position
            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                shouldMove = false; // Stop moving the camera
            }
        }
    }
}
