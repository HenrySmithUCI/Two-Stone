using UnityEngine;
using UnityEngine.UI;

public class SetupScene : MonoBehaviour {

    public Button[] buttons;
    public ChangeScenes sceneChanger;

	void Start () {
        int maxLevel = PlayerPrefs.GetInt("MaxLevel");
        for (int i = 0; i < buttons.Length; i++)
        {
            if(i <= maxLevel)
            {
                buttons[i].interactable = true;
            }
        }
	}

    public void resetPrefs()
    {
        PlayerPrefs.SetInt("MaxLevel", 0);
        sceneChanger.ChangeScene("Menu");
    }
}
