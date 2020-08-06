using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    public GameObject[] emittedObjects;
    public Transform[] spawnPoints;
    public float minInterval = 1;
    public float maxInterval = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnObstacles());
    }

    IEnumerator spawnObstacles()
    {
        while (true)
        {
            var timeToNext = Random.Range(this.minInterval, this.maxInterval);
            yield return new WaitForSeconds(timeToNext);
            int objectIndex = Random.Range(0, this.emittedObjects.Length);
            var obj = Instantiate(this.emittedObjects[objectIndex]);
            int spawnIndex = Random.Range(0, this.spawnPoints.Length);
            obj.transform.position = this.spawnPoints[spawnIndex].position;
        }
    }
}
