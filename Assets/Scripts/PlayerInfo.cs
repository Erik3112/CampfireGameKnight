using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public float Health;
    public float Money; 
    public TMP_Text HealthText;
    public TMP_Text MoneyText;
    public Image GameOverImage;
    public Image YouWinImage;
    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
        HealthText.text = "Health: " + (int)Health;
        print("Health: " + Health);

        Money = 0;
        MoneyText.text = "Money: " + (int)Money;
        print( "Money: " + Money);
        
        GameOverImage.gameObject.SetActive(false);
        YouWinImage.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = "Health: " + (int)Health;
        MoneyText.text = "Money: " + (int)Money;
        if (Health <= 0)
        {
            GameOverImage.gameObject.SetActive(true);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Damage"){
        
            Health = Health - 20;
            print("Health" + Health);
        }else if (other.tag == "Medicine"){
        
            Health = Health + 20;
            Destroy(other.gameObject);
            print("Health" + Health);
            if (Health < 100)
            {
                Health = Health + 20;
            }else if (Health > 100)
            {
                Health = 100;
            }
            
        }

        if (other.tag == "Money"){
            Money = Money + 1;
            Destroy(other.gameObject);
            print("Money:" + Money);
        }

        if (other.tag == "YouWin")
        {
            YouWinImage.gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "DamageZone")
        {
            Health = Health - 1 * Time.deltaTime;
            print("Health" + Health);
        }
    }
}
