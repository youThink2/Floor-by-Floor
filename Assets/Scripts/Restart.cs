using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject restartScreen;
     

    public void RestartGame()
    {
        //Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        restartScreen.SetActive(true);
        //Destroy the fade when game over
       
    }
}