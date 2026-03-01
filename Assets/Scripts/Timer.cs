using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{                                                       
    public float Duration = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Duration = Duration - 1 * Time.deltaTime;
       print(Duration);
       if(Duration <= 0){
            Destroy(gameObject);
       }
       
    }
}
