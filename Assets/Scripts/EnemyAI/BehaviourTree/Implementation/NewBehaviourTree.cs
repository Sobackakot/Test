using BehaviourFree.Node;
using BehaviourFree;
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
                new HasFoodCondition(useFood, ctx)),
            searchFood
        );
         
        var workSequence = new SequenceNode(
            new Not(
                new HangerCondition(useFood, ctx)),
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
 
    public void RemoveEnergy(int energyAmount)
    {
        if(isHasEnergy)
        this.energyAmount -= energyAmount;
        UpdateHungryState();
        UpdateEnergyState();
    }
    public void AddEnergy(int energyAmount)
    { 
        this.energyAmount += energyAmount;
        UpdateHungryState();
        UpdateEnergyState();
    }
    public void RemoveFood(int foodAmount)
    {
        if (isHasFood)
            this.foodAmount -= foodAmount;
        UpdateFoodState();
    }
    public void AddFood(int foodAmount)
    {
        if(isFoodFound)
            this.foodAmount += foodAmount;
        UpdateFoodState();
    }
    private void UpdateFoodState()
    {
        if (foodAmount >= 1)
            isHasFood = true;
        else isHasFood = false;
    }
    private void UpdateHungryState()
    {
        if (energyAmount < 2 || foodAmount == 0)
            isHungry = false;
        else isHungry = true;
    }
    private void UpdateEnergyState()
    {
        if (energyAmount >= 1)
           isHasEnergy = true;
        else isHasEnergy = false;
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
        Debug.Log("EnergyCondition " + ctx.isHasEnergy);
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
        Debug.Log("HangerCondition " + ctx.isHungry);
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
        Debug.Log("HasFoodCondition " + ctx.isHasFood);
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
        Debug.Log("Searching Food Task");
        ctx.SetStateFindFood(Random.value > 0.5f ? true : false);
        if (ctx.isFoodFound && timer <= Time.time) 
        {
            Debug.Log("Search Food Found Success");
            timer = Time.time + interfalSearch;
            ctx.AddFood(6); 
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
             
            Debug.Log("Using Food Task");

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
            Debug.Log("Working Task");

            return Status.Success;
        }
        else return Status.Running; 
    }
}