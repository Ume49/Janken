using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultDisplayer : MonoBehaviour
{
    // 0 勝ち
    // 1 負け
    // 2 引き分け
    [SerializeField] string[] resultMessageCandidate_ = new string[3];

    // 列挙型の結果を渡すとそれに応じたメッセージを表示する
    public void Display(EResult result){
        GetComponent<Text>().text = resultMessageCandidate_[(int)result];
    }
}
