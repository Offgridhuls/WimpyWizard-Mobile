using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewObject : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject spawnObject;
    // Start is called before the first frame update
    void Start()
    {
        SpawnGameObject(spawnObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnGameObject(GameObject objectToSpawn)
    {
        var newObj = Instantiate(objectToSpawn, spawnPos.position, Quaternion.identity);
    }
}
