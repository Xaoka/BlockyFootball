using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    public void startGame()
    {
        Time.timeScale = 1;
        GameObject.Find("play").SetActive(false);
    }
}
