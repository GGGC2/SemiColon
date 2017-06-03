using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_manager : MonoBehaviour {
	public int Next_scene;
	// Use this for initialization

	public void Scene_change(){
		SceneManager.LoadScene (Next_scene.ToString ());
	}
}
