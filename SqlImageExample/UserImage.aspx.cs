using System;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using Mono.Data.Sqlite;


namespace SqlImageExample
{
	
	public partial class UserImage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			const string connectionString = "URI=file:../SqlImageExample.db";

			using (SqliteConnection con = new SqliteConnection (connectionString))
			{            
				con.Open ();

				SqliteCommand cmd = new SqliteCommand(con);  
				cmd.CommandText = "SELECT Data FROM images";
				byte[] data = (byte[])cmd.ExecuteScalar ();
				cmd.CommandText = "SELECT Name FROM images";
				string name = (string)cmd.ExecuteScalar ();
				cmd.CommandText = "SELECT MimeType FROM images";
				string mimeType = (string)cmd.ExecuteScalar ();


				Response.Buffer = true;
				Response.Charset = "";
				Response.Cache.SetCacheability (HttpCacheability.NoCache);
				Response.ContentType = mimeType;
				Response.AddHeader("content-disposition", "attachment;filename=" + name);
				Response.BinaryWrite (data);
				Response.Flush ();
				Response.End ();
			}

		}

	}
}

