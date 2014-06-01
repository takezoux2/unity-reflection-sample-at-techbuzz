using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

public class GetAllFieldsAndMethods : MonoBehaviour {

    SampleClass sampleClass;

    void Awake(){
        sampleClass = new SampleClass ();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    }
    void OnGUI()
    {
        GUI.skin.label.fontSize = 20;
        // インスタンスのTypeを取得
        Type clazz = sampleClass.GetType ();

        GUILayout.Label ("クラス:" + clazz.FullName);
        GUILayout.Label ("---------- フィールド -----------------");
        foreach (FieldInfo f in clazz.GetFields()) {

            string fieldType = f.FieldType.Name;
            string fieldName = f.Name;
            object value = f.GetValue (sampleClass); // フィールドの値を取得



            GUILayout.Label (string.Format ("{0} {1} = {2}", fieldType, fieldName, value));

        }

        // メソッド、プロパティの列挙を実装します。

        foreach (var m in clazz.GetMethods()) {
            var name = m.Name;
            var returnType = m.ReturnType.Name;

            string[] args = new string[m.GetParameters().Length];
            for (int i = 0; i < args.Length; i++) {
                ParameterInfo param = m.GetParameters ()[i];
                args [i] = param.ParameterType.Name + " " + param.Name;
            }

            GUILayout.Label (string.Format ("{0} {1}({2})", returnType, name, string.Join (",", args)));


        }


    }

//
//    void Hoge(){
//        // iOSでは、プロパティからの取得を行おうとするとエラーになります。
//        GUILayout.Label ("---------- プロパティ -----------------");
//
//        foreach (var p in clazz.GetProperties()) {
//            string propType = p.PropertyType.Name;
//            string propName = p.Name;
//            p.GetGetMethod ();
//            p.GetSetMethod ();
//            object value = p.GetGetMethod ().Invoke (sampleClass, new object[0]);
//            // 下の取得方法だと、iOSで実行時例外がでてしまいます。
//            //object value = p.GetValue(sampleClass,new object[0]);
//            GUILayout.Label (string.Format ("{0} {1} = {2}", propType, propName, value));
//        }
//
//
//        GUILayout.Label ("---------- メソッド -----------------");
//        //メソッドの列挙
//        foreach (MethodInfo m in clazz.GetMethods()) {
//
//            string returnType = m.ReturnType.Name;
//            string methodName = m.Name;
//            string[] args = new string[m.GetParameters().Length];
//            for (int i = 0; i < args.Length; i++) {
//                var param = m.GetParameters ()[i];
//                args [i] = param.ParameterType.Name + " " + param.Name;
//            }
//
//            GUILayout.Label (string.Format ("{0} {1}({2})", returnType, methodName, string.Join (",", args)));
//
//        }
//
//
//
//        GUILayout.Label ("----------- Privateなフィールドの取得 --------------");
//
//        {
//            // BindingFlagsを正しく渡してあげると取得できます。
//            var f = clazz.GetField ("privateなフィールド", BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance);
//            GUILayout.Label (string.Format ("{0} {1} = {2}", f.FieldType.Name, f.Name, f.GetValue (sampleClass)));
//        }
//
//
//	}





}
