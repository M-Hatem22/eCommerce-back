using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL.DTOs.files;

public class uploadFileResult
{
    public bool isSucceess { get; set; }
    public string message { get; set; } = string.Empty;
    public string url { get; set; } = string.Empty;

    public uploadFileResult(bool isSuccess ,string message , string url = "")
    {
        isSucceess= isSuccess;
        this.message = message;
        this.url = url; 
    }
}
