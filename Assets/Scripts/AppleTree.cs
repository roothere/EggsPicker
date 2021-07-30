using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public float[] speed = { 10f, 20f, 35f, 50f, 60f, 80f};
    public float leftAndRightEdge = 20f; 
    public float[] chanceToCHangeDirections = { 0.01f, 0.015f, 0.02f, 0.03f, 0.04f, 0.05f};
    public float[] secondsBetweenAppleDrops = { 1f, 0.75f, 0.5f, 0.35f, 0.25f, 0.20f};
    static public int complexity;
    
    void Start()
    {
        complexity = 0;
        Invoke("DropApple", 2f);
    }

    void DropApple() {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops[complexity]);
    }

    void Update() {
        //Simple moving
        Vector3 pos = transform.position;
        pos.x += speed[complexity] * Time.deltaTime;
        transform.position = pos;

        //Change direction
        if (pos.x < -leftAndRightEdge) {
            speed[complexity] = Mathf.Abs(speed[complexity]);
        } else if (pos.x > leftAndRightEdge) {
            speed[complexity] = -Mathf.Abs(speed[complexity]);
        }
    }

    void FixedUpdate() {
        if (Random.value < chanceToCHangeDirections[complexity]) {
            speed[complexity] *= -1;
        }
    }
}
