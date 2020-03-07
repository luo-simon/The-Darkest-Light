using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    public bool isFollowing;

    public float xOffset;
    public float yOffset;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    private Vector3 playerPos;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isFollowing = true;
    }
    
    void Update()
    {
        if (isFollowing)
        {
            playerPos = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);
            transform.position = new Vector3(Mathf.Clamp(playerPos.x, minCameraPos.x, maxCameraPos.x),
                                 Mathf.Clamp(playerPos.y + yOffset, minCameraPos.y, maxCameraPos.y),
                                 Mathf.Clamp(playerPos.z, minCameraPos.z, maxCameraPos.z));
        }
    }
}
