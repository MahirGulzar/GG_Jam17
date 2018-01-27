using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageOnAir : MonoBehaviour {

    //public Vector3 Origin;



    //private Vector3 currentChosen;
    //private Vector3 previousPositon;
    //private float t;
    //private float currentSpeed;

    [HideInInspector]
    public Vector3[] waypointArray;
    float percentsPerSecond = 0.1f; // %2 of the path moved per second
    float currentPathPercent = 0.0f; //min 0, max 1

    bool Dragged = false;
    bool DragEnded = false;
    private Vector3 initPoint;
    Vector3 direction;

    private void OnEnable()
    {

        GetWayPoints();
    }


    //private void Update()
    //{
    //    if (!Input.GetMouseButtonDown(0))
    //    {
    //        if (transform.position != currentChosen)
    //        {
    //            transform.position = Vector3.MoveTowards(transform.position, currentChosen, currentSpeed*Time.deltaTime);
    //            //t += currentSpeed;
    //        }
    //        else
    //        {
    //            GetPosition();
    //        }

    //    }
    //}



    //private void GetPosition()
    //{
    //    print("called ..");
    //    t = 0;
    //    currentSpeed = Random.Range(1f, 0.5f);
    //    previousPositon = this.transform.position;
    //    currentChosen = new Vector3(Mathf.Clamp(transform.position.x + Random.Range(-5f, 5f), - 7,7), Mathf.Clamp(transform.position.x + Random.Range(-5f, 5f) ,- 4, 4), 0);
    //    print(currentChosen);

    //}


    

    void Update()
    {

        if (!Dragged)
        {
            if (currentPathPercent < 1)
            {
                currentPathPercent += percentsPerSecond * Time.deltaTime;
                iTween.PutOnPath(gameObject, waypointArray, currentPathPercent);
            }
            else
            {
                GetWayPoints();
            }

        }
        else
        {
            if(DragEnded)
            {
                transform.position += direction * 0.4f * Time.deltaTime;
            }
        }
    }

    private void GetWayPoints()
    {
        //print("called ..");
        percentsPerSecond = Random.Range(0.1f, 0.12f);
        currentPathPercent = 0; 
        int size = 10;
        waypointArray = new Vector3[size];
        Vector3 previousPositon = this.transform.position;
        Vector3 currentChosen;
        waypointArray[0] = previousPositon;
        for (int i=1;i<size;i++)
        {
            
            currentChosen = new Vector3(Mathf.Clamp(previousPositon.x + Random.Range(-5f, 5f), -7f, 7), Mathf.Clamp(previousPositon.x + Random.Range(-5f, 5f), -3.5f, 3.5f), 0);
            waypointArray[i] = currentChosen;
        }
        

    }



    //-------------------------

    public void OnDrag()
    {
        Dragged = true;
        if(initPoint==null)
        {
            initPoint = this.transform.position;
        }
    }


    public void OnDragEnd()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition)-initPoint;
        direction = new Vector3(direction.x, direction.y, 0);

        DragEnded = true;
    }

}
