using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameObject.SetActive(false);
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
        gameObject.SetActive(false);
    }
    
    
}
