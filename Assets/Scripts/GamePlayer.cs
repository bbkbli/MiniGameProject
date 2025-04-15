using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Progress;

public class GamePlayer : MonoBehaviour
{
    // 숫자, 문자
    public string PlayerName; //문자-string
    public int Score; //숫자-int (소수점x)
    public int Hp;
    public float GameTimer; // 숫자 - float (소수점o)
    public bool IsPlaying;     //맞냐 틀리냐 true false

    public GameObject txtTimer;
    public GameObject txtName;
    public GameObject txtScoreValue;
    public GameObject txtHpValue;

    public GameObject coinPrefab;
    public GameObject enemyPrefab;

    public GameObject itemContainer;
    public GameObject enemyContainer;

    public int ItemCount = 30;
    public float mapSize = 20;
    public int EnemyCount = 30;



    private void Start()
    {
        txtName.GetComponent<TMP_Text>().text = PlayerName;

        txtHpValue.GetComponent<TMP_Text>().text = Hp.ToString();

        // 생성
        //오버로딩
        //Instantiate()

        //Instantiate(coinPrefab, position . rotation);

        //itemContainer.transform
        //itemContainer.GetComponent<Transform>()

        //제어문
        //for문
        //if문

        //            시작   ;   끝   ;   변화
        int count;
        for (  count = 0 ;  count < ItemCount; count++  )
        {
            Debug.Log("반복중입니다");
            GameObject item = Instantiate(coinPrefab, itemContainer.transform);
            //변수
            float halfSzie = mapSize / 2;
            float randomX = Random.Range(halfSzie * -1, halfSzie);
            float randomZ = Random.Range(halfSzie * -1, halfSzie);
            item.transform.position = new Vector3(randomX, 1, randomZ);

        }

        //enemy
        for ( count = 0; count < EnemyCount  ; count++)
        {
            GameObject enemy = Instantiate(enemyPrefab, enemyContainer.transform);

            float halfSzie = mapSize / 2;
            float randomX = Random.Range(halfSzie * -1, halfSzie);
            float randomZ = Random.Range(halfSzie * -1, halfSzie);

            enemy.transform.position = new Vector3(randomX, 1, randomZ);
        }



        // 파괴
        //Destroy()

        //활성화/비활성화
        //txtName.SetActive(true)
        //txtName.SetActive(false)

        // 컴포넌트 접근
        //GetComponent<>()

    }

    private void Update()
    {

        if (!IsPlaying)
        {
            Debug.Log("게임이 끝났습니다");
            return;
        }

        GameTimer = GameTimer - Time.deltaTime;
        if(GameTimer < 0)
        {
            IsPlaying = false;
        }

        txtTimer.GetComponent<TMP_Text>().text = GameTimer.ToString("f1");

    }

    private void OnTriggerEnter(Collider other)
    {
        bool isEnemy = other.gameObject.tag == "Enemy";

        bool isItme = other.gameObject.tag == "Itme";

        if (isEnemy)
        {
            Debug.Log("Enemy Check");
            Hp = Hp - 1;


            if(Hp <= 0)
            {
                IsPlaying = false;
            }
            // if hp <= 0 - IsPlaying = false
        }

        if (isItme)
        {
            Debug.Log("Itme Check");

            // 0 = 0 + 1
            Score = Score + 1;
        }

        txtScoreValue.GetComponent<TMP_Text>().text = Score.ToString();

        txtHpValue.GetComponent<TMP_Text>().text = Hp.ToString();

        Destroy(other.gameObject);
    }
}
