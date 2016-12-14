using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void GoToMenu(){
		SceneManager.LoadScene ("Menu");
	}
		
	public void GoToHowTo(){
		SceneManager.LoadScene ("HowToScene");
	}

	public void GoToLore(){
		SceneManager.LoadScene ("LoreScene");
	}

	public void GoToGame(){
		SceneManager.LoadScene ("PlatformScene");
	}
}
