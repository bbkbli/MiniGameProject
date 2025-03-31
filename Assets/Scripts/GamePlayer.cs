using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GamePlayer : MonoBehaviour
{
    // 숫자, 문자
    public string PlayerName; //문자-string
    public int Score; //숫자-int (소수점x)
    public int Hp;
    public float GameTimer; // 숫자 - float (소수점o)
    public bool IsPlaying;     //맞냐 틀리냐 true false

    private void Start()
    {

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
