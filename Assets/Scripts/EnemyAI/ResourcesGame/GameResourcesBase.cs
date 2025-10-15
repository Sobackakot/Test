using EntityAI.Config;
using System.Collections.Generic;
using UnityEngine;

namespace EntityAI.ResoucesGame
{
    public abstract class GameResourcesBase : MonoBehaviour, IGameResources
    {

        // Теперь храним ссылки на ваши EntityConfige ScriptableObjects
        [field: SerializeField] private List<EntityConfige> _entityConfigs = new();
        [field: SerializeField] private List<Transform> _spawnPoints = new(); // Если spawnPoints хранятся здесь

        private Dictionary<EntityType, EntityConfige> _configsMap = new();

        public Dictionary<EntityType, EntityConfige> entities => _configsMap;

        List<EntityConfige> IGameResources.entityConfigs => _entityConfigs;

        List<Transform> IGameResources.spawnPoints => _spawnPoints;

        private void Awake()
        { 
            // Заполняем словарь конфигами
            foreach (var config in _entityConfigs)
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
