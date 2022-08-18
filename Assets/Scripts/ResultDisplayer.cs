using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultDisplayer : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text resultText_;

    string winner;

    const string PlayerName = "Player(Clone)";
    const string EnemyName  = "Enemy(Clone)";

    // �v���C���[�ΓG���ǂ���
    bool isPvsC(List<Human> players) {
        bool flag = false;

        foreach(var w in players) {
            // Player���P�ł����X�g�ɍ������Ă�����true�ɂȂ�
            flag |= w.gameObject.name == PlayerName;   
        }

        return flag;
    }

    public void Display(List<Human> playerList, int result) {
        // ��\���ɂȂ��Ă��錋�ʕ\���G���A��\��������
        resultText_.gameObject.SetActive(true);

        // ���������̎�
        if(result == -1) {
            resultText_.text = "������";
            return;
        }

        string WinnerObjectName = playerList[result].gameObject.name;

        if (WinnerObjectName == PlayerName) {
            winner = "�L�~";
        }
        else
        if (WinnerObjectName == EnemyName) {
            winner = "����";
        }

        // �Gvs�G�������ꍇ�̒ǉ�����
        if (isPvsC(playerList) == false) {
            winner += "(" + (result + 1).ToString() + "�Ԗ�)";
        }

        // �o��
        resultText_.text = winner + "�̏���";
    }
}
