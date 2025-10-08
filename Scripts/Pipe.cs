using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] public float destroyPos = -15f;

    void Update()
    {
        //moving the pipes left side
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        //Destroy the pipe
        if (transform.position.x < destroyPos) Destroy(gameObject);
    }
}
