using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerScript player;

    [SerializeField] GameObject GameOverUi;
    [SerializeField] GameObject bird;
    [SerializeField] Vector3 birdStartPos;
    GameObject[] pipes;
    
    void Awake()
    {
        GameOverUi.SetActive(false);

        player = bird.GetComponent<PlayerScript>();
    }
    //We Assign this function to button

    public void RestartGame()
    {
        ResumeGame();

        // Reset bird position
        bird.transform.position = birdStartPos;
        bird.GetComponent<SpriteRenderer>().enabled = true;

        // Reset input
        player.canJump = true;
        player.enabled = false;
        player.enabled = true;

        //Resetting the high_score before score reset
        ResetHighScore();

        // Reset score
        ScoreHandler.instance.ResetScore();

        // Delete pipes
        ClearPipes();

        GameOverUi.SetActive(false);
    }

    public void PauseGame(){
        Time.timeScale = 0.0f;
    }
    public void ResumeGame(){
        Time.timeScale = 1.0f;
    }

    public void GameOver(){
        PauseGame();
        player.enabled  = false;
        GameOverUi.SetActive(true);

    }
    
    void ResetHighScore(){
        ScoreHandler.instance.CalculateHighScore();
    }

    public void ExitYesUi(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void QuitUi()
    {
        Application.Quit();
    }
    public void ClearPipes()
    {
        pipes = GameObject.FindGameObjectsWithTag("PipeHolder");
        foreach (var item in pipes)
            Destroy(item);
    }
}
