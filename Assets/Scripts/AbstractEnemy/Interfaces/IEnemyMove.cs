 
using UnityEngine;
namespace EnemyAi
{

    public interface IEnemyMove
    {
        protected Vector3 TargetMove { get; set; }
        void Moving(Vector3 targetMove);
    }
}