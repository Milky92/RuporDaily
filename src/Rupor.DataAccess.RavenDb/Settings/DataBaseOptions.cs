namespace Rupor.DataAccess.RavenDb.Settings
{
    public class DatabaseOptions
    {
        public int MaxReqeustPerSession { get; set; }
        public bool NoTracking { get; set; }
        public bool NoCaching { get; set; }
        public string DataBase { get; set; }
        public string[] Urls { get; set; }
    }
}