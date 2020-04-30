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
    public GameObject BookOne;
    private Text BookTextOne;
    public GameObject BookTwo;
    private Text BookTextTwo;
    public GameObject BookThree;
    private Text BookTextThree;

    void Awake()
    {
        CommandKeyText = CommandKey.GetComponent<Text>();
        CommandText = Command.GetComponent<Text>();
        BookTextOne = BookOne.GetComponent<Text>();
        BookTextTwo = BookTwo.GetComponent<Text>();
        BookTextThree = BookThree.GetComponent<Text>();
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
                Timer = 0;
                CommandKey.SetActive(false);
                CommandText.text = "To send back those who mean you harm,";
                BookTextOne.text = "gather these items three:";
                BookTextTwo.text = "the bone of a holy man, salt,";
                BookTextThree.text ="and a stone blacker than night.";

            }
        }
    }

    void OnMouseExit(){
        CommandKey.SetActive(false);
        Command.SetActive(false);
    }
}
