using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotScript : MonoBehaviour {

    // Screenshot area and its border
    Texture2D screenCap;
    Texture2D border;
    bool shot = false;
    private int borderWidth = Screen.width / 2;
    private int borderHeight = Screen.height / 2;
    private int borderThickness = 5;
    List<Texture2D> screenshotList = new List<Texture2D>();

    // Display number of pictures
    int maxPics = 100;
    public GameObject numPicTextObject;
    Text numPicText;

    // Use this for initialization
    void Start () {
        screenCap = new Texture2D(borderWidth, borderHeight, TextureFormat.RGB24, false);
        border = new Texture2D(2, 2, TextureFormat.ARGB32, false);
        border.Apply();

        numPicText = numPicTextObject.GetComponent<Text>();
        updatePicCount();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (screenshotList.Count < maxPics)
            {
                StartCoroutine("Capture");
            }
        }
    }

    void OnGUI()
    {
        // Draw border of picture area
        GUI.DrawTexture(new Rect((Screen.width / 2) - (borderWidth / 2), (Screen.height / 2) - (borderHeight / 2), borderWidth, borderThickness), border, ScaleMode.StretchToFill); //top
        GUI.DrawTexture(new Rect((Screen.width / 2) - (borderWidth / 2), (Screen.height / 2) - (borderHeight / 2), borderThickness, borderHeight), border, ScaleMode.StretchToFill); //left
        GUI.DrawTexture(new Rect((Screen.width / 2) - (borderWidth / 2), (Screen.height / 2) + (borderHeight / 2), borderWidth, borderThickness), border, ScaleMode.StretchToFill); //bottom
        GUI.DrawTexture(new Rect((Screen.width / 2) + (borderWidth / 2), (Screen.height / 2) - (borderHeight / 2), borderThickness, borderHeight + borderThickness), border, ScaleMode.StretchToFill); //right

        if (shot)
        {
            GUI.DrawTexture(new Rect(30, 50, Screen.width / 10, Screen.height / 10), screenCap, ScaleMode.ScaleToFit);
        }
    }

    IEnumerator Capture()
    {
        yield return new WaitForEndOfFrame();
        screenCap.ReadPixels(new Rect((Screen.width / 2) - (borderWidth / 2), (Screen.height / 2) - (borderHeight / 2), borderWidth + 2 * borderThickness, borderHeight + 2 * borderThickness), 0, 0);
        screenCap.Apply();
        shot = true;
        screenshotList.Add(Instantiate(screenCap));
        updatePicCount();
    }

    void updatePicCount()
    {
        numPicText.text = screenshotList.Count + " / 100";
    }
}
