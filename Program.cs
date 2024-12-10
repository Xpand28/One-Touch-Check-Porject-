namespace OneTouchCheck
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static int userID;
        public static int selID;
        public static int createdID;
        public static string fname;

        //public static string ConnectionString = "Data Source=ACE;Initial Catalog=Comtendance;Persist Security Info=True;User ID=sa;Password=ccbc-2024;";
        public static string ConnectionString = "Data Source=DESKTOP-2RSHEU9\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;Initial Catalog=Comtendance";

        public static int isAdmin;
        public static int isAdvicer;
        public static int isTeacher;
        public static int isHeadTeacher;
        public static string selStrand;
        public static int selSub;

        public static string selsubj;
        public static Form prevFormInstance;
        public static Form prevFormInstance1;

        public static Form teachersubject = new TeacherSubject();

        public static int selsubjId;
        internal static object selectedTeacher;
        public static int selsubjblk;
        public static int selsubjDays;

        public static int selsubjIdReport;

        public static int mAdvisory = 0;
        internal static string? lname;
        internal static string? mname;

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());

        }
    }
}