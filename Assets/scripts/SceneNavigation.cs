using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation: MonoBehaviour
{

	public void StartMenuScene()
	{
		ChangeScene("0_MainMenu");
	}

	public void StartIntroScene()
    {
		ChangeScene("1_Intro");
	}

	public void StartGameScene()
	{
		ChangeScene("2_Gameplay");
	}

	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
	public void QuitGame()
	{
		Application.Quit();
	}
}
