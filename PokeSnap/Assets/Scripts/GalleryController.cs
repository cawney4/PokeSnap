using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryController : MonoBehaviour {

    public GameObject image;
    private int imageWidth = Screen.width / 2;
    private int imageHeight = Screen.height / 2;

    private int index = 0;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            
            if (index < GameController.screenshotList.Count - 1)
            {
                index += 1;
            }
        } else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (index > 0)
            {
                index -= 1;
            }
        }
        
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect((Screen.width / 2) - (imageWidth / 2), (Screen.height / 2) - (imageHeight / 2), imageWidth, imageHeight), GameController.screenshotList[index], ScaleMode.ScaleToFit);
    }
}
