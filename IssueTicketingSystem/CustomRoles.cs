namespace IssueTicketingSystem
{
    public static class CustomRoles
    {
        
        public const string Customer = "Customer";
        public const string User = "User";
        public const string Administrator = "Administrator";

        public static string ListOfRoles(params string[] roles)
        {
            return string.Join(",",roles);
        }
    }
}