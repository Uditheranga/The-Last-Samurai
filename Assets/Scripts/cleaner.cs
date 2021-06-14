using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cleaner : MonoBehaviour
{
    [SerializeField] private string GameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Fall");
            SceneManager.LoadScene(GameOver);
            Destroy(collision.gameObject);

        }
    }
}
