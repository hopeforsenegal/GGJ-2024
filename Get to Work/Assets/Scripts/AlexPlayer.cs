using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlexPlayer : MonoBehaviour
{
    public Config config;
    public AlexRunner runner;

    // Update inputs
    public void updateInputs()
    {
        runner.dx = Input.GetAxis("Horizontal");
        runner.jumpPressed = Input.GetKeyDown("space");
    }

    // Update is called once per frame
    void Update()
    {
        GameAlwaysAlive.DoUpdate(config);

        // Check win condition
        if (transform.position.y < -50)
        {
            Debug.Log("You made to work!");
        }
    }
}
