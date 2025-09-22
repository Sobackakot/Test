using BehaviourFree;
using BehaviourFree.Node;
using UnityEngine;

public class NewBehaviourTree : MonoBehaviour
{
    NodeBase rootNode;
    ContextTest ctx;

    public int foodAmount;
    public int energyAmount;

    public bool isFoodFound;

    public bool isHungry;
    public bool isHasFood;
    public bool isHasEnergy;


    private void Start()
    {
        ctx = new ContextTest();
        rootNode = BuildTree(); 
    }
    void Update()
    {
        ShowCurrentStates();
        rootNode.Evaluate(); 
    }
 
    private NodeBase BuildTree()
    {
        var useFood = new UseFoodTask(ctx);
        var searchFood = new SearchFoodNode(ctx);
        var work = new WorkTask(ctx);
         
        var eatFoodSequence = new SequenceNode(
            new HangerCondition(useFood, ctx),
            new HasFoodCondition(useFood, ctx),
            useFood
        );
         
        var findFoodSequence = new SequenceNode(
            new HangerCondition(searchFood, ctx),
            new Not(
                new HasFoodCondition(searchFood, ctx)),
            searchFood
        );
         
        var workSequence = new SequenceNode(
            new Not(
                new HangerCondition(work, ctx)),
            new EnergyCondition(work, ctx),
            work
        );
         
        return new SelectorNode(
            eatFoodSequence,
            findFoodSequence,
            workSequence
        ); 
    }
    void ShowCurrentStates()
    {
        isFoodFound = ctx.isFoodFound;

        isHasFood = ctx.isHasFood;
        isHasEnergy = ctx.isHasEnergy;
        isHungry = ctx.isHungry;

        energyAmount = ctx.energyAmount;
        foodAmount = ctx.foodAmount; 
    }
}
public class ContextTest
{
    public int foodAmount { get; private set; } = 6;
    public int energyAmount { get; private set; } = 6;
   
    public bool isFoodFound { get; private set; } = true;

    public bool isHungry { get; private set; } = false;
    public bool isHasFood { get; private set; } = true;
    public bool isHasEnergy { get; private set; } = true;
    
    public void SetStateFindFood(bool isFoodFound)
    {
        this.isFoodFound = isFoodFound;
    }
    public void AddEnergy(int energyAmount)
    {
        this.energyAmount += energyAmount;
        UpdateHungryState();
        UpdateEnergyState();
    }
    public void RemoveEnergy(int energyAmount)
    {
        if(isHasEnergy)
        this.energyAmount -= energyAmount;
        UpdateHungryState();
        UpdateEnergyState();
    }
 
    public void AddFood(int foodAmount)
    {
        if (isFoodFound)
            this.foodAmount += foodAmount;
        UpdateFoodState();
        UpdateEnergyState();
    }
    public void RemoveFood(int foodAmount)
    {
        if (isHasFood)
            this.foodAmount -= foodAmount;
        UpdateFoodState();
        UpdateEnergyState();
    }

    private void UpdateFoodState()
    { 
        isHasFood = foodAmount >= 1;
    }
    private void UpdateHungryState()
    {
        isHungry = energyAmount < 2 || foodAmount < 1;
    }
    private void UpdateEnergyState()
    {
        isHasEnergy = energyAmount > 1;
    }
}
public class EnergyCondition : ConditionNode
{
    public EnergyCondition(NodeBase child, ContextTest ctx) : base(child)
    {
        this.ctx = ctx;
    }
    ContextTest ctx;
    protected override bool CanEvaluate()
    { 
        return ctx.isHasEnergy;
    }
}
public class HangerCondition : ConditionNode
{
    public HangerCondition(NodeBase child, ContextTest ctx) : base(child)
    {
        this.ctx = ctx;
    }
    ContextTest ctx;
    protected override bool CanEvaluate()
    { 
        return ctx.isHungry;
    }
}
public class HasFoodCondition : ConditionNode
{
    public HasFoodCondition(NodeBase child, ContextTest ctx) : base(child)
    {
        this.ctx = ctx;
    }
    ContextTest ctx;
    protected override bool CanEvaluate()
    { 
        return ctx.isHasFood;
    }
}
public class SearchFoodNode : NodeBase
{
    public SearchFoodNode(ContextTest ctx)
    {
        this.ctx = ctx;
    }
    ContextTest ctx;
    private float timer;
    private float interfalSearch = 3f;
    public override Status Evaluate()
    { 
        ctx.SetStateFindFood(Random.value > 0.5f);
        if (ctx.isFoodFound && timer <= Time.time) 
        { 
            timer = Time.time + interfalSearch;
            ctx.AddFood(Random.Range(6, 15)); 
            return Status.Success;
        } 
        else return Status.Running;
    }
}
public class UseFoodTask : NodeBase
{
    public UseFoodTask(ContextTest ctx)
    {
        this.ctx = ctx;
    }
    ContextTest ctx;
    private float timer;
    private float interfalUse = 3f;
  
    public override Status Evaluate()
    {
        if (timer <= Time.time)
        { 
            timer = Time.time + interfalUse;
            ctx.RemoveFood(1);
            ctx.AddEnergy(2);
               
            return Status.Success;
        }
        else return Status.Running; 
    }
}
public class WorkTask : NodeBase
{ 
    public WorkTask(ContextTest ctx)
    {
        this.ctx = ctx;
    }
    ContextTest ctx;
    private float timer;
    private float interfalWork = 3f;
    public override Status Evaluate()
    {
        
        if (timer <= Time.time)
        { 
            timer = Time.time + interfalWork;
            ctx.RemoveEnergy(1);   
            return Status.Success;
        }
        else return Status.Running; 
    }
}