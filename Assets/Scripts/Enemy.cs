using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Human
{
    private void Awake() {
        kind = Kind.Enemy;
    }

    override public bool Choice(out EChoice result){
        // 結果をランダムに決定
        result = (EChoice)Random.Range(0, 2);

        // 何を出すか決めたのでtrue
        return true;
    }
}
