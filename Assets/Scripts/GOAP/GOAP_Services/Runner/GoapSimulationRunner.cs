using EntityAI.GOAP.Action;
using EntityAI.GOAP.Goal;
using EntityAI.GOAP.Planer;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ... (unchanged properties) ...
public class GoapSimulationRunner : MonoBehaviour
{
    [Header("Initial State")]
    public float initialHunger = 80f;
    public float initialEnergy = 100f;
    public int initialRawFood = 0;
    public int initialCookedFood = 0;
    public int initialReserve = 10;
    public int maxTicks = 50;

    private IBlackboard _bb;
    private GOAPAgent _agent;

    private void Start()
    {
        Initialize();
        // _agent.StartTicking() is called in Initialize, but we keep the safety call
        if (_agent != null) _agent.StartTicking();
        StartCoroutine(StopAfter(maxTicks * 0.6f + 5f));
    }

    private void OnDestroy() { if (_agent != null) _agent.StopTicking(); }
    private IEnumerator StopAfter(float t) { yield return new WaitForSeconds(t); if (_agent != null) _agent.StopTicking(); Debug.Log("[Simulation] Stopped executor (safety)."); }


    private readonly IHeuristicStrategy _heuristicStrategy;// null------------------------------------------
    private readonly IStateHasher _hasher; // null------------------------------------------
    private void Initialize()
    {
        // 1. Создание DI-сервисов
        var randomizer = new RandomizerService();
        var itemFactory = new ItemFactoryService(randomizer);
        var contextUpdater = new ContextUpdaterService(randomizer);
        var goalStrategy = new ReactiveGoalStrategy();
        var planner = new GOAPPlanner(_heuristicStrategy, _hasher);

        // 2. Инициализация Blackboard
        _bb = new Blackboard();
        _bb.Register(new HungerProperty(initialHunger));
        _bb.Register(new EnergyProperty(initialEnergy));
        _bb.Register(new RawFoodProp(initialRawFood));
        _bb.Register(new CookedFoodProp(initialCookedFood));
        _bb.Register(new FoodReserveProp(initialReserve));
        _bb.Register(new WoodProp(0));

        // Начальное снаряжение
        _bb.Inventory.Add(itemFactory.CreateFound(ItemType.FoundAxe));
        _bb.Inventory.Add(itemFactory.CreateFound(ItemType.Crossbow));
        _bb.Inventory.Add(new Item(ItemType.Bolt, 100f));
        _bb.Inventory.Add(new Item(ItemType.Cookware, 100f));
        _bb.Inventory.Add(new Item(ItemType.FireStarter, 100f));

        // 3. Создание и Инициализация Агента
        _agent = gameObject.GetComponent<GOAPAgent>() ?? gameObject.AddComponent<GOAPAgent>();

        // Внедрение сервисов (Service Injection)
        _agent.ServiceInitialize(planner, contextUpdater, goalStrategy);

        // Определение Действий
        var actions = new List<IGOAPAction>
            {
                new MakeToolsAction(randomizer),
                new CraftWeaponAction(randomizer),
                new FindWeaponAction(randomizer),
                new HuntAction(randomizer),
                new ChopWoodAction(randomizer),
                new LightFireAction(randomizer),
                new CookFoodAction(randomizer),
                new StoreFoodAction(randomizer),
                new EatAction(randomizer),
                new GatherBerriesAction(randomizer)
            };

        // Определение Целей
        var goals = new List<IGoapGoal>
            {
                new EatGoal(priority: 3f, threshold: 20f),
                new StockpileGoal(priority: 1f, target: 100)
            };

        // Инициализация Агента (передача состояния, действий и целей)
        _agent.Initialize(_bb, actions, goals);

        // 4. Energy estimation pass (логика остается та же, но с новыми классами)
        var tempBB = _bb.Clone();
        if (!tempBB.TryGet<EnergyProperty>(out var eTemp)) tempBB.Register(new EnergyProperty(1000f)); else eTemp.Value = 1000f;
        var plan = planner.Plan(tempBB, new EatGoal(priority: 3f, threshold: 20f), actions.Cast<IGOAPAction>().ToList());
        float requiredEnergyEstimate = initialEnergy;

        if (plan != null && plan.Count > 0)
        {
            var simBB = _bb.Clone();
            float sumDur = 0f;
            foreach (var a in plan)
            {
                Item relevant = null;
                if (a.RequiredItems != null && a.RequiredItems.Length > 0)
                {
                    foreach (var t in a.RequiredItems)
                    {
                        var it = simBB.Inventory.GetBest(t);
                        if (it != null) { relevant = it; break; }
                    }
                }
                float quality = relevant != null ? relevant.QualityPercent : 100f;
                float qualityFactor = Mathf.Clamp01((80f - quality) / 100f);
                float timeMultiplier = 1f + qualityFactor * 0.4f;
                float estDur = Mathf.Clamp(a.BaseDuration, 0.1f, 120f) * timeMultiplier;
                sumDur += estDur;
                a.ApplyEffects(simBB);
            }
            requiredEnergyEstimate = sumDur * 2f + 10f;
        }

        float cap = 1000f;
        float newEnergy = Mathf.Clamp(Mathf.Max(initialEnergy, requiredEnergyEstimate), 0f, cap);
        if (!_bb.TryGet<EnergyProperty>(out var eReal)) _bb.Register(new EnergyProperty(newEnergy)); else { eReal.Value = newEnergy; _bb.Register(eReal); }

        Debug.Log($"[Simulation] Initialized. Energy set to {newEnergy:F1}. BB: {_bb.DebugDump()}");
    }
}
