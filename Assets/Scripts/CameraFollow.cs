using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followedObject;

    private Transform focus;

    private Vector3 startOffset;
    private Vector3 offset;
    public Vector3 zoomedOffset;

    private bool zoomedOut = false;

    public float nearSize;
    public float farSize;
    public float zoomTime;
    private float zoomSpeed;

    // Start is called before the first frame update
    void Start()
    {
      focus = followedObject.transform;
      offset = startOffset = transform.position - focus.position;

      zoomSpeed = (farSize - nearSize) / zoomTime;
    }

    // Update is called once per frame
    void LateUpdate()
    {
      // calculate new position
      transform.position = focus.position + offset;

      if(focus.position.y < -10 && !zoomedOut) {
        StopAllCoroutines();
        StartCoroutine(ZoomOut());
      }
      else if(focus.position.y > -8 && zoomedOut) {
        StopAllCoroutines();
        StartCoroutine(ZoomIn());
      }
    }

    IEnumerator ZoomOut() {
      Debug.Log("zooming out");
      zoomedOut = true;
      while(Camera.main.orthographicSize < farSize) {
        Camera.main.orthographicSize += zoomSpeed * Time.deltaTime;
        offset = Vector3.Lerp(startOffset, startOffset + zoomedOffset, (Camera.main.orthographicSize - nearSize)/(farSize - nearSize));
        yield return null;
      }
    }

    IEnumerator ZoomIn() {
      Debug.Log("zooming in");
      zoomedOut = false;
      while(Camera.main.orthographicSize > nearSize) {
        Camera.main.orthographicSize -= zoomSpeed * Time.deltaTime;
        offset = Vector3.Lerp(startOffset + zoomedOffset, startOffset, 1 - (Camera.main.orthographicSize - nearSize)/(farSize - nearSize));
        yield return null;
      }
    }

    public void FollowNewObject(GameObject newObject) {
      followedObject = newObject;
      focus = followedObject.transform;
    }
}
