using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class missionComplete : MonoBehaviour
{

    [SerializeField] private string loadLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Level Complete");
            SceneManager.LoadScene(loadLevel);

        }
        
    }
    
    
}
