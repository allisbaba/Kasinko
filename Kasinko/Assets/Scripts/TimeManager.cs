using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using TMPro;

public class TimeManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI score_txt;
    public GameObject one;
    private float time_range = 1.0f;
    private float remaining_time = 0.0f;
    private float minusTime = 0.2f;
    public GameObject bombOne;
    public GameObject bombTwo;
    public GameObject bomb;
    public GameObject bombThree;
    public AudioSource sound_doc;
    public AudioClip sound_coin;
    public AudioClip sound_bomb;
    

   

    private void Update()
    {
        if (Time.time>= remaining_time)
        {
            SpawnOne();
            remaining_time = time_range + Time.time;
        }

        if (score>40)
        {
            bomb.SetActive(true);
        }

        if (score>=80)
        {
            bombOne.SetActive(true);
        }

        if (score>200)
        {
            bombTwo.SetActive(true);
        }

        if (score>350)
        {
            bombThree.SetActive(true);
        }
        

        
       
    }

    float CalculateTimeRange()
    {
        return 1.0f/(float)Math.Pow(score/20+1, 1.1);
    }

    void SpawnOne()
    {
        Vector3 position = new Vector3(Random.Range(-2.6F, 2.6F), UnityEngine.Random.Range(-4.2F, 4.2F), 1);
        Instantiate(one, position, transform.rotation);
        


    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.CompareTag("One") )
        {
            score += 1;
            sound_doc.PlayOneShot(sound_coin);
            score_txt.text = score.ToString();
            Debug.Log(score);
            Destroy(col.gameObject);
           
        }
        if (col.gameObject.CompareTag("Two") )
        {
            score += 2;
            sound_doc.PlayOneShot(sound_coin);
            Debug.Log(score);
            Destroy(col.gameObject);
           
        }

        if (col.gameObject.CompareTag("Bomb"))
        {
            sound_doc.PlayOneShot(sound_bomb);
            SceneManager.LoadScene("Scenes/GameOver");
        }

        time_range = CalculateTimeRange();
        
    }
    
}
