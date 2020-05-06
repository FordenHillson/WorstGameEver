using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using SocketIO;

public class Arrow : MonoBehaviour
{
    public Variable var;

    public Mechanic mech;

    public Rigidbody2D rigid;

    public SocketIOComponent socket;
    private void Start()
    {
        rigid.AddForce(new Vector2(var.forceX,var.forceY));
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Head"))
        {
            Debug.Log("Hit it's head");
            socket.Emit("HitHead");
        }

        else if(collider.gameObject.CompareTag("Body"))
        {
            Debug.Log("Hit it's body");
            socket.Emit("HitBody");
        }
    }


}
