using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}


    void OnGUI(){
    
        GUILayout.BeginVertical ();

        if (GUILayout.Button ("フィールドとメソッドの列挙")) {

            Application.LoadLevel ("GetAllFieldsAndMethods");

        }


        if (GUILayout.Button ("フィールドやメソッドの列挙")) {

            Application.LoadLevel ("SendMessageLike");

        }

        if (GUILayout.Button ("JSON化")) {

            Application.LoadLevel ("ToJSON");

        }
    }


}
