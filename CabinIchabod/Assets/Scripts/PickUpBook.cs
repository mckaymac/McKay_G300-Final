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
    private float Timer;
    public GameObject Book;
    private Text BookText;

    void Awake()
    {
        CommandKeyText = CommandKey.GetComponent<Text>();
        CommandText = Command.GetComponent<Text>();
        BookText = Book.GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         Distance = Player.TargetDistance;
         if(Timer > 15.0f){
             CommandText.text = "";
         }
         Timer = Timer + Time.deltaTime;
    }

     void OnMouseOver(){
        if(Distance < 2){
            CommandKeyText.text = "[e]";
            CommandText.text = "Read Book";
            CommandKey.SetActive(true);
            Command.SetActive(true);

            if(Input.GetButtonDown("Action")){
                CommandKey.SetActive(false);
                Command.SetActive(false);
                Book.SetActive(true);


            }
        }
    }

    void OnMouseExit(){
        CommandKey.SetActive(false);
        Command.SetActive(false);
    }
}
