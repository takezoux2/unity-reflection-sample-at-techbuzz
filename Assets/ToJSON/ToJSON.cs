using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;

public class ToJSON : MonoBehaviour {

    string json = "";

	// Use this for initialization
	void Start () {
        var user = new User ();
        user.name = "Unityちゃん";
        user.age = 1;
        user.role = 2;
        user.temporaryCounter = 23232;
        json = JSonize (user);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI(){
        GUILayout.Label (json);
    }

    string JSonize( object obj){

        var json = new Dictionary<string,object> ();

        foreach (var f in obj.GetType().GetFields()) {

            if (HasIgnoreAttribute (f)) {
                Debug.Log ("Field:" + f.Name + " is ignored");
                continue;
            }

            json.Add (f.Name, f.GetValue (obj));
        }

        return MiniJSON.Json.Serialize (json);
    }

    bool HasIgnoreAttribute(FieldInfo f){
        return f.GetCustomAttributes (typeof(IgnoreAttribute), true).Length > 0;
    }



}

