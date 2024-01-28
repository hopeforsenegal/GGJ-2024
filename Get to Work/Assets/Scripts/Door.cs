using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Door: MonoBehaviour
{
    private CameraManager manager;

    void Start()
    {
        manager = FindObjectOfType<CameraManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(enabled == false)
        {
            return;
        }
        var player = collision.gameObject.GetComponent<TopDownDude>();
        manager.OnPlayerDoorCollision(player,this);

    }
}
