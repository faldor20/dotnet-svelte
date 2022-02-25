namespace Library.Configuration
{
    class Paths
    {   //Subdirectory for images
        public string Images { get; set; } = "./Images/";
        public DirectoryInfo Content { get; set; } = new DirectoryInfo("./Content");
    }
class Library
    {   //Subdirectory for images
        public int LoanDays;
    }
}