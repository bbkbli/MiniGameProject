using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GamePlayer : MonoBehaviour
{
    // ����, ����
    public string PlayerName; //����-string
    public int Score; //����-int (�Ҽ���x)
    public int Hp;
    public float GameTimer; // ���� - float (�Ҽ���o)
    public bool IsPlaying;     //�³� Ʋ���� true false

    private void Start()
    {

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

        Destroy(other.gameObject);
    }
}
