using EntityAI.Config;
using UnityEngine;

namespace EntityAI.Factory
{
    public abstract class FactoryBase : IFactory
    {
        protected readonly EntityType type;
        protected readonly IGameResources _gameResources; // <-- ���������: ����������� �� ��������
        public IGameResources resources => _gameResources;

        // ����������� ������ ��������� IGameResources
        public FactoryBase(EntityType type, IGameResources gameResources)
        {
            this.type = type;
            _gameResources = gameResources;
        }


        // ����� Creating � CreatorBase ����� ���������� IGameResources
        public IEntity NewEntity() // ����� �� ��������� IEntityResources ��������, � ���������� _gameResources
        {
            // 1. �������� EntityConfige ��� ������� ����
            EntityConfige entityConfig = _gameResources.GetEntityConfig(type);

            if (entityConfig == null || entityConfig.prefab == null)
            {
                Debug.LogError($"Factory: No config or prefab found for EntityType: {type}");
                return null;
            }

            // 2. ������������ ������
            // ���������: spawnPoint ����� ���������� � NewEntity, � �� ����� �� ������� SO
            // ���� spawnPoint �������� ��� ������� ������, �� ������ SO �� ������ ��� ���������.
            // ���� spawnPoint - ��� ��������� ����� ��� ����, ����� �����.
            // ��� �������, � ������ ��� �� ������� SO.
            GameObject newEnemyGo = GameObject.Instantiate(entityConfig.prefab, entityConfig.spawnPoint, Quaternion.identity);

            // 3. �������� ��������� EntityAIBase � ����������������� GameObject
            EntityAIBase entityAIBase = newEnemyGo.GetComponent<EntityAIBase>();

            if (entityAIBase == null)
            {
                Debug.LogError($"Factory: Prefab for {type} does not have an EntityAIBase component!");
                GameObject.Destroy(newEnemyGo); // ����������, ���� ��� ������� ����������
                return null;
            }

            // 4. ���������� ���������� ID ��� ����� ���������� ��������
            entityConfig.SetEntityInstanceId(System.Guid.NewGuid().ToString());

            // 5. ���������� EntityAIBase (������� �������� IEntity)
            return entityAIBase;
        }
    }

}

