using System;
using System.ComponentModel.DataAnnotations;
namespace Data.Model;



public class Administrator:User
{
    
    public SuperUser Elevatedby { get; set; }
    
}

