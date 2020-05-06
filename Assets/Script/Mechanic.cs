using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class Mechanic : MonoBehaviour
{
    public Variable var;

    #region PowerCoroutine
    public void CallPowCoroutine()
    {
        if (var.tempPow == 0)
            StartCoroutine("ScalingPowIE");
        else if (var.tempPow != 0)
        {
            StopCoroutine("ScalingPowIE");
            var.fininshPowerbar = true;
        }

    }

    public void CheckPowIncreasing()
    {
        if (var.pow <= var.minPow)
        {
            var.powIncreasing = true;

        }
        if (var.pow >= var.maxPow)
        {
            var.powIncreasing = false;
        }
    }

    public void GetTempPow()
    {
        if (Input.GetKeyDown(KeyCode.Space) && var.tempPow == 0)
        {
            var.tempPow = var.pow;
            Debug.Log("Space was pressed");
            StopCoroutine("ScalingPowIE");
            
        }
    }

    IEnumerator ScalingPowIE()
    {
        //Debug.Log("Start scalingPowIE coroutine");
        if (var.pow < var.maxPow && var.powIncreasing)
        {
            //Debug.Log("function correct");
            var.pow += var.deltaPow;
            CheckPowIncreasing();
            GetTempPow();
        }

        if (var.pow > var.minPow && !var.powIncreasing)
        {
            var.pow -= var.deltaPow;
            CheckPowIncreasing();
            GetTempPow();
        }

        var.statusBox.text = "Power : " + var.pow.ToString("F0") + "||" + " Angle : " + var.ang.ToString("F0");

        yield return null;
    }
    #endregion

    #region AngleCoroutine
    public void CallAngCoroutine()
    {
        if (var.tempPow != 0 && var.tempAng == 0)
        {
            //Debug.Log("will start Anglebar Coroutine");
            StartCoroutine("ScalingAngIE");
        }

        else if (var.tempPow != 0 && var.tempAng != 0)
        {
            StopCoroutine("ScalingAngIE");
            //Debug.Log("Ang was stop");
        }

    }

    public void CheckAngIncreasing()
    {
        if (var.ang <= var.minAng)
        {
            var.angIncreasing = true;
        }
        if (var.ang >= var.maxAng)
        {
            var.angIncreasing = false;
        }
    }

    public void GetTempAng()
    {
        if (Input.GetKeyDown(KeyCode.Space) && var.tempPow != 0 && var.tempAng == 0 && var.fininshPowerbar)
        {
            var.tempAng = var.ang;
            Debug.Log("Anglebar will stop");
            StopCoroutine("ScalingAngIE");
        }
    }

    IEnumerator ScalingAngIE()
    {
        //Debug.Log("Start Anglebar coroutine");
        if (var.ang < var.maxAng && var.angIncreasing)
        {
            var.ang += var.deltaAng;
            CheckAngIncreasing();
            GetTempAng();
        }

        if (var.ang > var.minAng && !var.angIncreasing)
        {
            var.ang -= var.deltaAng;
            CheckAngIncreasing();
            GetTempAng();
        }

        var.statusBox.text = "Power : " + var.pow.ToString("F0") + "||" + " Angle : " + var.ang.ToString("F0");

        yield return null;
    }
    #endregion

    #region Calculate
    public void CheckValue()
    {
        //Debug.Log("Start CheckValue");
        if (var.tempPow != 0 && var.tempAng != 0)
        {
            var.get2value = true;
        }
    }

    public void GetValue()
    {
        //Debug.Log("Start GetValue");
        if (var.get2value)
        {
            var.force = var.tempPow;
            var.angle = var.tempAng;
        }
    }

    public void SpawnArrow()
    {
        if (var.force != 0 && var.angle != 0 && !var.isShot)
        {
            Instantiate(var.arrow, var.spawnPos.position, Quaternion.identity);
            var.isShot = true;
        }
        ResetValue();
    }

    public void CalculateInAxis()
    {
        //Debug.Log("Start Calculate force in Axis");
        var.forceX = (var.force * 10 * Mathf.Cos(var.angle * Mathf.Deg2Rad));
        var.forceY = (var.force * 10 * Mathf.Sin(var.angle * Mathf.Deg2Rad));
    }

    public void ResetValue()
    {
        if (var.isShot)
        {
            var.pow = 20;
            var.fininshPowerbar = false;
            var.powIncreasing = true;
            var.ang = 20;
            var.angIncreasing = true;
            var.tempPow = 0;
            var.tempAng = 0;
            var.get2value = false;
            var.force = 0;
            var.angle = 0;
            var.isShot = false;
            
            Debug.Log("all stat was reset");
        }
    }
    #endregion

    public void PlayLoop()
    {
        Debug.Log("Playloop working");

        CallPowCoroutine();
        CallAngCoroutine();
        CheckValue();
        GetValue();
        CalculateInAxis();
        SpawnArrow();
        //ResetValue();

    }

    private void Update()
    {
        PlayLoop();
    }
}
