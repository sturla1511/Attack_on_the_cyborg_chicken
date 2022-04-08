using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Text Stext;
    public Text HStext;


    // Start is called before the first frame update
    private void Start()
    {
        Stext.text = "score: " + PlayerPrefs.GetInt("score");

        HStext.text = "highscore: " + PlayerPrefs.GetInt("highscore");
    }
}
