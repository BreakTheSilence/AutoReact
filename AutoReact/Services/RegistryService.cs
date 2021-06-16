namespace AutoReact.Services
{
    public class RegistryService
    {
        private const string UserDataSubKey = @"SOFTWARE\BaitApp";

        public string ReadFromRegistry(string keyName)
        {
            var sk = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(UserDataSubKey);

            return sk?.GetValue(keyName.ToUpper())?.ToString();
        }

        public void WriteToRegistry(string keyName, string value)
        {
            var sk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(UserDataSubKey);

            sk?.SetValue(keyName.ToUpper(), value);
        }
    }
}
