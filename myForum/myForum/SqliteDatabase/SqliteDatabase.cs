using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace myForum
{
    public class SqliteDatabase
    {
        //Initialise the connection to the database
		readonly SQLiteAsyncConnection database;

        //Get the database path
		public SqliteDatabase(string dbPath)
		{
			//Get the database path
			database = new SQLiteAsyncConnection(dbPath);
            //Create table
            database.CreateTableAsync<ItemData>().Wait();
		}

		//      //Get data from database and add to list
		//public Task<List<ItemData>> GetItemsAsync()
		//{
		//	return database.Table<ItemData>().ToListAsync();
		//}

		//      //SQL query which is using to markdown which one is read by user
		//public Task<List<ItemData>> GetItemsNotDoneAsync()
		//{
		//	return database.QueryAsync<ItemData>("SELECT * FROM [ItemData] WHERE [IsUserLoggedIn] = 0");
		//}
		//      //Query of select the data from ID
		//public Task<ItemData> GetItemAsync(int id)
		//{
		//	return database.Table<ItemData>().Where(i => i.ID == id).FirstOrDefaultAsync();
		//}



		public Task<ItemData> GetItemAsync()
		{
            return database.Table<ItemData>().FirstOrDefaultAsync();
		}


		//Insert data to database 
		public Task<int> SaveItemAsync(ItemData item)
		{
   //         if (item.Username != null)
			//{
			//	return database.UpdateAsync(item);
			//}
			//else
			//{
				return database.InsertAsync(item);
			//}
		}

        //Delete data from database
		public Task<int> DeleteItemAsync(ItemData item)
		{
			return database.DeleteAsync(item);
		}
	}
}

