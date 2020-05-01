using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateZombie : MonoBehaviour
{
    private ZombieFactory Factory;
    //public GameObject Player;
    private static float SpawnTime = 1.0f;

    public float Timer;

    void Awake(){
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Timer = 0;
        Factory = ZombieFactory.Instance;
        Factory.CreateZombie();
    }

    // Update is called once per frame
    void Update()
    {
       Timer = Timer + Time.deltaTime; 
       if(Timer > SpawnTime){
           Factory.CreateZombieRandom();
           Timer = 0;
       }
    }
}
