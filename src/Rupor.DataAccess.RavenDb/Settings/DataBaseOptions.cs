namespace Rupor.DataAccess.RavenDb.Settings
{
    public class DatabaseOptions
    {
        public int MaxReqeustPerSession { get; set; } = 32;
        public bool NoTracking { get; set; }
        public bool NoCaching { get; set; }
        public bool UseOptimisticConcurrency { get; set; } = true;
        public string DataBase { get; set; }
        public string[] Urls { get; set; }
    }
}