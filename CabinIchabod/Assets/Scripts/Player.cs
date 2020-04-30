using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static float TargetDistance;

    private float Health = 100.0f;

    public float Distance;

    public AudioSource Hurt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DecreaseHealth(float healthLoss){
        Health = Health - healthLoss;
        Hurt.Play();
        Debug.Log("Oof, that hurt");
        if(Health == 0){
            SceneManager.LoadScene("Game Over");
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
