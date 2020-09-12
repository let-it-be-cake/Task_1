namespace Excel.Interfaces
{
    internal interface IWrite
    {
        void Write(System.Data.DataTable dataTable,
            string path,
            int rowShift = 1,
            int columnShift = 1);
    }
}