using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private AsteroidManager manager;

    public GameObject dust;

    // Start is called before the first frame update
    void Start()
    {
      manager = gameObject.transform.parent.GetComponent<AsteroidManager>();
    }

    // Update is called once per frame
    void Update()
    {
      if(manager == null) manager = gameObject.transform.parent.GetComponent<AsteroidManager>();

    }

    void OnCollisionEnter2D(Collision2D collisionInfo) {
      if(manager == null) manager = gameObject.transform.parent.GetComponent<AsteroidManager>();
      string name = collisionInfo.gameObject.name;
      // Debug.Log("collide with " + name );
      // explode on high impacts
      float impactSpeed = collisionInfo.relativeVelocity.magnitude;
      if(impactSpeed > 2) {
        float factor = 0.9f;
        transform.localScale = factor * transform.localScale;
        if(transform.localScale.x < 0.2f) manager.RemoveAsteroid(gameObject);
      }

      // spawn dust with size proportional to impactSpeed at every contact point
      for(int i = 0; i < collisionInfo.contactCount; i++) {
        Vector2 contact = collisionInfo.GetContact(i).point;
        GameObject animObject = Instantiate(dust, new Vector3(contact.x, contact.y, 0f), Quaternion.identity);
        animObject.transform.parent = gameObject.transform;
        float scaleFactor = 0.4f;
        animObject.transform.localScale = scaleFactor * impactSpeed * animObject.transform.localScale;
      }
    }
}
