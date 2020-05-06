using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Variable : MonoBehaviour
{
    //------------ Powerbar --------------
    public bool powIncreasing;
    public float pow;
    public float deltaPow;
    public float maxPow;
    public float minPow;
    public bool fininshPowerbar;
    //------------ Anglebar --------------
    public bool angIncreasing;
    public float ang;
    public float deltaAng;
    public float maxAng;
    public float minAng;
    //-------------- UI ------------------ 
    public Text statusBox;
    public Text TimeCounter;
    //------------- Calculate ------------
    public float tempPow;
    public float tempAng;
    public bool get2value;
    public float force;
    public float angle;
    
    //------------- Object Ref ---------------
    public GameObject arrow;
    public Transform spawnPos;
    //------------- Result -------------------
    public float forceX;
    public float forceY;
    //------------- Health & Attack -------------------
    //public int damage;
    //public bool isCollide = false;
    //------------- Time Controller ------------------
    //public float timer;
    //public Text timeText;
    //-------------- Gameplay ------------------
    public bool isShot = false;

}
