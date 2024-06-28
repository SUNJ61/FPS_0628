using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//enemy�� �¾�� ������ ���Ҿ� ������ü�� �ƿ츣�� ����� ����, �� ���� ��ü�� ���� Ŭ����
//1. �� ������, 2. �¾ ��ġ 3. �ð� ����(���ʸ��� �¾�°�) 4. ��� ���� �¾�°�
public class GameManager : MonoBehaviour
{
    public GameObject mob_fb; //1��
    public Transform[] point; //2��
    private float timePrev; //3�� - ���� �ڿ�
    private float SpawnTime = 3.0f; //3�� - 3�ʰ���
    private int MaxCount = 10; //4��
    void Start()
    {
        //���̶�Ű���� SpawnPoints��� ������Ʈ�� ã�� �� ������Ʈ�� ���� ��ġ ������Ʈ���� �����Ѵ�.(##�ڱ� �ڽ���ġ ���� ����##)
        point = GameObject.Find("SpawnPoints").GetComponentsInChildren<Transform>(); //���� �Ҵ�
        timePrev = Time.time; // ������Ʈ�� �������� ���Žð��� ��.
    }


    void Update()
    {
        if (Time.time - timePrev >= SpawnTime)
        {
            //���̶�Ű���� ���� �±׸� ���� ������Ʈ�� ������ ī��Ʈ�ؼ� �ѱ�
            int monsterCounter = GameObject.FindGameObjectsWithTag("MONSTER").Length;
            if (monsterCounter < MaxCount)
            {
                int randPos = Random.Range(1, point.Length);
                Instantiate(mob_fb, point[randPos].position, point[randPos].rotation);
                timePrev = Time.time; //���Žð� ������Ʈ
            }
        }
    }
}
