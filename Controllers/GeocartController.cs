using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace asp_mvc_webmap.Controllers;

public class GeocartController : Controller
{
    // 
    // GET: /HelloWorld/
    public string Index()
    {
        return "This is my default action...";
    }
    // 
    // GET: /HelloWorld/Welcome/ 
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }
}