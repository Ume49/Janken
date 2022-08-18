using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Human
{
    // 手を決定し終わっているか
    public bool isDecided_ = false;

    public override bool Choice()
    {   Debug.Log("Player.Choice()");
        
        if(isDecided_ == true)
        {
            DisplayChoice();

            _result_text.gameObject.SetActive(true);
            
            // ボタンを非表示にする
            // 兄弟関係にあるオブジェクトから無理やり参照する
            _result_text.gameObject.transform.parent.GetChild(1).gameObject.SetActive(false);

            return true;
        }
        return false;
    }

    public void SetChoice(EChoice choice){ Debug.Log("Player.SetChoice(choice)");
        _choice = choice;

        // 手を決定したので変更
        isDecided_ = true;
    }
}
