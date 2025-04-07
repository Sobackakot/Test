 
using UnityEngine;
namespace EnemyAi
{

    public interface IEnemyMove
    {
        protected Vector3 targetMove { get; set; }
        void Moving(Vector3 targetMove);
    }
}