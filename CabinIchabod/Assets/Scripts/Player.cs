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
    private Text Salt;
    public GameObject SaltObject;
    private Text Bone;
    public GameObject BoneObject;
    private Text Rock;
    public GameObject RockObject;
    // Start is called before the first frame update
    void Start()
    {
        goal = 0;
    }

    public void DecreaseHealth(float healthLoss){
        Health = Health - healthLoss;
        Hurt.Play();
        Debug.Log("Oof, that hurt");
        if(Health == 0){
            SceneManager.LoadScene("Game Over");
        }
    }

    void OnCollisionEnter(Collider other){
        if(other.gameObject.CompareTag("Salt")){
            other.gameObject.SetActive(false);
            //add text
        }

        if(other.gameObject.CompareTag("Bone")){
            other.gameObject.SetActive(false);

        }

        if(other.gameObject.CompareTag("Rock")){
            other.gameObject.SetActive(false);

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
