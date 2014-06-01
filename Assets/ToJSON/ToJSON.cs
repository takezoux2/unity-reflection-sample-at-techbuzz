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
//        var user = new User ();
//        user.name = "Unityちゃん";
//        user.age = 1;
//        user.role = 2;
//        user.temporaryCounter = 23232;
//        json = JSonize (user);


        var u = Deserialize<User> (@"
   {""name"" : ""hoge"",""age"" : 5}");



        json = JSonize (u);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI(){
        GUI.skin.label.fontSize = 30;
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


    public T Deserialize<T>(string json){
    
        var d = MiniJSON.Json.Deserialize (json) as System.Collections.IDictionary;

        Type clazz = typeof(T);

        var constructor = clazz.GetConstructor (new Type[0]);

        T instance = (T)constructor.Invoke (new object[0]);


        foreach (var f in clazz.GetFields()) {

            if (d.Contains (f.Name)) {
                var value = d [f.Name];

                // string,long,bool,double

                if (f.FieldType == typeof(int)) {
                    f.SetValue (instance, (int)(long)value);
                } else if (f.FieldType == typeof(string)) {
                    f.SetValue (instance, value);
                } else if (f.FieldType == typeof(long)) {
                    f.SetValue (instance, value);
                } else {
                    throw new Exception ("Not supported");
                }





            }

        }

        return instance;


    }



    bool HasIgnoreAttribute(FieldInfo f){

        return f.GetCustomAttributes (typeof(IgnoreAttribute), true).Length > 0;
    }



}

