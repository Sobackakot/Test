
// FoodReserveProp будет использоваться в нашем EatAction для "неприкосновенного запаса".
using EntityAI.GOAP.WorldState;

public class FoodReserveProp : WorldProperty<int> 
{ 
    public FoodReserveProp(int v) : base(v) 
    { 
    } 
}