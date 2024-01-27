using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R1LeftDoor : MonoBehaviour
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
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<TopDownDude>();
        if (player != null)
        {

            Debug.Log("I touched the door");
            var pos = invis1.transform.position;
            pos.z = camera.transform.position.z;
            LeanTween.move(camera.gameObject, pos, 0.3f);
        }

    }
}
