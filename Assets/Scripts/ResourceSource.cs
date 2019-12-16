using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSource : MonoBehaviour
{
    public float timeToSpawn;
    private float timer = 0;

    public GameObject resourcePrefab;

    public void Update() {
        if (timer >= timeToSpawn) {
            GameObject newResource = GameObject.Instantiate(resourcePrefab);
            newResource.transform.position = this.transform.position;
            Vector3 randomDir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            newResource.GetComponent<Pickupable>().Throw(randomDir, 30);
            timer = 0;
            Debug.Log("Spawned!");
        }
        timer += Time.deltaTime;
    
    }
}
