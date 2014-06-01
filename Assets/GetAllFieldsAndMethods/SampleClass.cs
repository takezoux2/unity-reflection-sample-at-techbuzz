using UnityEngine;
using System.Collections;

public class SampleClass {

    public bool 真偽値 = false;

    public int intのフィールド = 23;

    public string 文字列フィールド = "文字列";

    private string privateなフィールド = "はgetFields()には含まれませんがGetField(name)で取得できます";

    public string publicプロパティ {
        get;
        set;
    }
    private string privateプロパティ {
        get;
        set;
    }

    public SampleClass(){
        publicプロパティ = "publicだよ";
        privateプロパティ = "privateだよ";
    }


    public string publicなメソッド(int 引数の名前も,bool とれます){
        Debug.Log ("publicなメソッドが呼ばれました");
        return "public";
    }

    private string privateなメソッド(int aa){
        Debug.Log ("は、GetMethods()に含まれませんが、GetMethod(name)で取得できます。");
        return "private";
    }

}
