using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleLike : MonoBehaviour
{
    [SerializeField] Text textarea;

    public void WriteLine(string line){
        // 挿入して改行
        textarea.text += line + "\n";
    }
}
