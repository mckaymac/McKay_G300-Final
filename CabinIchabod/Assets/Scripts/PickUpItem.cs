using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public float Distance;
    public GameObject CommandKey;
    private Text CommandKeyText;
    public GameObject Command;
    private Text CommandText;
    public GameObject Item;

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
    }

     void OnMouseOver(){
        if(Distance < 2){
            CommandKeyText.text = "[e]";
            CommandText.text = "Pick Up Item";
            CommandKey.SetActive(true);
            Command.SetActive(true);

            if(Input.GetButtonDown("Action")){
                Item.SetActive(false);
                CommandKey.SetActive(false);
                CommandText.text = "You picked up the item!";

            }
        }
    }

    void OnMouseExit(){
        CommandKey.SetActive(false);
        Command.SetActive(false);
    }
}
