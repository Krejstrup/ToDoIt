namespace ToDo_ConsoleApp.Data
{
    public class PersonSequencer
    {
        private static int _staticId = 0;

        public static int getNext()
        {
            return ++_staticId;
        }

        public static void Reset()
        {
            _staticId = 0;
        }

    }
}
