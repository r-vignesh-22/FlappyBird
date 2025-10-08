using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] LayerMask birdLayer;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(((1 << collision.gameObject.layer) & birdLayer) != 0)
        {
            //increase the score
            ScoreHandler.instance.IncrementScore(1);
        }
    }
}
