namespace ToDo_ConsoleApp.Data
{
    public class ToDoSequencer
    {
        private static int _staticId = 0;


        public static int NextId()
        {
            return ++_staticId;
        }


        public static void Reset()
        {
            _staticId = 0;
        }
    }
}
