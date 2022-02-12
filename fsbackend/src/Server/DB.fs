module Library.DB
open System

type LoanInfo={

        Id:int 
        LoanedDate:DateTime 
        LoanedUser:User 

    }
and Book=
    {
        Id :int
        Listing :BookListing
        LoanInfo:Option<LoanInfo> 

    }
//This annotation makes this flattened into the parent instead of being it's
and BookListing=
    {
        Id:int 
        Description:string 
        Title:string 
        Author:string 
        Books:List<Book>  
        //List<Book> reservedBooks  = new();
        /// <summary>
        /// List of userIds of users who have reserved the book
        /// </summary>
        reservations:List<User> 
    }
and User=
    {
        Id:int 
        LoanedBooks:List<Book> 
        /// <summary>
        /// List of bookListingIDs. NOT bookIDs
        /// </summary>
        //List<int> ReservedBooks  = new();

    }
