using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Human : MonoBehaviour
{
    public enum Kind{
        Player,
        Enemy
    }

    public Kind kind;

    // 結果が決まったらtrue、決まってないならfalse
    public abstract bool Choice(out EChoice choice);
}
