using Assets.Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(SceneConstants.MainMenu);
        }
    }
}
