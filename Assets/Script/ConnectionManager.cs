using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

[RequireComponent (typeof(SocketIOComponent))]
public class ConnectionManager : MonoBehaviour
{
    public bool monsterAttack;

    public SocketIOComponent socket;

    public HealthBar healthBar;
    public BossHealthBar bossHealthBar;

    public Text deadTxt;
    public GameObject DeadPanel;

    public GameObject enemyBoss;

    public int maxHp = 200;

    public int curHp;
    void Start()
    {
        socket = GetComponent<SocketIOComponent>();
        curHp = maxHp;

        socket.On("SpawnMonster", SpawnMonster);
        socket.On("UpdateMonsterData", UpdateMonsterData);
        socket.On("MonsterAttack", MonsterAttack);
        socket.On("DisableImage", DisableImage);
        socket.On("EnableImage", EnableImage);

        DeadPanel.gameObject.SetActive(false);
        deadTxt.gameObject.SetActive(false);
    }

    private void SpawnMonster(SocketIOEvent evt)
    {
        MonsterData.maxHealth = int.Parse(evt.data["MonsterMaxHP"].ToString());
        Debug.Log(MonsterData.maxHealth);
        //monsterHealthBar.SetMaxHealth(MonsterData.maxHealth);
        MonsterData.currentHealth = int.Parse(evt.data["MonsterCurHP"].ToString());
        Debug.Log(MonsterData.currentHealth);
        //monsterHealthBar.SetHealth(MonsterData.currentHealth);
    }

    private void UpdateMonsterData(SocketIOEvent evt)
    {
        MonsterData.maxHealth = int.Parse(evt.data["MonsterMaxHP"].ToString());
        Debug.Log(MonsterData.maxHealth);
        //monsterHealthBar.SetMaxHealth(MonsterData.maxHealth);
        bossHealthBar.SetBossMaxHealth(MonsterData.maxHealth);
        MonsterData.currentHealth = int.Parse(evt.data["MonsterCurHP"].ToString());
        Debug.Log(MonsterData.currentHealth);
        //monsterHealthBar.SetHealth(MonsterData.currentHealth);
        bossHealthBar.SetBossHealth(MonsterData.currentHealth);

    }

    private void MonsterAttack(SocketIOEvent evt)
    {
        monsterAttack = true;
        //Debug.Log(evt.data.ToString());
        curHp -= int.Parse(evt.data["MonsterDamage"].ToString());
        Debug.Log(int.Parse(evt.data["MonsterDamage"].ToString()));
        //playerHealthBar.SetHealth(PlayerData.currentHealth);
        healthBar.SetHealh(curHp);
        CheckPlayerDead();
    }
    private void CheckPlayerDead()
    {
        if (curHp <= 0)
        {
            DeadPanel.gameObject.SetActive(true);//สร้าง Panel มาแล้วขึ้นว่า Dead
            deadTxt.gameObject.SetActive(true);
            //testBtn.gameObject.SetActive(false);
        }
    }

    private void DisableImage(SocketIOEvent evt)
    {
        enemyBoss.SetActive(false);
    }

    private void EnableImage(SocketIOEvent evt)
    {
        enemyBoss.SetActive(true);
    }
}
