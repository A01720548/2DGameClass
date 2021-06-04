using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 position_user;
    public float offset = 5f;
    private float timeOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        position_user = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        if (player.transform.localScale.x > 0f) {
            position_user = new Vector3(player.transform.position.x - offset, transform.position.y, transform.position.z);
        } else {
            position_user = new Vector3(player.transform.position.x + offset, transform.position.y, transform.position.z);

        }
        transform.position = Vector3.Lerp(transform.position, position_user, timeOffset = Time.deltaTime);
        // transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
