using UnityEngine;

public class Player_BaseRotation : MonoBehaviour
{
    public float speed;

    // Gerçek player tanklarında bu kod olmayacak
    void Update()
    {
        Rotate();
    }
    private void Rotate()
    {
        if (Input.anyKey)
        {
            transform.Rotate(new Vector3(30f, 0f, 0f) * Time.deltaTime * speed);
        }
    }
}
