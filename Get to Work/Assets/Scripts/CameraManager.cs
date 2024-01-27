using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public GameObject invis1;
    public GameObject invis2;
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
            MoveCamera(camera, invis2.transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MoveCamera(camera, invis1.transform);
        }

    }

    public static void MoveCamera(Camera c, Transform invis)
    {
        var pos = invis.transform.position;
        pos.z = c.transform.position.z;
        LeanTween.move(c.gameObject, pos, 0.3f);
    }
}
