using EnemyAi; 

public interface IBehaviourHandler  
{
    Enemy enemy { get; set; } 
    void Enter();
    void Exit();
    void Update();
    void LateUpdate();
    void FixedUpdate();
}
