using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//enemy가 태어나는 로직과 더불어 게임전체를 아우르는 기능을 조정, 즉 게임 전체를 조정 클래스
//1. 적 프리팹, 2. 태어날 위치 3. 시간 간격(몇초마다 태어나는가) 4. 몇마리 까지 태어나는가
public class GameManager : MonoBehaviour
{
    public GameObject mob_fb; //1번
    public Transform[] point; //2번
    private float timePrev; //3번 - 몇초 뒤에
    private float SpawnTime = 3.0f; //3번 - 3초간격
    private int MaxCount = 10; //4번
    void Start()
    {
        //하이라키에서 SpawnPoints라는 오브젝트를 찾고 그 오브젝트의 속한 위치 컴포넌트들을 저장한다.(##자기 자신위치 정보 포함##)
        point = GameObject.Find("SpawnPoints").GetComponentsInChildren<Transform>(); //동적 할당
        timePrev = Time.time; // 업데이트로 내려가면 과거시간이 됨.
    }


    void Update()
    {
        if (Time.time - timePrev >= SpawnTime)
        {
            //하이라키에서 몬스터 태그를 가진 오브젝트의 갯수를 카운트해서 넘김
            int monsterCounter = GameObject.FindGameObjectsWithTag("MONSTER").Length;
            if (monsterCounter < MaxCount)
            {
                int randPos = Random.Range(1, point.Length);
                Instantiate(mob_fb, point[randPos].position, point[randPos].rotation);
                timePrev = Time.time; //과거시간 업데이트
            }
        }
    }
}
