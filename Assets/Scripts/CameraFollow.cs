using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed;
    public float minX, maxX;

    void Update()
    {
        if(player.position.x > minX)
        {
            Vector3 newPos = new Vector3(player.position.x, transform.position.y, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }
    }
}
