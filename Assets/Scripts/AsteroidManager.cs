using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public Rigidbody2D asteroidPrefab;

    public int maxAsteroids;
    public float minSize;
    public float maxSize;
    public float minVelocity;
    public float maxVelocity;

    private int asteroidCount;

    // Start is called before the first frame update
    void Start()
    {
      while(asteroidCount < maxAsteroids) SpawnUntilMax();
    }

    // Update is called once per frame
    void Update()
    {
      // Debug.Log("count = " + asteroidCount);
      if(asteroidCount < maxAsteroids) SpawnUntilMax();
    }

    void SpawnUntilMax() {
      float xStart = -50;
      float xEnd = 50;
      float yStart = -20;
      float yEnd = 70;
      float minStep = maxSize + 2;
      float maxStep = 3*maxSize;
      for(float x = xStart; x < xEnd; x += Random.Range(minStep, maxStep)) {
        for(float y = yStart; y < yEnd; y += Random.Range(minStep, maxStep)) {
          if(asteroidCount >= maxAsteroids) return;
          Vector3 position = new Vector3(x, y, 1);
          float size = Random.Range(minSize, maxSize);
          minStep = size + 2;
          maxStep = 3*size;
          SpawnAsteroid(position, size);
        }
      }
      // Vector3 position = new Vector3(Random.Range(-range, range), Random.Range(-range, range), 0);
      // float size = Random.Range(minSize, maxSize);
      // if(!PositionTaken(position, size)) {
      //   SpawnAsteroid(position, size);
      // }
    }

    // bool PositionTaken(Vector3 position, float size) {
    //   for(int i = 0; i < takenAreas.Count; i++) {
    //     (Vector3, float) area = takenAreas[i];
    //     if(area.Item1.x + area.Item2 < position.x - size) {
    //       continue;
    //     }
    //     if(area.Item1.x - area.Item2 > position.x + size) {
    //
    //       continue;
    //     }
    //     if(area.Item1.y + area.Item2 < position.y - size) {
    //       continue;
    //     }
    //     if(area.Item1.y - area.Item2 > position.y + size) {
    //       continue;
    //     }
    //     Debug.Log("taken!");
    //     return true;
    //   }
    //   return false;
    // }

    public void SpawnAsteroid(Vector3 position, float size) {
      if(size < minSize) return;

      // spawn asteriod at pos
      Rigidbody2D rb = Instantiate(asteroidPrefab, position, Quaternion.identity);
      rb.gameObject.transform.parent = transform;

      // set size
      rb.gameObject.transform.localScale = new Vector3(size/26, size/26, 1f);

      // give asteroid random velocity
      Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
      dir.Normalize();
      rb.velocity = Random.Range(minVelocity, maxVelocity) * dir;

      // give asteroid random torque
      float minAlpha = 0f;
      float maxAlpha = 360f;
      rb.angularVelocity = Random.Range(minAlpha, maxAlpha);

      // increase count
      asteroidCount++;
    }

    public void RemoveAsteroid(GameObject removed) {
      Destroy(removed);
      asteroidCount--;
    }
}
