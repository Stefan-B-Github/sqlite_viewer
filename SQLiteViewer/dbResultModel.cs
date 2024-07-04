using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace SQLiteViewer;

public class dbResultModel : PageModel
{
    public Dictionary<int, string> DBResultList { get; set; }

    public void OnGet()
    {
        DBResultList = DBConnection.RunSelect(5, 10);  
    }
}