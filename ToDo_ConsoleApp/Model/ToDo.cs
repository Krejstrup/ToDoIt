namespace ToDo_ConsoleApp.Model
{
    public class ToDo
    {

        private readonly int _todoId;
        private string _description;
        private bool _done;
        private Person _assignee;


        /// <summary>
        /// A constructor method for create a new ToDo.
        /// </summary>
        /// <param name="todoId">The unique Id for this ToDo task.</param>
        /// <param name="description">The description of this ToDo task.</param>
        public ToDo(int theToDoId = 0, string theToDoDescription = "")
        {
            _todoId = theToDoId;
            // I dont want to have an null assigned description, though "" is excepted, for now
            _description = theToDoDescription == null ? "" : theToDoDescription;
            _done = false;
            _assignee = null;
        }


        /// <summary>
        /// A get for the unique Id of this ToDo task.
        /// </summary>
        public int TodoId
        {
            get { return _todoId; }
        }

        /// <summary>
        /// A get for the descriptiton of this ToDo task
        /// </summary>
        public string Description
        {
            get { return _description; }
            set
            {
                if (value != null) _description = value;
            }
        }

        /// <summary>
        /// A marker of the ToDo task done or not done.
        /// </summary>
        public bool Done
        {
            get { return _done; }
            set { _done = value; }
        }

        /// <summary>
        /// A get for the person that is assigned to the ToDo task.
        /// </summary>
        public Person Assignee
        {
            get { return _assignee; }
            set { _assignee = value; }
        }
    }
}
