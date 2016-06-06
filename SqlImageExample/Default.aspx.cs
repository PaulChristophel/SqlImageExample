using System;
using System.Web;
using System.Web.UI;

namespace SqlImageExample
{
	
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			IMG_EX.ImageUrl = "UserImage.aspx";
		}
	}
}

