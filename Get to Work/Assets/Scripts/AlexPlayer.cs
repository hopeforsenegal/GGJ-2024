using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlexPlayer : MonoBehaviour
{
    public Config config;
    public AlexRunner runner;

    // Update is called once per frame
    void Update()
    {
        GameAlwaysAlive.Instance.runningTime += Time.deltaTime;
        // Update inputs
        runner.dx = Input.GetAxis("Horizontal");
        runner.jumpPressed = Input.GetKeyDown("space");
    }
}
