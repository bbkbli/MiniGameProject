using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Progress;

public class GamePlayer : MonoBehaviour
{
    // ����, ����
    public string PlayerName; //����-string
    public int Score; //����-int (�Ҽ���x)
    public int Hp;
    public float GameTimer; // ���� - float (�Ҽ���o)
    public bool IsPlaying;     //�³� Ʋ���� true false

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

        // ����
        //�����ε�
        //Instantiate()

        //Instantiate(coinPrefab, position . rotation);

        //itemContainer.transform
        //itemContainer.GetComponent<Transform>()

        //���
        //for��
        //if��

        //            ����   ;   ��   ;   ��ȭ
        int count;
        for (  count = 0 ;  count < ItemCount; count++  )
        {
            Debug.Log("�ݺ����Դϴ�");
            GameObject item = Instantiate(coinPrefab, itemContainer.transform);
            //����
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



        // �ı�
        //Destroy()

        //Ȱ��ȭ/��Ȱ��ȭ
        //txtName.SetActive(true)
        //txtName.SetActive(false)

        // ������Ʈ ����
        //GetComponent<>()

    }

    private void Update()
    {

        if (!IsPlaying)
        {
            Debug.Log("������ �������ϴ�");
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
