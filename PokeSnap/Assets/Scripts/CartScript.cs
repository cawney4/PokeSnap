using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CartScript : MonoBehaviour {
    //Vector3[] path = { new Vector3(1, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 0, 0) };
    private Transform[] waypointArray;
    private int numPoints = 49;
    float percentsPerSecond = 0.01f; // %2 of the path moved per second
    float currentPathPercent = 0.0f; //min 0, max 1

    
// Use this for initialization
void Start () {
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
        if (currentPathPercent > 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
		Vector3 point2 = iTween.PointOnPath(waypointArray, currentPathPercent + 0.05f);
		Vector3 direction = new Vector3((int) point2.x, (int) point2.y, (int) point2.z);
		iTween.LookTo(gameObject,iTween.Hash("looktarget", direction, "easetype", iTween.EaseType.easeOutBack,"time", 3f));

    }

    /*
    void OnDrawGizmos()
    {
        //Visual. Not used in movement
        iTween.DrawPath(waypointArray);
    }
    */
    
}
