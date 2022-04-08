using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class TextWriter : MonoBehaviour
{
  [SerializeField]
  private Text _title;
  public int score = 0;
  public int addPoints;
  public string scoreText;

  void start()
  {
    score = 0;
    scoreText ="score: "+score;
    _title.text = scoreText;
  }

  public void addToScore()
  {
    score += addPoints;
    scoreText = "score: "+score;
    _title.text = scoreText;
  }

  public void subtractScore()
  {
    score -= 1;
    scoreText = "score: "+score;
    _title.text = scoreText;
  }

  public void setScore()
  {
    if (score > PlayerPrefs.GetInt("highscore"))
    {
      PlayerPrefs.SetInt("highscore",  score);
      PlayerPrefs.SetInt("score",  PlayerPrefs.GetInt("highscore"));
    }
    else
    {
      PlayerPrefs.SetInt("score",  score);
    }
  }

    
}
