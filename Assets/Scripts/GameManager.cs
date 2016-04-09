using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	//Water and speed
	public int water = 0;  
	private int speed = 0;

	//GUI
	public Font newFont;   
	private int fontSize;
	bool isMenuOn = false;

	public Texture2D Tex0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F1)){
			isMenuOn = true;
		}
		if(Input.GetKeyDown(KeyCode.F2)){
			isMenuOn = false;
		}
		if(isMenuOn == true){
			if(Input.GetKeyDown(KeyCode.Space)){
				Application.LoadLevel (0);
			}
			if(Input.GetKeyDown(KeyCode.Q)){
				//End game
			}
		}
	}
	void OnGUI(){
		GUIStyle nStyle = new GUIStyle ();
		nStyle.font = newFont;
		nStyle.normal.textColor = new Color(0,100,255);
	
		if(isMenuOn == true){
			nStyle.normal.background = Tex0;
			nStyle.fontSize = 60;
			GUI.Box(new Rect(0,0,Screen.width,Screen.height), "Menu",nStyle);
			nStyle.normal.background = null;
			nStyle.fontSize = 26;
			GUI.Label (new Rect (0, Screen.height-30, 200, 200), "Press SPACE to restart: " , nStyle);
			GUI.Label (new Rect (Screen.width-200, 10, 200, 200), "Press Q to quit: " , nStyle);

	}
		if(isMenuOn == false){
			nStyle.normal.textColor = new Color(0,100,255);
			nStyle.fontSize = 26;
			GUI.TextField (new Rect (Screen.width-200, 10, 200, 200), "Water: "+water+ " l.", nStyle);
			nStyle.normal.textColor = new Color(255,255,0);
			nStyle.fontSize = 25;
			GUI.TextField (new Rect (0, Screen.height-30, 200, 200), "Speed: " + speed + " km/h", nStyle);
		}
	}
}
