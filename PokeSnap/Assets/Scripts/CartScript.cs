using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartScript : MonoBehaviour {
    //Vector3[] path = { new Vector3(1, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 0, 0) };
    private Transform[] waypointArray;
    private int numPoints = 49;
    float percentsPerSecond = 0.01f; // %2 of the path moved per second
    float currentPathPercent = 0.0f; //min 0, max 1

    private bool gameOver = false;

    
// Use this for initialization
void Start () {
        //iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
        //iTween.PutOnPath(gameObject, path, 100);
        //GameObject[] list = GameObject.FindGameObjectsWithTag("Path");
        //list.
        waypointArray = new Transform[numPoints];
        for (int i = 1; i<numPoints + 1; i++)
        {
            waypointArray[i - 1] = GameObject.Find("Point" + i).transform;
        }

    }
	
	// Update is called once per frame
	void Update () {
        currentPathPercent += percentsPerSecond * Time.deltaTime;
		iTween.PutOnPath(gameObject, waypointArray, currentPathPercent);
        if (currentPathPercent > 100)
        {
            gameOver = true;
            // Load next scene?
        }
		Vector3 point2 = iTween.PointOnPath(waypointArray, currentPathPercent + 0.1f);

		Debug.Log (point2.x);
		Vector3 direction = new Vector3((int) point2.x, (int) point2.y, (int) point2.z);
		iTween.RotateTo(gameObject,iTween.Hash("rotation", direction, "easetype", iTween.EaseType.easeInOutSine,"time", 1f));

    }

    /*
    void OnDrawGizmos()
    {
        //Visual. Not used in movement
        iTween.DrawPath(waypointArray);
    }
    */
    
}
