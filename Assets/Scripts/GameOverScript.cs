using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public float Duration;
  

    // Update is called once per frame
    void Update()
    {

        Duration = Duration - 1 * Time.deltaTime;
        if(Duration <= 0){
            SceneManager.LoadScene(0);
        }
    }
}
