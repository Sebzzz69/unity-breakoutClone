using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCrashes : MonoBehaviour
{
    int i;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameCrash();
    }


    void GameCrash()
    {
        while (true)
        {
            i = 0; i = 1;
        }
            
    }
}
