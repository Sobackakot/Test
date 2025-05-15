public interface IAction <in T> where T : IContext
{
    bool CanExecute(T context);
    void Execute(T context);
}
