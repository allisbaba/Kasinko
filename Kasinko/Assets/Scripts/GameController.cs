using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{

    public GameObject fallObj;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fall"))
        {
            
            Destroy(fallObj);
            
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
        
    }
}
