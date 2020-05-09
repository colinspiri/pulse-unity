using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempAnimation : MonoBehaviour
{
    public float animationTime;

    // Start is called before the first frame update
    void Start()
    {
      Destroy(gameObject, animationTime);
    }

    // Update is called once per frame
    void Update()
    {
      transform.rotation = Quaternion.identity;
    }
}
