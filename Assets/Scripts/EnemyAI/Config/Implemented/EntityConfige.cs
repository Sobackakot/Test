using System;
using UnityEngine;


namespace EntityAI.Config
{
    [CreateAssetMenu(fileName = "EntityAI_Config", menuName = "Config/EntityAI" )]
    public class EntityConfige : ScriptableObject, IEntityConfig
    {
        [Range(1, 4), SerializeField] float _minDistanceInteract =2;
        public float minDistanceInteract => _minDistanceInteract;

        [Range(10, 50), SerializeField] float _maxDistanceRaycast =25;
        public float maxDistanceRaycast => _maxDistanceRaycast;

        [SerializeField] LayerMask _targetLayer;
        public LayerMask targetLayer => _targetLayer;

        [SerializeField] LayerMask _raycastLayers;
        public LayerMask raycastLayers => _raycastLayers;


        [SerializeField] Vector3[] _patrolPoints;
        public Vector3[] patrolPoints => _patrolPoints;

        float _time;
        public float time=> _time;


        [field: Range(1, 15), SerializeField] public float timeAFC { get ; set; }

        [Range(1, 15), SerializeField] float _interval = 5f;
        public float interval => _interval;


        [SerializeField] private EntityType _entityType;
        public EntityType entityType => _entityType;

        [SerializeField] private GameObject _prefab;  
        public GameObject prefab => _prefab;  

        [SerializeField] private Vector3 _spawnPoint;  
        public Vector3 spawnPoint => _spawnPoint;

        private string _entityId = Guid.NewGuid().ToString();  
        public string entityId => _entityId;  
         
        [Range(3, 30), SerializeField] float _minDistanceLoockTarget = 30;
        public float minDistanceLoockTarget => _minDistanceLoockTarget;


        [Range(3, 20), SerializeField] float _minDistanceFollowTarget = 25;
        public float minDistanceFollowTarget => _minDistanceFollowTarget;


        [Range(0.5f, 5), SerializeField] float _minDistanceAttackTarget = 3;
        public float minDistanceAttackTarget => _minDistanceAttackTarget;


        [Range(15, 45), SerializeField] float _minAngleRotate = 45f;
        public float minAngleRotate => _minAngleRotate;


        [Range(60, 120), SerializeField] float _maxAngleRotate = 125f;
        public float maxAngleRotate => _maxAngleRotate;


        [Range(3, 6), SerializeField] float _speedMove = 5f;
        public float speedMove => _speedMove;



        [field: Range(1, 45), SerializeField] float _angleRotate = 3f;
        public float angleRotate => _angleRotate;

        [field: Range(1, 5), SerializeField] float _minRadiusTrigger = 2;
        public float minRadiusTrigger => _minRadiusTrigger;

        [field: Range(3, 30), SerializeField] float _visionRadius = 25;
        public float visionRadius => _visionRadius;

        [field: Range(90, 160), SerializeField] float _viewAngle =125;
        public float viewAngle => _viewAngle;
          
        public void SetSpawnPoint(Vector3 point) => _spawnPoint = point; 
        public void SetEntityInstanceId(string id) => _entityId = id; 
    }
}