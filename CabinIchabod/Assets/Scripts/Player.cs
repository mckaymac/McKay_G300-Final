﻿using System.Collections;
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
    public Text Salt;
    public GameObject SaltObject;
    public Text Bone;
    public GameObject BoneObject;
    public Text Rock;
    public GameObject RockObject;
    // Start is called before the first frame update
    void Start()
    {
        goal = 0;
    }

    void Awake(){
        Rock = RockObject.GetComponent<Text>();
        Bone = BoneObject.GetComponent<Text>();
        Salt = SaltObject.GetComponent<Text>();
    }

    public void DecreaseHealth(float healthLoss){
        Health = Health - healthLoss;
        Hurt.Play();
        Debug.Log("Oof, that hurt");
        if(Health == 0){
            SceneManager.LoadScene("Game Over");
        }
    }

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
            //SceneManager.LoadScene("You Win");
        }

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit objectHit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out objectHit)){
            Distance = objectHit.distance;
            TargetDistance = Distance;
        }
        
    }
}
