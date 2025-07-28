using System;
using UnityEngine;


namespace EntityAI.Config
{
    [CreateAssetMenu(fileName = "EntityAI_Config", menuName = "Config/EntityAI" )]
    public class EntityConfige : ScriptableObject, IEntityConfig
    {

        [SerializeField] private EntityType _entityType;
        public EntityType entityType => _entityType;

        [SerializeField] private GameObject _prefab; // <-- ƒќЅј¬Ћ≈Ќќ: —сылка на префаб
        public GameObject prefab => _prefab; // <-- ƒќЅј¬Ћ≈Ќќ

        [SerializeField] private Vector3 _spawnPoint; // ћожно удалить, если спавн-поинт будет передаватьс€ в фабрику
        public Vector3 spawnPoint => _spawnPoint;

        private string _entityId = Guid.NewGuid().ToString(); // »дентификатор дл€ экземпл€ра сущности
        public string entityId => _entityId; // Ётот ID должен генерироватьс€ при создании экземпл€ра, а не в SO

        // ... (остальные ваши пол€ конфигурации) ...

        // ћетод SetSpawnPoint, если spawnPoint не будет передаватьс€ в фабрику, а будет частью конфига SO
        public void SetSpawnPoint(Vector3 point) => _spawnPoint = point;

        // ћетод дл€ установки ID экземпл€ра (если ID должен быть уникальным дл€ каждого экземпл€ра)
        public void SetEntityInstanceId(string id) => _entityId = id;


        [field: Range(3, 30), SerializeField] float _minDistanceLoockTarget = 30;
        public float minDistanceLoockTarget => _minDistanceLoockTarget;


        [field: Range(3, 20), SerializeField] float _minDistanceFollowTarget = 25;
        public float minDistanceFollowTarget => _minDistanceFollowTarget;


        [field: Range(0.5f, 5), SerializeField] float _minDistanceAttackTarget = 6;
        public float minDistanceAttackTarget => _minDistanceAttackTarget;


        [field: Range(15, 45), SerializeField] float _minAngle = 45f;
        public float minAngle => _minAngle;


        [field: Range(60, 120), SerializeField] float _maxAngle = 125f;
        public float maxAngle => _maxAngle;


        [field: Range(3, 6), SerializeField] float _speedMove = 5f;
        public float speedMove => _speedMove;



        [field: Range(1, 45), SerializeField] float _angleRotate = 3f;
        public float angleRotate => _angleRotate;
         
    }
}