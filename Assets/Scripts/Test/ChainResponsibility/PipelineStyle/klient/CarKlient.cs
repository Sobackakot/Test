namespace Pipeline.Service.Client
{
    public class CarKlient : IClient
    {
        public ServiceRequirements Requirements { get; set; }

        public bool IsServiceComplete()
        {
            return Requirements == ServiceRequirements.None;
        }
    }

}
