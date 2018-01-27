using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    bool move = false;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        Vector3 viewPosition = Camera.main.WorldToViewportPoint(player.transform.position);

        if (viewPosition.x > 0.6f && !move) // move right
        {
            //print("move right...");
            move = true;
            offset = transform.position - player.transform.position;
        }
        else if (viewPosition.x < 0.2f && !move )  // move left
        {
            //print("move left...");
            move = true;
            offset = transform.position - player.transform.position;
        }
        else if(!player.GetComponent<Animator>().GetBool("Move"))
        {
            move = false;
        }
    }






    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        

        if(move && !player.GetComponent<CharacterScript>().flipped && player.GetComponent<Animator>().GetBool("Move"))
            transform.position = new Vector3(player.transform.position.x + offset.x+0.1f, player.transform.position.y+ offset.y,-10);
        else if (move && player.GetComponent<CharacterScript>().flipped && player.GetComponent<Animator>().GetBool("Move"))
            transform.position = new Vector3(player.transform.position.x + offset.x - 0.1f, player.transform.position.y + offset.y, -10);









        // Clamp camera on x-axis

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0, 200), transform.position.y, -10);





    }
}
