namespace Rupor.DataAccess.Context
{
    public interface IDataContext
    {
        IDatabaseContext GetContext();
    }
}