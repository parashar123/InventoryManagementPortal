# InventoryManagementPortal

Steps important for configuring and using the application.

**
*** Required: SQL SERVER, VS CODE, VISUAL STUDIO, NODE JS
**

1) Run the sql scripts in correct sequence in sql server i.e createDB followed by creating Product table.
Path: .....InventoryManagementPortal\ImportantFiles

2) Change the connection string in the web.config file for WebApplication1(InventoryApi poject).

 <connectionStrings>
    <add name ="InventoryAddDB" connectionString="Data Source=.;Initial Catalog=InventoryDB; Integrated Security=true" providerName="System.Data.SqlClient"/>
  </connectionStrings>

3) Launch the above service. Make sure api service is up and running.

4) Go the ....\InventoryApp\InventoryUI\ShopBridgeInventorySolution and type cmd in the address path. 

5) execute following:
   ng serve

6) load Shop bridge application from the mentioned port by accessing following Url:
    http://localhost:4200/product

7) Application default page only shows Application name and shows a welcome note.

8) route to http://localhost:4200/product

9) Click on Add Prodcut for adding products with photo upload feature.

10) Click on pencil icon to edit and open the product detail page.
11) click on delete icon to delete the product from our inventory.
12) Filter/Search and Sorting features are available.