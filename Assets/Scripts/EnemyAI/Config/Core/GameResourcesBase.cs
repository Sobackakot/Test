using System.Collections.Generic;
using UnityEngine;

namespace EntityAI.Config
{
    public abstract class GameResourcesBase : MonoBehaviour, IGameResources
    {
        // Теперь храним ссылки на ваши EntityConfige ScriptableObjects
        [field: SerializeField] private List<EntityConfige> entityConfigs = new();
        [field: SerializeField] private List<Transform> spawnPoints = new(); // Если spawnPoints хранятся здесь

        private Dictionary<EntityType, EntityConfige> _configsMap = new();

        public Dictionary<EntityType, EntityConfige> entities => _configsMap;
         

        private void Awake()
        {
            // Инициализация spawnPoints (если вы их храните здесь и назначаете конфигам)
            for (int i = 0; i < entityConfigs.Count; i++)
            {
                if (i < spawnPoints.Count)
                {
                    entityConfigs[i].SetSpawnPoint(spawnPoints[i].position);
                }
                // Также сгенерируем уникальный ID для каждого экземпляра, если это нужно
                // entityConfigs[i].SetEntityInstanceId(Guid.NewGuid().ToString()); // Нет, это для экземпляров
            }

            // Заполняем словарь конфигами
            foreach (var config in entityConfigs)
            {
                if (!_configsMap.ContainsKey(config.entityType))
                {
                    _configsMap.Add(config.entityType, config);
                }
                else
                {
                    Debug.LogWarning($"Duplicate EntityType {config.entityType} in GameResourcesBase. Only the first will be used.");
                }
            }
        }

        public EntityConfige GetEntityConfig(EntityType type)
        {
            return _configsMap.TryGetValue(type, out var config) ? config : null;
        }
    }

}
