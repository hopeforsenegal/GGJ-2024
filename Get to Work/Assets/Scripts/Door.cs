using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Door: MonoBehaviour
{
    public GameObject invis1;
    public GameObject invis2;
    public Camera camera;

    private CameraManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<TopDownDude>();
        if (player != null)
        {

            Debug.Log("I touched the door");
            CameraManager.MoveCamera(camera, invis2.transform);
        }

    }
}
