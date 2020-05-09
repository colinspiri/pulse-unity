using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class SpaceBackground : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      // flicker stars by changing light intensity
    }

    // void GenerateStars() {
    //   float numStars = 2*xdiff/unitsPerStar;
    //   // loop through and create each star
    //   stars = new List<GameObject>();
    //   for(int i = 1; i <= numStars; i++) {
    //     GameObject star = new GameObject("Star" + i);
    //     star.transform.parent = transform;
    //     star.transform.position = new Vector3(Random.Range(-xdiff, xdiff), Random.Range(-ydiff, ydiff), 0f);
    //     // add sprite component
    //     SpriteRenderer sprite = star.AddComponent<SpriteRenderer>();
    //     sprite.sprite = starSprite;
    //     sprite.sortingLayerName = "Background";
    //     // add light component
    //
    //     // light.lightType = "point";
    //     // GetComponent<Light>().color = Color.white;
    //     // add to list
    //     stars.Add(star);
    //   }
    // }
}
