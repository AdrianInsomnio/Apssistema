using UnityEngine;
using System.Collections;

public class MoveOnPathScript : MonoBehaviour {

    public EditorPathScript PathFollow;
    public int nextWayPointID = 0;
    public float speed;
    private float reachDistance = 1.0f;
    public float rotationSpeed = 5.0f;
    public string pathName;
    Vector3 lastPosition, currentPosition;
    public bool isPingPong,closePath;
    public int MaxloopCount=1;
    int currentLoop=1;
    bool isIda = true;
    




	// Use this for initialization
	void Start () {
        //PathFollow = GameObject.Find(pathName).GetComponent<EditorPathScript>();
        lastPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (isPingPong || currentLoop <= MaxloopCount )
        {
            mover();
        }
    }
        
    void mover()
    {
        float distance = Vector3.Distance(PathFollow.path_objs[nextWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, PathFollow.path_objs[nextWayPointID].position, Time.deltaTime * speed);
        var rotation = Quaternion.LookRotation(PathFollow.path_objs[nextWayPointID].position - transform.position);
       
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        if (distance <= reachDistance)
        {
            //if ( (CurrentWayPointID < 0) && (isIda= false) && isPingPong)
            //{
            //    CurrentWayPointID = 0;
            //    isIda = true;
            //}

            if (isIda)
            {
                nextWayPointID++;
            }
            else
            {
                nextWayPointID--;
            }


            //currentLoop++;
        }
        if (nextWayPointID >= PathFollow.path_objs.Count)
        {
            //isIda = false;
            //if (!isPingPong)
            //{
            //    currentLoop++; Debug.Log("entra 01");
            //     isIda = false;

            //}
            //    else
            //    {
            //        CurrentWayPointID--; Debug.Log("entra --");
            //        if (CurrentWayPointID <0 )
            //        {
            //            isIda = true;
            //            CurrentWayPointID ++;
            //        }
            if (closePath) {
                nextWayPointID = 0;
            };
            if (isPingPong)
            {
                isIda = false;
                nextWayPointID = PathFollow.path_objs.Count;
            };
        }

        
    }
}

