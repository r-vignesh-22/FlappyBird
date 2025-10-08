using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] LayerMask birdLayer;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (((1 << other.gameObject.layer) & birdLayer) != 0)
        {
            //grabbing player script
            PlayerScript ply = other.gameObject.GetComponent<PlayerScript>();
            ply.canJump = false;
            

            //calling GameManger
            GameManager game = GameObject.FindFirstObjectByType<GameManager>();
            game.GameOver();
            ScoreHandler.instance.CalculateHighScore();
            
            
        }
    }

    
}
