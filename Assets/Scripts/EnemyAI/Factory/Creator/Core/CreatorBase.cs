using EntityAI.Config;
using EntityAI.Factory;
using EntityAI.React;
using UnityEngine;


namespace EntityAI.Creator
{
    public abstract class CreatorBase : ICreator
    {

        public CreatorBase(ICreatorEntityAISubject subjectCreator)
        {
            this.subjectCreator = subjectCreator;
            pool = new(); 
        }
        private ICreatorEntityAISubject subjectCreator;
        public PoolSystem pool { get; }
        public void Creating(IFactory factory)
        { 
            IEntity entity = factory.NewEntity(pool);  

            subjectCreator.InvokeAction(CreatorActionType.CreatorEntity, entity);
        }
        public void CreatingPool(int count, EntityConfige config)
        {
            var entitys = pool.InitializePool(count, config);  
        }
    }
}


