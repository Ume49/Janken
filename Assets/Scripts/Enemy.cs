using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Human
{
    override public bool Choice(){ Debug.Log("Enemy.Choice()");
        // 結果をランダムに決定
        _choice = (EChoice)Random.Range(0, 2);

        DisplayChoice();

        // 何を出すか決めたのでtrue
        return true;
    }
}
