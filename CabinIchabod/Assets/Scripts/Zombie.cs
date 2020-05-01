using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public GameObject PlayerGameObject;

    private Player PlayerObject;

    public Animator Animator;

    private bool Attacking = false;

    private float Health = 50.0f;

    private float Timer = 0.0f;

    public void DamageZombie(float damage){
        Health = Health - damage;

        if(Health <= 0.0f){
           
           // yield return new WaitForSeconds(25.0f);
            StartCoroutine(ZombieDeath());
        }
    }

    //Kill the zombie and trigger its animation
    IEnumerator ZombieDeath(){
        Animator.SetTrigger("Death");
        yield return new WaitForSeconds(1.2f);
        //Destroy code for the zombie   

    }

    //Attack player and trigger animation
    IEnumerator Attack(){
        Attacking = true;
        Animator.SetTrigger("Attack");
        PlayerObject.DecreaseHealth(10.0f);
        yield return new WaitForSeconds(1.2f);
        Attacking = false;
    }

    void Awake(){
        Animator = GetComponent<Animator>();
    }

    public void Initialize(Player player){
        PlayerObject = player;
    }

    // Update is called once per frame
    void Update()
    {
        //Measurue distance to player
        RaycastHit objectHit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out objectHit)){
            var distance = objectHit.distance;

            if(objectHit.transform.tag == "Player" && distance < 1.0 && Attacking == false){
                Animator.SetTrigger("Attack");
                StartCoroutine(Attack());
            }
        }

        var target = PlayerObject.transform.position;
        target.y = transform.position.y + (transform.lossyScale.y / 2);
        transform.LookAt(target);

        // var target = Player.transform.position;
        // target.y = transform.position.y;
        // var moveDirection = target - transform.position;

        // transform.LookAt(target);
        
    }
}
