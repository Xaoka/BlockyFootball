using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private GameObject gameOverObject;
    private Text collectableText;
    private int collected = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.gameOverObject = GameObject.Find("gameOver");
        this.gameOverObject.SetActive(false);
        this.collectableText = GameObject.Find("CollectableText").GetComponent<Text>();
    }

    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            this.gameOverObject.SetActive(true);
            // Time.timeScale = 0;
            this.gameObject.GetComponentInChildren<Shake>().shakeForSeconds(1.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("shift"))
        {
            var shiftObject = other.gameObject.GetComponent<Shift>();
            shiftObject.Move();
        }
        else if (other.gameObject.CompareTag("collectable"))
        {
            Destroy(other.gameObject);
            this.collected++;
            this.collectableText.text = this.collected.ToString();
        }
        else if (other.gameObject.CompareTag("soundtrigger"))
        {
            if (UnityEngine.Random.Range(0f, 1f) < 0.3f)
            {
                var shiftObject = other.gameObject.GetComponent<AudioSource>();
                shiftObject.Play();
            }
        }
    }
}
