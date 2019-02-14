using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform playerPosition;
    public Transform moveThresold;



    // Update is called once per frame
    void Update()
    {
        if (playerPosition.position.x > moveThresold.position.x)
        {
            //move camere private void OnApplicationPause(bool pauseStatus) {
            transform.position = new Vector3(playerPosition.position.x, transform.position.y, transform.position.z);
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(moveThresold.position, new Vector2(moveThresold.position.x, moveThresold.position.y + 10));
        Gizmos.DrawLine(moveThresold.position, new Vector2(moveThresold.position.x, moveThresold.position.y - 10));
    }

}
