using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_manager : MonoBehaviour {
	public static Scene_manager Instance{get{return instance;}}
	private static Scene_manager instance;

	public void Awake(){
		instance = this;
	}
	public int Next_scene;
	public int this_scene;
	// Use this for initialization

	public void Scene_change(){
		SceneManager.LoadScene (Next_scene);
	}
	public void Reload_this_scene(){
		SceneManager.LoadScene (this_scene);
	}

	public void HowToPlay()
	{
		SceneManager.LoadScene(8);
	}

	public void Credit()
	{
		SceneManager.LoadScene(9);
	}

	public void GoToHome()
	{
		SceneManager.LoadScene(1);
	}
}
