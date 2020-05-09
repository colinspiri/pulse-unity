using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followedObject;

    private Transform focus;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
      focus = followedObject.transform;
      offset = transform.position - focus.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
      // calculate new position
      transform.position = focus.position + offset;
      transform.LookAt(focus.position);
    }

    public void FollowNewObject(GameObject newObject) {
      followedObject = newObject;
      focus = followedObject.transform;
    }
}
