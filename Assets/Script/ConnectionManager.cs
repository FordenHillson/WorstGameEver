using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

[RequireComponent (typeof(SocketIOComponent))]
public class ConnectionManager : MonoBehaviour
{
    public bool monsterAttack;

    public SocketIOComponent socket;

    public int maxHp = 200;

    public int curHp;
    void Start()
    {
        socket = GetComponent<SocketIOComponent>();
        curHp = maxHp;

        socket.On("SpawnMonster", SpawnMonster);
        socket.On("UpdateMonsterData", UpdateMonsterData);
        socket.On("MonsterAttack", MonsterAttack);
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
        MonsterData.currentHealth = int.Parse(evt.data["MonsterCurHP"].ToString());
        Debug.Log(MonsterData.currentHealth);
        //monsterHealthBar.SetHealth(MonsterData.currentHealth);
    }

    private void MonsterAttack(SocketIOEvent evt)
    {
        monsterAttack = true;
        //Debug.Log(evt.data.ToString());
        curHp -= int.Parse(evt.data["MonsterDamage"].ToString());
        Debug.Log(int.Parse(evt.data["MonsterDamage"].ToString()));
        //playerHealthBar.SetHealth(PlayerData.currentHealth);
    }

    private void CheckPlayerDead()
    {
        if(curHp <= 0)
        {
            //สร้าง Panel มาแล้วขึ้นว่า Dead
        }
    }
}
