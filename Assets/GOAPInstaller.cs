using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GOAPInstaller", menuName = "Installers/GOAPInstaller")]
public class GOAPInstaller : ScriptableObjectInstaller<GOAPInstaller>
{
    public override void InstallBindings()
    {
        // 1. Привязка AgentContext (Монобехейвиор)
        // FromComponentInHierarchy() находит компонент в иерархии сцены.
        Container.Bind<AgentContext>().FromComponentInHierarchy().AsSingle();

        // 2. Привязка Стратегии Выбора Цели (Одиночная)
        // Предполагаем, что HighestPriorityStrategy чистый POCO и реализует IGoalSelectionStrategy
        Container.Bind<IGoalSelectionStrategy>().To<HighestPriorityStrategy>().AsSingle();

        // 3. Привязка Базовых Сущностей
        BindSensors();
        BindGoals();
        BindActions();

        // 4. Привязка GOAPAgent (Главный Контроллер)
        // GOAPAgent должен быть привязан последним, так как он зависит от всех вышеперечисленных
        Container.Bind<GOAPAgent>()
                 .AsSingle()
                 .NonLazy(); // Создать сразу, не ждать первого запроса
    }

    private void BindSensors()
    {
        // Все конкретные сенсоры привязываются к базовому классу WorldFactSensor.
        // AsCached() гарантирует, что Zenject создаст их один раз.
        // Они будут собраны Zenject'ом в List<WorldFactSensor> для инъекции.
        Container.Bind<WorldFactSensor>().To<HungerSensor>().AsCached();
        // Container.Bind<WorldFactSensor>().To<WoodSensor>().AsCached();
    }

    private void BindGoals()
    {
        // Все конкретные цели привязываются к базовому классу GOAPGoal.
        // AsCached() гарантирует, что Zenject создаст их один раз.
        Container.Bind<GOAPGoal>().To<BeFedGoal>().AsCached();
        // Container.Bind<GOAPGoal>().To<BeWarmGoal>().AsCached();
    }

    private void BindActions()
    {
        // Все конкретные действия привязываются к базовому классу GOAPAction.
        // AsCached() гарантирует, что Zenject создаст их один раз.
        Container.Bind<GOAPAction>().To<GOAPLightFireAction>().AsCached();
        Container.Bind<GOAPAction>().To<GOAPEatAction>().AsCached();
        Container.Bind<GOAPAction>().To<GOAPChopWoodAction>().AsCached();
        // Container.Bind<GOAPAction>().To<GOAPMoveToResourceAction>().AsCached();
    }
}