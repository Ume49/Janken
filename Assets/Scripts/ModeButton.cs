using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeButton : MonoBehaviour
{
    [SerializeField] GameObject[] players_;

    // ボタンを押したときの処理
    // プレイヤーを登録する、あとインスタンス生成する
    public void Pushed(){
        List<Human> playerComponents = new List<Human>();

        foreach(var w in players_){
            var instanceObject = (GameObject)Instantiate(w, Vector3.zero, Quaternion.identity);

            // シーン遷移で消えると困るので
            DontDestroyOnLoad(instanceObject);
            // !! Mainシーン終了時に必ず消す

            playerComponents.Add(instanceObject.GetComponent<Human>());            
        }

        // 対戦プレイヤーを登録
        foreach(var w in playerComponents){
            PlayersStock.players.Enqueue(w);
        }

        // このシーンでやることはボタンを押すだけなのでシーンチェンジ
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}
