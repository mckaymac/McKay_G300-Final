using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    private Animator Animator;
    private bool Firing = false;
    public GameObject MuzzleFlash;
    public GameObject Barrel;
    public AudioSource PistolShot;
    public AudioSource Reload;
    public AudioSource EmptyClick;
    public float Distance;
    public GameObject Player;
    // public GameObject CommandKey;
    // private Text CommandKeyText;
    // public GameObject Command;
    // private Text CommandText;
    private int ammo = 7;
    // public GameObject AmmoBox;
    private int extraAmmo = 35;
    private float Damage = 25.0f;
    // private bool flag = false;

    //The bullet images
    public Image Bullet1;
    public Image Bullet2;
    public Image Bullet3;
    public Image Bullet4;
    public Image Bullet5;
    public Image Bullet6;
    public Image Bullet7;
    private int totalAmmo;
    private int TotalAmmo;
    private bool flag = true;

    

    IEnumerator FirePistol(){

        RaycastHit objectShot;
            if(ammo > 0){
                ammo--;
                Firing = true;
                PistolShot.Play();
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out objectShot)){
                    objectShot.transform.SendMessage("DamageZombie", Damage, SendMessageOptions.DontRequireReceiver);
                }
                Animator.SetTrigger("Fire");
                var flash = Instantiate(MuzzleFlash, Barrel.transform.position, Barrel.transform.rotation);

                yield return new WaitForSeconds(1.0f);
                Destroy(flash);
                Firing = false;
            }
            else{
                EmptyClick.Play();
            }
        
    }

    IEnumerator ReloadGun(){
        if(flag == true){
            flag = false;
            Reload.Play();
            Bullet1.gameObject.SetActive(true);
            Bullet2.gameObject.SetActive(true);
            Bullet3.gameObject.SetActive(true);
            Bullet4.gameObject.SetActive(true);
            Bullet5.gameObject.SetActive(true);
            Bullet6.gameObject.SetActive(true);
            Bullet7.gameObject.SetActive(true);
            while(ammo < 7 && extraAmmo > 0){
                    ammo++;
                    extraAmmo--;
                }
        }
        yield return new WaitForSeconds(1.0f);
        flag = true;
        }

        

    // IEnumerator AmmoBoxInt(){
    //     if(flag == true){
    //         Animator.SetTrigger("Close");
    //         yield return new WaitForSeconds(2.0f);
    //         extraAmmo += 7;
    //         flag = false;
    //     }
    // }

    // void OnMouseOver(){
    //     if(Distance < 1){
    //         CommandKeyText.text = "[e]";
    //         CommandText.text = "Pick Up Ammo";
    //         CommandKey.SetActive(true);
    //         Command.SetActive(true);
            

    //         if(Input.GetButtonDown("Action")){
    //             StartCoroutine(AmmoBoxInt());
    //             CommandKey.SetActive(false);
    //             Command.SetActive(false);
    //             AmmoBox.SetActive(false);
    //             flag = true;
    //         }
    //     }
    //     else{
    //         CommandKey.SetActive(false);
    //         Command.SetActive(false);
    //     }
    // }
    void Awake(){
        Animator = GetComponent<Animator>();
    //     CommandKeyText = CommandKey.GetComponent<Text>();
    //     CommandText = Command.GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // RaycastHit objectHit;
        // if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out objectHit)){
        //     Distance = Player.TargetDistance;
        //     if(objectHit.transform.tag == "Ammo" && Distance < 1.0){
        //         Animator.SetTrigger("Close");
        //     }
        // }
        if(Input.GetButtonDown("Fire1")){
            StartCoroutine(FirePistol());
        }
        if(Input.GetButtonDown("Reload") && ammo <= 7){
            StartCoroutine(ReloadGun());
        }

        if(ammo == 6){
            Bullet1.gameObject.SetActive(false);
        }
        if(ammo == 5){
            Bullet2.gameObject.SetActive(false);
        }
        if(ammo == 4){
            Bullet3.gameObject.SetActive(false);
        }
        if(ammo == 3){
            Bullet4.gameObject.SetActive(false);
        }
        if(ammo == 2){
            Bullet5.gameObject.SetActive(false);
        }
        if(ammo == 1){
            Bullet6.gameObject.SetActive(false);
        }
        if(ammo == 0){
            Bullet7.gameObject.SetActive(false);
        }
    }
}
