using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DoorToVantage{
   public Door door;
   public GameObject vantage;
   public GameObject spawn;
}

public class CameraManager : MonoBehaviour
{
    public DoorToVantage[] doorToVantage;
    public GameObject vantage1;
    public GameObject vantage2;
    public GameObject spawn1;
    public GameObject spawn2;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            MoveCamera(camera, vantage2.transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MoveCamera(camera, vantage1.transform);
        }

    }
    public void OnPlayerDoorCollision(TopDownDude player)
    {
        if (player != null)
        {

            Debug.Log("I touched the door");
            CameraManager.MoveCamera(camera, vantage2.transform);
            CameraManager.MovePlayer(player, spawn2.transform);
        }
    }
    public static void MoveCamera(Camera c, Transform vantage)
    {
        var pos = vantage.transform.position;
        pos.z = c.transform.position.z;
        LeanTween.move(c.gameObject, pos, 0.3f);
    }
    public static void MovePlayer(TopDownDude player, Transform spawn)
    {
        var spawnPoint = spawn.transform.position;
        LeanTween.move(player.gameObject, spawnPoint, 0.01f);
    }
}
