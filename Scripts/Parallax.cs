using UnityEngine;

public class Parallax : MonoBehaviour
{
    MeshRenderer mesh;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mesh = this.GetComponent<MeshRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        mesh.material.mainTextureOffset += new Vector2(speed * Time.deltaTime,0.0f);
    }
}
