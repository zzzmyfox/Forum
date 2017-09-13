using System;

using Xamarin.Forms;
using SQLite;

namespace myForum
{
    public class ItemData
    {
    	[PrimaryKey, AutoIncrement]
    	public int ID { get; set; }
    	public string Text { get; set; }
    	public string Description { get; set; }
    	public bool Read { get; set; }
    }
}

