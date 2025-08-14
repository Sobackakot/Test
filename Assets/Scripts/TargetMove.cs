
using EntityAI.Repository;
using UnityEngine;

public class TargetMove : MonoBehaviour, ITargetable
{
    ITargetSingleRepository _registry;
    public ITargetSingleRepository registry => _registry;
    public Transform targetTr { get ; set ; }

    bool _isAlive;
    public bool isAlive => _isAlive;
    [field:SerializeField]public TargetType TargetType { get; set ; }

    //public void Initialized(ITargetSingleRepository registry)
    //{
    //    this.registry = registry;
    //}
    private void Awake()
    {
        _registry = FindObjectOfType<TargetSingleRepository>();
        targetTr = GetComponent<Transform>();   
    }
    private void OnEnable()
    {
        registry.RegisterTarget(this);
        _isAlive = true;
    }
    private void OnDisable()
    {
        registry.UnregisterTarget(this);
        _isAlive = false;
    }

    public bool IsAlive()
    {
        return isAlive;
    }

    public void OnFocused(Transform npcTr)
    {
    }

    public void OnDefocus()
    {
    }

    public void InteractOnNewPoint()
    {
    }
}
