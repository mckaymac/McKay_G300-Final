using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Ammo : MonoBehaviour
{
    public GameObject CommandKey;
    private Text CommandKeyText;
    public GameObject Command;
    private Text CommandText;
    private int ammo = 7;
    public GameObject AmmoBox;
    private int extraAmmo = 0;
    private float Damage = 25.0f;
    private bool flag = true;
    public float Distance;
    public AudioSource OpenNoise;

    //public Pistol extraAmmo;

    void OnMouseOver(){

        if(Distance < 2){

            CommandKeyText.text = "[e]";
            CommandText.text = "Pick Up Ammo";
            CommandKey.SetActive(true);
            Command.SetActive(true);

            if(Input.GetButtonDown("Action")){
                StartCoroutine(AmmoBoxInt());
                CommandKey.SetActive(false);
                Command.SetActive(false);                
            }
        }
    }

     void OnMouseExit(){
        CommandKey.SetActive(false);
        Command.SetActive(false);
    }
    
    void Awake(){
        Animator = GetComponent<Animator>();
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
        RaycastHit objectHit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out objectHit)){
            Distance = Player.TargetDistance;
        }
    }
}
