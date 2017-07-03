using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfoController : MonoBehaviour
{
	public Image Info;
    public float speed;

    private float GameTime;

    private void Start()
    {
        Info.color = new Color(1, 1, 1, 0);
        GameTime = 0;
    }

    private void Update()
    {
        GameTime = GameTime + Time.deltaTime;

        if(GameTime <= 3f)
        {
            Info.color = new Color (1, 1, 1, Info.color.a + speed * Time.deltaTime);
        }
        else if (GameTime >= 3.5f && GameTime < 7f)
        {
            Info.color = new Color (1, 1, 1, Info.color.a - speed * Time.deltaTime);
        }
        else if (GameTime >= 7f)
        {
            SceneManager.LoadScene(1);
        }
    }
}