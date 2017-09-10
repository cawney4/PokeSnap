using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    static public List<Texture2D> screenshotList = new List<Texture2D>(); //static because end scene needs access

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(transform.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
