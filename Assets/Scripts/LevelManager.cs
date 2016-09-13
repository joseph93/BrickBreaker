using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void loadLevel(string level)
    {
        SceneManager.LoadScene(level);
	    Brick.breakableCount = 0;
    }

    public void endGame()
    {
        Application.Quit();
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Brick.breakableCount = 0;
    }

    public void bricksDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            loadNextLevel();
        }
    }
}
