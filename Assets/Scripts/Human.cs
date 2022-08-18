using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Human : MonoBehaviour
{
    // 表示したいGUI
    [SerializeField] GameObject _gui;
    // なんの手を選んだのか表示するTextコンポーネント
    [SerializeField] protected Text _result_text;

    // parentには配置するGUIの親にするオブジェクトを渡す
    public void Display(GameObject parent){
        // 親を設定してプレファブを追加
        var instance = Instantiate(_gui, parent.transform);

        // ついでにresult_textも取得しておく
        // GUIのPrefabの親子関係から取得
        _result_text = instance.transform.GetChild(0).GetComponent<Text>();
    }

    // このプレイヤーが決めたじゃんけんの手
    public EChoice _choice{
        get;
        protected set;
    }

    // 結果が決まったらtrue、決まってないならfalse
    public abstract bool Choice();

    // なんの手を選んだのか表示
    public void DisplayChoice()
    {
        // EChoiceを日本語にする
        // *本当はToStringをいじりたかった
        string choice_japan="";
        
        switch (_choice)
        {
            case EChoice.Rock:
                choice_japan = "グー";
                break;
            case EChoice.Paper:
                choice_japan = "パー";
                break;
            case EChoice.Scisors:
                choice_japan = "チョキ";
                break;
        }

        _result_text.text = choice_japan;
    }
}
