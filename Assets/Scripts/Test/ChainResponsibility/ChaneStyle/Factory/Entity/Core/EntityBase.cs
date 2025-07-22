using UnityEngine;

namespace Entity
{
    public abstract class EntityBase : MonoBehaviour, IEntity
    {
        public EntityBase(EntityType EntityType)
        {
            _entityType = EntityType;
        }

        [SerializeField] private GameObject prefabEntity;
        public GameObject prefab => prefabEntity;

        [SerializeField] private Transform spawnPoint;
        public Vector3 point => spawnPoint.position;

        private EntityType _entityType;
        public EntityType entityType => _entityType;
         
    }

}
