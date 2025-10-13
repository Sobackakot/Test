using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// StockpileGoal: Основная, долгосрочная цель агента — накопить N единиц резерва.
public class StockpileGoal : GOAPGoal
{
    public override string Name => "AchieveFoodStockpile";
    public readonly int Target;
    public StockpileGoal(float priority, int target) : base(priority) { Target = target; }
    public override bool IsSatisfied(IBlackboard bb)
    {
        if (!bb.TryGet<FoodReserveProp>(out var fr)) return false;
        return fr.Value >= Target;
    }
}
