using EntityAI.Config;
using UnityEngine;

namespace EntityAI.Factory
{
    public abstract class FactoryBase : IFactory
    {
        protected readonly EntityType type;
        protected readonly IGameResources _gameResources; // <-- ДОБАВЛЕНО: Зависимость от ресурсов
        public IGameResources resources => _gameResources;

        // Конструктор теперь принимает IGameResources
        public FactoryBase(EntityType type, IGameResources gameResources)
        {
            this.type = type;
            _gameResources = gameResources;
        }


        // Метод Creating в CreatorBase будет передавать IGameResources
        public IEntity NewEntity() // Метод не принимает IEntityResources напрямую, а использует _gameResources
        {
            // 1. Получаем EntityConfige для нужного типа
            EntityConfige entityConfig = _gameResources.GetEntityConfig(type);

            if (entityConfig == null || entityConfig.prefab == null)
            {
                Debug.LogError($"Factory: No config or prefab found for EntityType: {type}");
                return null;
            }

            // 2. Инстанцируем префаб
            // Замечание: spawnPoint лучше передавать в NewEntity, а не брать из конфига SO
            // Если spawnPoint уникален для каждого спавна, то конфиг SO не должен его содержать.
            // Если spawnPoint - это дефолтный спавн для типа, тогда можно.
            // Для примера, я возьму его из конфига SO.
            GameObject newEnemyGo = GameObject.Instantiate(entityConfig.prefab, entityConfig.spawnPoint, Quaternion.identity);

            // 3. Получаем компонент EntityAIBase с инстанцированного GameObject
            EntityAIBase entityAIBase = newEnemyGo.GetComponent<EntityAIBase>();

            if (entityAIBase == null)
            {
                Debug.LogError($"Factory: Prefab for {type} does not have an EntityAIBase component!");
                GameObject.Destroy(newEnemyGo); // Уничтожаем, если нет нужного компонента
                return null;
            }

            // 4. Генерируем уникальный ID для ЭТОГО экземпляра сущности
            entityConfig.SetEntityInstanceId(System.Guid.NewGuid().ToString());

            // 5. Возвращаем EntityAIBase (который является IEntity)
            return entityAIBase;
        }
    }

}

