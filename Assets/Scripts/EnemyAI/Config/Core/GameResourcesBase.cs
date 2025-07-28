using System.Collections.Generic;
using UnityEngine;

namespace EntityAI.Config
{
    public abstract class GameResourcesBase : MonoBehaviour, IGameResources
    {
        // ������ ������ ������ �� ���� EntityConfige ScriptableObjects
        [field: SerializeField] private List<EntityConfige> entityConfigs = new();
        [field: SerializeField] private List<Transform> spawnPoints = new(); // ���� spawnPoints �������� �����

        private Dictionary<EntityType, EntityConfige> _configsMap = new();

        public Dictionary<EntityType, EntityConfige> entities => _configsMap;
         

        private void Awake()
        {
            // ������������� spawnPoints (���� �� �� ������� ����� � ���������� ��������)
            for (int i = 0; i < entityConfigs.Count; i++)
            {
                if (i < spawnPoints.Count)
                {
                    entityConfigs[i].SetSpawnPoint(spawnPoints[i].position);
                }
                // ����� ����������� ���������� ID ��� ������� ����������, ���� ��� �����
                // entityConfigs[i].SetEntityInstanceId(Guid.NewGuid().ToString()); // ���, ��� ��� �����������
            }

            // ��������� ������� ���������
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
