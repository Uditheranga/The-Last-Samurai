using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeCount : MonoBehaviour
{

    public Image[] lives;
    public int livesRemaining;
    [SerializeField] private string loadScene;


    public void LoseLife()
    {
        //if no lives remaining

        if (livesRemaining == 0)
        {
            return;
        }
        //Decrease the value of lives remaining

        livesRemaining--;

        //Hide one of life images

        lives[livesRemaining].enabled = false;

        //if we ran out of lives we lose

        if (livesRemaining == 0)
        {
            //FindObjectOfType<playerContoller>().Die();
            SceneManager.LoadScene(loadScene);
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //    LoseLife();
    }

}
