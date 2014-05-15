using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

public class SendMessageLike : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    string methodName = "";
    string args = "";

    string result = "";
    void OnGUI(){
        GUILayout.Label ("MonoBehaviour#SendMessageみたいな機能を作ってみる");

        GUILayout.BeginHorizontal ();
        GUILayout.Label ("メソッド名");
        methodName = GUILayout.TextField (methodName);
        GUILayout.EndHorizontal ();
        GUILayout.BeginHorizontal ();
        GUILayout.Label ("引数");
        args = GUILayout.TextField (args);
        GUILayout.EndHorizontal ();

        if (GUILayout.Button ("実行")) {
            MySendMessage (methodName, args.Split(','));
        }

        GUILayout.Label ("-----------------------------");
        GUILayout.Label (result);

    }

    public void MySendMessage(string methodName, string[] args){
        try{

            // 名前でメソッドを探してくる
            MethodInfo method = FindMethodByName(methodName);
            if(method == null){
                result = "メソッドが見つかりません";
                return;
            }
            if(method.GetParameters().Length != args.Length){
                result = "引数の個数が一致しません";
                return;
            }

            // 引数の型を合わせる
            object[] passArgs = new object[method.GetParameters().Length];
            for(int i = 0;i < method.GetParameters().Length;i++){
            
                var paramType = method.GetParameters()[i].ParameterType;

                //今回は手抜きでIntとstringだけ
                if(paramType == typeof(string)){
                    passArgs[i] = args[i];
                }else if(paramType == typeof(int)){
                    passArgs[i] = int.Parse(args[i]);
                }else{
                    result = "引数の型変換に失敗しました。";
                }
            }

            // メソッドを呼び出す

            object returnValue = method.Invoke(this,passArgs);
            result = "呼び出し成功:" + returnValue;

        }catch(Exception e){
            result = e.Message;
        }
    }

    MethodInfo FindMethodByName(string methodName){
        var methods = GetType().GetMethods();
        foreach(var m in methods)
        {
            if(m.Name == methodName){
                return m;
            }
        }
        return null;
    }

    public void ShowMessage(string message){
        Debug.Log (message);
    }

    public int Add(int a,int b){
        return a + b;
    }

    public void Move(int x,int y ,int z){
        transform.localPosition += new Vector3 (x, y, z);
    }

    public void Rotate(int x,int y , int z){
        transform.localEulerAngles +=  new Vector3 (x, y, z);
    }



}
