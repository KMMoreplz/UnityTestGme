using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShip : MonoBehaviour
{
    public GameObject player;
    public float s = 1;

    void Start()
    {
        player.transform.position = new Vector3(0, 0, 0);
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * s * Time.deltaTime;
        player.transform.position += tempVect;
    }
}
