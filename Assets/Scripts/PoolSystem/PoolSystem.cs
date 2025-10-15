using EntityAI;
using EntityAI.Config;
using EntityAI.ResoucesGame;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoolSystem  
{ 
    
    Dictionary<EntityType, Queue<GameObject>> poolGameObjects = new(); 
    public Queue<GameObject> InitializePool(int poolCount, EntityConfige config)
    {
        for(int i = 0; i < poolCount; i++)
        {
            GameObject newEntity = CreateNewEntity(config);
            newEntity.SetActive(false);

            if(!poolGameObjects.ContainsKey(config.entityType))
                poolGameObjects[config.entityType] = new Queue<GameObject>();
            poolGameObjects[config.entityType].Enqueue(newEntity);
        }
        return poolGameObjects[config.entityType];
    }

    public GameObject ExtractFromPool(EntityConfige config)
    { 
        GameObject newObject = null;
        Vector3 validatePoint = GetValidSpawnPosition(config.spawnPoint);
        if (poolGameObjects.TryGetValue(config.entityType, out Queue<GameObject> objects))
        {
            if (objects.TryDequeue(out newObject))
            {
                newObject.SetActive(true);
                newObject.transform.position = validatePoint;
            }
            else
            {
                newObject = CreateNewEntity(config); 
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
    private static GameObject CreateNewEntity(EntityConfige config)
    {
        // Сперва создаем конфиг, указывает точку спавна, а потом уже сушьность
        EntityConfige newConfig = GameObject.Instantiate(config);
        newConfig.SetEntityId(System.Guid.NewGuid().ToString());

        int index = UnityEngine.Random.Range(0, ResoursesInst.res.spawnPoints.Count);
        newConfig.SetSpawnPoint(ResoursesInst.res.spawnPoints[index].position);
        newConfig.SetPartolPoints(ResoursesInst.res.spawnPoints);

        GameObject newEntity = GameObject.Instantiate(config.prefab, newConfig.spawnPoint, Quaternion.identity);
        EntityAIBase entity = newEntity.GetComponent<EntityAIBase>();

        entity.SetConfig(newConfig);
        return newEntity;
    }
    // Новая функция для поиска ближайшей точки на NavMesh
    private Vector3 GetValidSpawnPosition(Vector3 desiredPosition)
    {
        NavMeshHit hit;
        // Ищем ближайшую точку на NavMesh в радиусе 5.0f
        if (NavMesh.SamplePosition(desiredPosition, out hit, 5.0f, NavMesh.AllAreas))
        {
            return hit.position;
        }
        else
        {
            // Если валидная точка не найдена, возвращаем исходную, но это опасно.
            // В реальной игре тут должен быть лог ошибки и безопасный выход.
            Debug.LogError("Валидная точка не найдена");
            return desiredPosition; // Тут будет выброшена ошибка NavMesh, если мы вернемся сюда.
        }
    }
}
