using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�� ���� ����� ����ϰڴ�. ScenManagement ������ ���

public class UIManager : MonoBehaviour // MonoBehaviour�� ����Ƽ�� ����� �ҷ����ڴ�. (���۳�Ʈ �ҷ����� ��)
{
    public void PlayGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR //��ó���� (�������� �̸� ����� ������ ����.)
        UnityEditor.EditorApplication.isPlaying = false; //����Ƽ���� �������� ���¿��� ����
#else //���忡�� ���� (exe���� �����ε�)
        Application.Quit();
#endif
    }
}
