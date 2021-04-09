namespace Videop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, GenreType, ReleaseDate, DateAdded, NumberInStock) VALUES (1, 'Comedy', 1/1/2009, 1/4/2016, 5)");
            Sql("INSERT INTO Genres (Id, GenreType, ReleaseDate, DateAdded, NumberInStock) VALUES (2, 'Action', 1/1/2008, 1/4/2017, 15)");
            Sql("INSERT INTO Genres (Id, GenreType, ReleaseDate, DateAdded, NumberInStock) VALUES (3, 'Sci-Phi', 1/1/2006, 1/4/2018, 50)");
            Sql("INSERT INTO Genres (Id, GenreType, ReleaseDate, DateAdded, NumberInStock) VALUES (4, 'Drama', 1/1/2003, 1/4/2019, 25)");
        }
        
        public override void Down()
        {
        }
    }
}

//Sql("INSERT INTO Genres (Id, GenreType, ReleaseDate, DateAdded, NumberInStock) VALUES (1, 'Comedy', 'Friday, November 6, 2009', 'Wednesday, May 4, 2016', 5)");
//Sql("INSERT INTO Genres (Id, GenreType, ReleaseDate, DateAdded, NumberInStock) VALUES (2, 'Action', 'Friday, November 4, 2008', 'Wednesday, May 7, 2017', 15)");
//Sql("INSERT INTO Genres (Id, GenreType, ReleaseDate, DateAdded, NumberInStock) VALUES (3, 'Sci-Phi', 'Friday, November 3, 2004', 'Wednesday, May 9, 2018', 50)");
//Sql("INSERT INTO Genres (Id, GenreType, ReleaseDate, DateAdded, NumberInStock) VALUES (4, 'Drama', 'Friday, November 12, 2013', 'Wednesday, May 10, 2019', 25)");