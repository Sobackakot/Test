using System;
using UnityEngine;


namespace EntityAI.Config
{
    public class EntityConfige : MonoBehaviour, IEntityConfig
    {

        [SerializeField] private EntityType _entityType;
        public EntityType entityType => _entityType;

        [SerializeField] private Vector3 _spawnPoint;
        public Vector3 spawnPoint => _spawnPoint;
         
        private string _entityId = Guid.NewGuid().ToString();
        public string entityId => _entityId;


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

        public void SetSpawnPoint(Vector3 point) => _spawnPoint = point;

    }
}