using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class CharacterScript : MonoBehaviour {

    Animator anim;
    SkeletonAnimation skeletonAnimation;
    public EventHandler eventHandler;

    public bool flipped = false;
    float speed=1.8f;
    float initX;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        initX = transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.D))
        {
            flipped = false;
            this.transform.rotation = Quaternion.Euler(transform.rotation.x, 0, 0);
            anim.SetBool("Move", true);
            
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            flipped = true;
            this.transform.rotation = Quaternion.Euler(transform.rotation.x, 180, 0);
            anim.SetBool("Move", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("Move", false);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("Move", false);
        }



        // Movement


        if(anim.GetBool("Move"))
        {
            if(!flipped)
                transform.position += Vector3.right* speed * Time.deltaTime;
            else
                transform.position += Vector3.left * speed * Time.deltaTime;
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, initX, 195), transform.position.y, transform.position.z);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("yeess.. here..");
        Destroy(collision.gameObject.GetComponent<Collider2D>());
        eventHandler.DoPrompt();
    }
}
