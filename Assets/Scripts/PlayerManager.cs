using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // 対戦プレイヤー
    List<Human> players_;

    // 現在処理しているプレイヤーを指し示すインデックス
    int current_player_index_ = -1;

    // プレイヤーのGUIを表示する上で親に設定させるオブジェクト
    [SerializeField] GameObject gui_parent_;

    // 結果を表示する
    [SerializeField] ResultDisplayer resultDisplayer_;

    void Awake(){
        players_ = new List<Human>();
    }

    void Start() {
        StartHumanChoice();
    }

    void StartHumanChoice(){ Debug.Log("PlayerManager.StartHumanChoice()");
        // 次のプレイヤーを取得
        players_.Add(PlayersStock.players.Dequeue());
        current_player_index_++;

        // ユーザーに現在プレイヤーの判定をしていることを通知するGUIを表示させる
        players_[current_player_index_].Display(gui_parent_);
    }

    void Update(){
        if(players_[current_player_index_].Choice()){
            if(PlayersStock.players.Count > 0){
                // まだプレイヤーが残っているなら取得して手の判定をさせる
                StartHumanChoice();
                return;
            }

            // 手を全部決めたら勝敗判定
            int result = Choice_Judge.Judge(players_[0]._choice, players_[1]._choice);

            // 結果表示
            resultDisplayer_.Display(players_, result);

            // DontDestroyOnなんとかに設定されているプレイヤーたちを削除
            // *List<T>の挙動を完全に把握してるわけではないので一応ケツから消す
            Destroy(players_[1].gameObject);
            Destroy(players_[0].gameObject);

            // このコンポーネントを削除してUpdateを呼ばれないようにする
            Destroy(this);
        }
    }
}
