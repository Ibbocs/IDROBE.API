using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Validations.SendQueriesValidations;

public class SendQueryModelValidationMessageConstants
{
    public const string Query_Info = "Name required and can be up to 256 characters";
    public const string Store_Logos = "At least one logo file must be provided.";
    public const string Store_Logos_Format = "All logo files must be in JPEG or PNG format.";
    public const string Query_Info_Store_Name_Empty = "Store name cannot be empty.";
    public const string Query_Info_Phone_Number_Empty = "Phone number cannot be empty.";
    public const string Query_Info_Phone_Number_Matches = "Phone number must be in the format +994 XX XXX XXXX.";
    public const string Query_Info_Email_Empty = "Email cannot be empty.";
    public const string Query_Info_Email_Format = "Invalid email address format.";
    public const string Query_Info_Addres_Empty = "Address cannot be empty.";
    public const string Query_Info_Addres_Length = "Address must be at most 100 characters.";
}
