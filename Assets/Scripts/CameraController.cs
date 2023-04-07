using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update() // cant update position here becuase this update could happen before others
    {
    }

    void LateUpdate() // runs after other updates are done
    {
        transform.position = player.transform.position + offset;
    }
}
