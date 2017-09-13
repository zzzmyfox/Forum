﻿using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace myForum
{
    public class SqliteDatabase
    {
		readonly SQLiteAsyncConnection database;

		public SqliteDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ItemData>().Wait();
		}

		public Task<List<ItemData>> GetItemsAsync()
		{
			return database.Table<ItemData>().ToListAsync();
		}

		public Task<List<ItemData>> GetItemsNotDoneAsync()
		{
			return database.QueryAsync<ItemData>("SELECT * FROM [ItemData] WHERE [Done] = 0");
		}

		public Task<ItemData> GetItemAsync(int id)
		{
			return database.Table<ItemData>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(ItemData item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else
			{
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItemAsync(ItemData item)
		{
			return database.DeleteAsync(item);
		}
	}
}

