using System;

using Xamarin.Forms;
using SQLite;

namespace myForum
{
    public class ItemData
    {
    	[PrimaryKey, AutoIncrement]
    	public int ID { get; set; }
    	public string Name { get; set; }
    	public string Notes { get; set; }
    	public bool Done { get; set; }
    }
}

