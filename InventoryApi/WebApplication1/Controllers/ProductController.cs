using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : ApiController
    {
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            string query = @"
                    select ProductId, ProductName, Description, Price, convert(varchar(10),DateOfAdding,120) as DateOfAdding, PhotoFileName
                    from dbo.Product";
            DataTable table = new DataTable();
            using(var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["InventoryAddDB"].ConnectionString))
                using(var cmd= new SqlCommand(query,con))
            using(var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }

       
        public string Post(Product prod)
        {
            try
            {
                string query = @"insert into dbo.product values
                        ('" + prod.ProductName + @"', '" + prod.Description + @"', '" + prod.Price + @"',
                         '" + prod.DateOfAdding + @"',
                         '" + prod.PhotoFileName + @"'
                        )
                        ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["InventoryAddDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Add!!";
            }

        }

        public string Put(Product prod)
        {
            try
            {
                string query = @"
                        update dbo.product set
                        ProductName='" + prod.ProductName + @"',
                        Description= '" + prod.Description + @"', 
                        Price= '" + prod.Price + @"',
                        DateOfAdding= '" + prod.DateOfAdding + @"',
                        PhotoFileName='" + prod.PhotoFileName + @"'
                        where ProductId=" + prod.ProductId + @"";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["InventoryAddDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Update!!";
            }
        }

            public string Delete(int id)
            {
                try
                {
                    string query = @"
                        delete from dbo.product
                        where ProductId=" + id + @"";

                    DataTable table = new DataTable();
                    using (var con = new SqlConnection(ConfigurationManager.
                        ConnectionStrings["InventoryAddDB"].ConnectionString))
                    using (var cmd = new SqlCommand(query, con))
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        da.Fill(table);
                    }

                    return "Deleted Successfully!!";
                }
                catch (Exception)
                {

                    return "Failed to Delete!!";
                }

            }
        [Route("api/Product/GetAllProductNames")]
        [HttpGet]
        public HttpResponseMessage GetAllProductNames()
        {

            string query = @"
                    select ProductName from dbo.Product";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["InventoryAddDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }

        [Route("api/Product/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Photos/"+ fileName);

                postedFile.SaveAs(physicalPath);

                return fileName;

            }
            catch (Exception)
            {

                return "anonymous.png";
            }

        }
    }
}