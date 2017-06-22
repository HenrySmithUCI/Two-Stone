using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScenes : MonoBehaviour {

	public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void reset()
    {
        ChangeScene("Level" + GameSpace.instance.currentLevel);
    }

    public void next()
    {
        ChangeScene("Level" + (GameSpace.instance.currentLevel + 1));
    }

    public void menu()
    {
        ChangeScene("Menu");
    }
}
