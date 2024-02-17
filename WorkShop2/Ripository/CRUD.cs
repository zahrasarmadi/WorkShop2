using Dapper;
using System;
using System.Data.SqlClient;
using WorkShop2.Entities;
using WorkShop2.ViewModel;

namespace WorkShop2.Ripository;

public class CRUD
{
    public List<Product> GetAllProducts()
    {
        string connectionString = @"Server=DESKTOP-BKH8GT2\SQLEXPRESS;Integrated Security=true;Database=WorkShop2;";
        using var cn = new SqlConnection(connectionString);
        var sql = $"Select * from dbo.Product";
        var cmd = new CommandDefinition(sql);
        var result = cn.Query<Product>(cmd);
        return result.ToList();
    }
    public Product GetProduct(int id)
    {
        string connectionString = @"Server=DESKTOP-BKH8GT2\SQLEXPRESS;Integrated Security=true;Database=WorkShop2;";
        using var cn = new SqlConnection(connectionString);
        var sql = $"Select * from dbo.Product Where Id=@id";
        var cmd = new CommandDefinition(sql, new { id = id });

        var result = cn.QueryFirstOrDefault<Product>(cmd);
        if (result != null)
        {
            return result;
        }
       return new Product();

    }

    public List<Category> GetAllCategory()
    {
        string connectionString = @"Server=DESKTOP-BKH8GT2\SQLEXPRESS;Integrated Security=true;Database=WorkShop2;";
        using var cn = new SqlConnection(connectionString);
        var sql = $"Select * from dbo.Category";
        var cmd = new CommandDefinition(sql);
        var result = cn.Query<Category>(cmd);
        return result.ToList();
    }


    public void AddProduct(AddModelView addModelView)
    {
        string connectionString = @"Server=DESKTOP-BKH8GT2\SQLEXPRESS;Integrated Security=true;Database=WorkShop2;";
        string sql = "INSERT dbo.Product(Name,Title,Description,Price,Color,CategoryId)VALUES(@Name,@Title,@Description,@Price,@Color,@CategoryId)";
        using var cn = new SqlConnection(connectionString);
        var command = new CommandDefinition(sql, addModelView);
        cn.Execute(command);
    }

    public void UpdateProduct(Product product)
    {
        int targetproducts =product.Id;
        string connectionString = @"Server=DESKTOP-BKH8GT2\SQLEXPRESS;Integrated Security=true;Database=WorkShop2;";
        string sql = "Update dbo.Product Set Name=@Name,Title=@Title,Description=@Description,Price=@Price,Color=@Color,CategoryId=@CategoryId Where Id=@Id";
        using var cn = new SqlConnection(connectionString);
        var command = new CommandDefinition(sql, product);
        cn.Execute(command);
    }

    public void DeleteProduct(int id)
    {
        string connectionString = @"Server=DESKTOP-BKH8GT2\SQLEXPRESS;Integrated Security=true;Database=WorkShop2;";
        string sql = "DELETE FROM Product WHERE Id=@id";
        using var cn = new SqlConnection(connectionString);
        var command = new CommandDefinition(sql,new { id=id});
        cn.Execute(command);
    }


}
