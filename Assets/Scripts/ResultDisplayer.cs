using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultDisplayer : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text resultText_;

    string winner;

    const string PlayerName = "Player(Clone)";
    const string EnemyName  = "Enemy(Clone)";

    // プレイヤー対敵かどうか
    bool isPvsC(List<Human> players) {
        bool flag = false;

        foreach(var w in players) {
            // Playerが１つでもリストに混じっていたらtrueになる
            flag |= w.gameObject.name == PlayerName;   
        }

        return flag;
    }

    public void Display(List<Human> playerList, int result) {
        // 非表示になっている結果表示エリアを表示させる
        resultText_.gameObject.SetActive(true);

        // 引き分けの時
        if(result == -1) {
            resultText_.text = "あいこ";
            return;
        }

        string WinnerObjectName = playerList[result].gameObject.name;

        if (WinnerObjectName == PlayerName) {
            winner = "キミ";
        }
        else
        if (WinnerObjectName == EnemyName) {
            winner = "相手";
        }

        // 敵vs敵だった場合の追加処理
        if (isPvsC(playerList) == false) {
            winner += "(" + (result + 1).ToString() + "番目)";
        }

        // 出力
        resultText_.text = winner + "の勝ち";
    }
}
