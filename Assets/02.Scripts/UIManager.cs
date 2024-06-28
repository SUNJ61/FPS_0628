using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬 관련 기능을 사용하겠다. ScenManagement 생략을 명시

public class UIManager : MonoBehaviour // MonoBehaviour는 유니티의 기능을 불러오겠다. (컴퍼넌트 불러오기 등)
{
    public void PlayGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR //전처리기 (컴파일전 미리 기능이 정해져 있음.)
        UnityEditor.EditorApplication.isPlaying = false; //유니티에서 편집중인 상태에서 종료
#else //빌드에서 종료 (exe파일 실행인듯)
        Application.Quit();
#endif
    }
}
