using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Music : MonoBehaviour
{
    void Awake()
    {
        GameObject[] backgroundMusic = GameObject.FindGameObjectsWithTag("Music");
        if (backgroundMusic.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
}

//Music used was provided in class lab sessions