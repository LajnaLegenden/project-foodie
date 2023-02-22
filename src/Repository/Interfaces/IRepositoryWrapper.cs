namespace project_foodie.Repository
{
    public interface IRepositoryWrapper
    {
        IOrderRepository Order { get; }
        Task SaveAsync();
    }
}