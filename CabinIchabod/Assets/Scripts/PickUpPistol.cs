using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PickUpPistol : MonoBehaviour
{

    public float Distance;
    public GameObject CommandKey;
    private Text CommandKeyText;
    public GameObject Command;
    private Text CommandText;
    public GameObject WorldGun;
    public GameObject PlayerGun;

    public Image Crosshair;

    public Image Bullet1;
    public Image Bullet2;
    public Image Bullet3;
    public Image Bullet4;
    public Image Bullet5;
    public Image Bullet6;
    public Image Bullet7;

    void Awake(){
        CommandKeyText = CommandKey.GetComponent<Text>();
        CommandText = Command.GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Distance = Player.TargetDistance; 
    }

    //This function is what makes the text appear on the screen when the player hovers the 
    //mouse over the cube object around the gun on the table or make it not appear when
    //the player is not looking at it.
    void OnMouseOver(){
        if(Distance < 2){
            CommandKeyText.text = "[e]";
            CommandText.text = "Pick Up Pistol";
            CommandKey.SetActive(true);
            Command.SetActive(true);

            if(Input.GetButtonDown("Action")){
                WorldGun.SetActive(false);
                PlayerGun.SetActive(true);
                CommandKey.SetActive(false);
                Command.SetActive(false);
                Crosshair.gameObject.SetActive(true);
                Bullet1.gameObject.SetActive(true);
                Bullet2.gameObject.SetActive(true);
                Bullet3.gameObject.SetActive(true);
                Bullet4.gameObject.SetActive(true);
                Bullet5.gameObject.SetActive(true);
                Bullet6.gameObject.SetActive(true);
                Bullet7.gameObject.SetActive(true);
            }
        }
    }

    void OnMouseExit(){
        CommandKey.SetActive(false);
        Command.SetActive(false);
    }
}
