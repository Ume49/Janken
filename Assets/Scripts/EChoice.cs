using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// じゃんけんの手
// 次のやつが前のやつに勝てる順番
public enum EChoice : int{
    Rock,
    Paper,
    Scisors,
    length
}

// じゃんけんの勝敗を判定する関数
public class Choice_Judge{
    // -1 : 引き分け
    // それ以外 choice_数字 の勝った方の数字を返す
    static public int Judge(EChoice choice_0, EChoice choice_1){
        
        // 引き分け
        if(choice_0 == choice_1) return -1;

        // choice_0 の「次のやつ」を計算
        // Scissors + 1 = Rockとなるようにループの考慮もする
        EChoice next_0 = (EChoice)((int)(choice_0 + 1)%(int)EChoice.length);

        if (choice_1 == next_0){
            // 列挙型の定義より、一致してたらchoice_1の勝利
            return 1;
        }
        else{
            // 残るのはchoice_0の勝利しかない
            return 0;
        }
    }
}