using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class PickUpBook: MonoBehaviour
{
    public float Distance;
    public GameObject CommandKey;
    private Text CommandKeyText;
    public GameObject Command;
    private Text CommandText;
    public GameObject Item;
    private int Timer;

    void Awake()
    {
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
         if(Timer > 15){
             CommandText.text = "";
         }
    }

     void OnMouseOver(){
        if(Distance < 2){
            CommandKeyText.text = "[e]";
            CommandText.text = "Read Book";
            CommandKey.SetActive(true);
            Command.SetActive(true);

            if(Input.GetButtonDown("Action")){
                Timer = 0;
                CommandKey.SetActive(false);
                CommandText.text = "To send back those who mean you harm, gather these items three: the bone of a holy man, salt, and a stone blacker than night.";

            }
        }
    }

    void OnMouseExit(){
        CommandKey.SetActive(false);
        Command.SetActive(false);
    }
}
