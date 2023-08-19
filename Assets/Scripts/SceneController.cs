using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
   public static void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
