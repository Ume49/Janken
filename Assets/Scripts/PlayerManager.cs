using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject player_ui;
    [SerializeField] GameObject enemy_ui;
    
    [SerializeField] Transform ui_parent;

    // 現在処理しているプレイヤー
    Human currentPlayHuman;

    void Start() {
        StartHumanChoice();
    }

    void StartHumanChoice(){
        // 次のプレイヤーを取得
        var human = PlayersStock.players.Dequeue();
        // TODO: 空の時の処理

        GameObject instanceGameObject = null;

        // 種類に対応したUIを追加
        switch(human.kind){
            case Human.Kind.Player:
                instanceGameObject = (GameObject)Instantiate(player_ui, player_ui.transform);
                break;
            case Human.Kind.Enemy:
                instanceGameObject = (GameObject)Instantiate(enemy_ui, enemy_ui.transform);
                break;
        }

        // 追加したUIを子要素として登録
        instanceGameObject.transform.parent = ui_parent;

        // 手を選ぶ処理をするため登録
        currentPlayHuman = human;
    }

    void Update(){
        EChoice result;

        if(currentPlayHuman.Choice(out result)){
            // TODO: 結果を格納

            StartHumanChoice();

            // TODO: 手を全部決めたら勝敗判定
        }
    }
}
