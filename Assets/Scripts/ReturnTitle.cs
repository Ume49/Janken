using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTitle : MonoBehaviour
{
    public void Pushed(){
        // 一番最初のシーンに戻る
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
