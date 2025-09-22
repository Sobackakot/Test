using EntityAI;
using System.Collections.Generic;
using UnityEngine;

public class PoolSystem  
{ 
    
    Dictionary<EntityType, Queue<GameObject>> poolGameObjects = new(); 
    public Queue<GameObject> InitializePool(int poolCount, GameObject prefub, EntityType entityType, Vector3 pos, Quaternion rot)
    {
        for(int i = 0; i < poolCount; i++)
        {
            GameObject newEntity = GameObject.Instantiate(prefub, pos, rot);
            newEntity.SetActive(false);
            if(!poolGameObjects.ContainsKey(entityType))
                poolGameObjects[entityType] = new Queue<GameObject>();
            poolGameObjects[entityType].Enqueue(newEntity);
        }
        return poolGameObjects[entityType];
    }

    public GameObject ExtractFromPool(GameObject prefub, EntityType entityType, Vector3 pos,Quaternion rot)
    { 
        GameObject newObject = null;
        if (poolGameObjects.TryGetValue(entityType, out Queue<GameObject> objects))
        {
            if (objects.TryDequeue(out newObject))
            {
                newObject.gameObject.SetActive(true);
                Debug.Log("extract from pool");
            }
            else
            {
                newObject = GameObject.Instantiate(prefub, pos, rot);
                Debug.Log("extract from new ");
            }
        }  

        return newObject;
    }
    public void ReturnToPool(GameObject currentEntity, EntityType entityType)
    {
        currentEntity.gameObject.SetActive(false);
        if (poolGameObjects.TryGetValue(entityType, out Queue<GameObject> objects))
        {
            if (!poolGameObjects.ContainsKey(entityType))
                poolGameObjects[entityType] = new Queue<GameObject>();
            poolGameObjects[entityType].Enqueue(currentEntity);
        }
            
    } 
}
