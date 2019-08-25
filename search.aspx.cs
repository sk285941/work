using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String name = Request.QueryString["name"];
        String date1 = Request.QueryString["date1"];
        String date2 = Request.QueryString["date2"];
        String choice = Request.QueryString["choice"];

        if (choice == "1") 
        {
            //物
            AccessDataSource1.SelectCommand =
                "SELECT c.ShipCountry, Sum(a.UnitPrice) AS 總計" +
                "FROM [Order Details] AS a, Products AS b , Orders AS c" +
                "WHERE b.ProductName = '" + name + "' AND b.ProductID = a.ProductID AND c.OrderDate Between #" + date1 + "# And #" + date2 + "#" +
                "GROUP BY  c.ShipCountry" +
                "ORDER BY Sum(a.UnitPrice) DESC";
        }
        else if (choice == "2")
        {
            //地
            AccessDataSource1.SelectCommand =
                "SELECT distinct  b.ProductName, Sum(a.UnitPrice) AS 總計" +
                "FROM [Order Details] AS a, Products AS b , Orders AS c, Categories AS d" +
                "WHERE c.ShipCountry = '" + name + "' AND c.OrderID = a.OrderID AND c.OrderDate Between #" + date1 + "# And #" + date2 + "# AND a.ProductID = b.ProductID" +
                "GROUP BY  c.ShipCountry, b.ProductName" +
                "ORDER BY Sum(a.UnitPrice) DESC";
        }
        else if (choice == "3")
        {
            //時
            AccessDataSource1.SelectCommand =
                "SELECT Sum(a.Freight) AS 總計" +
                "FROM Orders AS a" +
                "WHERE (((a.OrderDate) Between #" + date1 + "# And #" + date2 + "#))";
        }
        else if (choice == "4")
        {
            //事
            AccessDataSource1.SelectCommand =
                "SELECT b.CompanyName, a.ProductName, a.QuantityPerUnit, a.UnitPrice" +
                "FROM Products AS a, Suppliers AS b" +
                "WHERE b.CompanyName LIKE '" + name + "' AND b.SupplierID = a.SupplierID";
        }
        else if (choice == "5")
        {
            //人
            AccessDataSource1.SelectCommand = 
                "SELECT a.LastName AS 員工, Sum(b.Freight) AS 總計 FROM Employees AS a, Orders AS b "+
                "WHERE (((a.LastName)='" + name + "') AND ((b.EmployeeID)=[a].[EmployeeID]) AND ((b.[OrderDate]) Between #" + date1 + "# And #" + date2 + "#)) "+
                "GROUP BY a.LastName, a.EmployeeID";
        }
        
        
        
        
        //時 SELECT Sum(a.Freight) AS 總計 FROM Orders AS a WHERE (((a.OrderDate) Between #7/1/1996# And #7/31/1996#))
        /*AccessDataSource1.SelectCommand = 
            "SELECT Sum(a.Freight) AS 總計 " + 
            "FROM Orders AS a " +
            "WHERE (((a.OrderDate) Between #" + date1 + "# And #" + date2 + "#));";*/
       


    }
}
