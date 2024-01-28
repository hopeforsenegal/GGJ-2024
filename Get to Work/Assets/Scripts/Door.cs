using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Door: MonoBehaviour
{
   // public GameObject invsi;
    private CameraManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<CameraManager>();
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<TopDownDude>();
        manager.OnPlayerDoorCollision(player,this);

    }
}
