using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButton : MonoBehaviour
{
    private void Start() {
        // プレイヤーを検索して取得
        user_player_ = Resources.FindObjectsOfTypeAll<Player>()[0];
    }

    [SerializeField] Player user_player_;

    // このボタンを押したときに選択する手
    [SerializeField] EChoice output_choice;

    public void Pushed(){
        user_player_.SetChoice(output_choice);
    }
}
