using CManager.Domain.Models;
using System.Numerics;

namespace CManager.Infrastructure.Services;

public class FormattingService
{
    public static string Mobile(string phone)
    {
        if (phone.Length > 9){
            string formatted = phone.Replace(" ", "");
            formatted = formatted.Insert(3, "-");
            formatted = formatted.Insert(7, " ");
            formatted = formatted.Insert(10, " ");
            return formatted;
        }
        return phone;
    }

    public static string Postalcode(string postalCode)
    {
        if (postalCode.Length == 5)
        { 
            string formatted = postalCode.Replace(" ", "");
            formatted = formatted.Insert(3, " ");
            return formatted;
        }
        return postalCode;
    }

}
