
using System.Collections.Generic;
using UnityEngine;

namespace EnemyAi
{
    public class MainHandlerEnemyAi  
    {
        private float timer = 5f;
        private int indexPoint;
    
        public bool IsMinDistance(Transform enemyTr, Transform targetTr)
        {
            float distance = Vector3.Distance(enemyTr.position, targetTr.position);
            float minDistance = 30;
            if (distance <= minDistance) return true;
            else return false;
        }
        public void MoveEnemy(Enemy enemy, Transform enemyTr)
        {
            Vector3 forward = Vector3.forward;
            Vector3 right = Vector3.right;
            Vector3 back = Vector3.back;
            Vector3 left = Vector3.left;
            List<Vector3> points = new List<Vector3> { forward, right, back, left };
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                timer = Random.Range(3, 10);
                indexPoint = Random.Range(0, points.Count);
            } 
            enemy.Move(points[indexPoint]);
        }
        public void FollowEnemy(Enemy enemy, Transform targetTr)
        { 
            enemy.FollowTarget(targetTr); 
        }
        public void AttackEnemy(Enemy enemy, Transform targetTr)
        {
            enemy.Attack(targetTr);
        }
    }
}


