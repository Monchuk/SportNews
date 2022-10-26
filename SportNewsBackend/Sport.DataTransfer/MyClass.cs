namespace SportNewsBackend.Sport.DataTransfer
{
    public class MyClass
    {
        private int id;
        private string name;
        public MyClass(int id, string name) 
        {
            this.id = id;
            this.name = name;
            ToString();
        }
       
        public override string ToString()
        {
            return "Hello this is SportNews";
        }
    }
}
