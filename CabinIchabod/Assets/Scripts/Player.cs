using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static float TargetDistance;

    private float Health = 100.0f;

    public float Distance;

    public AudioSource Hurt;
    private int goal;
    public GameObject SaltObject;
    public GameObject BoneObject;
    public GameObject RockObject;
    // Start is called before the first frame update
    void Start()
    {
        goal = 0;
    }

    //Decrease hp when hit by zombies
    public void DecreaseHealth(float healthLoss){
        Health = Health - healthLoss;
        Hurt.Play();
        Debug.Log("Oof, that hurt");
        if(Health == 0){
            SceneManager.LoadScene("Game Over");
        }
    }

    //Act as the gate for completing the game
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Salt")){
            goal++;
            other.gameObject.SetActive(false);
            SaltObject.SetActive(true);
        }

        if(other.gameObject.CompareTag("Bone")){
            goal++;
            other.gameObject.SetActive(false);
            BoneObject.SetActive(true);
        }

        if(other.gameObject.CompareTag("Rock")){
            goal++;
            other.gameObject.SetActive(false);
            RockObject.SetActive(true);
        }

        if(other.gameObject.CompareTag("Goal") && (goal == 3)){
            SceneManager.LoadScene("Victory");
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Measure distance from player to object
        RaycastHit objectHit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out objectHit)){
            Distance = objectHit.distance;
            TargetDistance = Distance;
        }

        //Quit the game 
        if(Input.GetKey("escape")){
            Application.Quit();
        }
        
    }
}
