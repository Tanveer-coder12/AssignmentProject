using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
   public void StartGameButton()
   {
        SceneManager.LoadScene("GameScene");
   }
   
   public void ExitGameButton()
    {
        Application.Quit();
    }
}
