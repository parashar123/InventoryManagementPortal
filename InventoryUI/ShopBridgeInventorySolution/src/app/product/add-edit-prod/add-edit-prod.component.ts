import { Component, OnInit, Input } from '@angular/core';
import { InventoryServiceService } from 'src/app/inventory-service.service';

@Component({
  selector: 'app-add-edit-prod',
  templateUrl: './add-edit-prod.component.html',
  styleUrls: ['./add-edit-prod.component.css']
})
export class AddEditProdComponent implements OnInit {

  constructor(private service: InventoryServiceService ){
    
    
  }
  @Input() prod:any;
  ProductId: string ='';
  ProductName: string ='';
  Description: string ='';
  Price: string ='';
  DateOfAdding:string ='';
  PhotoFileName: string ='';
  PhotoFilePath: string ='';

  ngOnInit(): void {
    this.loadProductList();
  }

  loadProductList(){
    this.ProductId=this.prod.ProductId;
    this.ProductName= this.prod.ProductName;
    this.Description=this.prod.Description;
    this.Price= this.prod.Price;
    this.DateOfAdding=this.prod.DateOfAdding;
    this.PhotoFileName= this.prod.PhotoFileName;
    this.PhotoFilePath= this.service.PhotoUrl + this.PhotoFileName;
  }

  addProduct(){
    var val = {ProductId: this.ProductId,
                ProductName: this.ProductName,
                Description :this.Description,
                Price : this.Price,
                DateOfAdding :this.DateOfAdding,
                PhotoFileName : this.PhotoFileName   
              };
              if(val.ProductName && val.Price && val.Description){
                this.service.addProduct(val).subscribe(res=>{
                  alert(res.toString());
              });
              }
              else{
                alert("Please provide valid input. ProductName, Price and Description are mandaory!!");
              }
                
             }

  updateProduct(){
    var val = {ProductId: this.ProductId,
                ProductName: this.ProductName,
                Description :this.Description,
                Price : this.Price,
                DateOfAdding :this.DateOfAdding,
                PhotoFileName : this.PhotoFileName              
              };
                this.service.updateProduct(val).subscribe(res=>{
                  alert(res.toString());
               });
              
              }

    uploadPhoto(event){
      var file = event.target.files[0];
      const formData: FormData = new FormData();
      formData.append('uploadedFile',file,file.name);

      this.service.UploadPhoto(formData).subscribe((data:any)=>{
        this.PhotoFileName = data.toString();
        this.PhotoFilePath= this.service.PhotoUrl + this.PhotoFileName;

      })

    }
}
