namespace security.Pages;

public static class Config
{
    private static string _connectionString;
    public static string ConnectionString
    {
        get
        {
            if (_connectionString == null)
            {
                var fileName = Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData), "wasecurity", "config.txt");
                if (File.Exists(fileName))
                {
                    _connectionString = File.ReadAllText(fileName);
                }
                else
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                    File.Create(fileName).Close();
                    StreamWriter writer = new(fileName);
                    writer.WriteLine("server=localhost;user=root;password=neurit159;database=security");
                    writer.Close();
                    _connectionString = "server=localhost;user=root;password=neurit159;database=security";
                }
            }

            return _connectionString;
        }
        set
        {
            _connectionString = value;
        }
    }
}