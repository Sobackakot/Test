using EntityAI.GOAP.Goal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// StockpileSubGoal: Динамически генерируемая подцель для достижения следующей "партии" резерва.
// ЭТО И ЕСТЬ РЕАЛИЗАЦИЯ BATCH-СТРАТЕГИИ ИЗ РЕФЕРЕНСА.
public class StockpileSubGoal : GOAPGoal
{
    public override string Name => "AchieveStockpileBatch";
    public readonly int SubTarget;
    public StockpileSubGoal(float priority, int subTarget) : base(priority) { SubTarget = subTarget; }
    public override bool IsSatisfied(IBlackboard bb)
    {
        if (!bb.TryGet<FoodReserveProp>(out var fr)) return false;
        return fr.Value >= SubTarget;
    }
}