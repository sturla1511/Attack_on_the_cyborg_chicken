using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class StartGame : MonoBehaviour
{
    public Animator anim;
    public bool startAnim;
    
    public void GameStart() //blir kalt nå man tryker på start kanpen i menu
    {
        LoadGameScene();
        startAnim = true;
        anim.SetBool("StartAnim", startAnim);
    }
    
    public Animator transition;
    public float transitionTime = 0.5f;
    public void LoadGameScene()
    {

        StartCoroutine(LoadGameScene(SceneManager.GetActiveScene().buildIndex + 1));
    }
    
    IEnumerator LoadGameScene(int LevelIndex){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);

    }


    
}
