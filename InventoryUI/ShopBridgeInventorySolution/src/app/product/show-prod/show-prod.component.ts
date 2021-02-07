import { Component, OnInit } from '@angular/core';
import { InventoryServiceService } from 'src/app/inventory-service.service';

@Component({
  selector: 'app-show-prod',
  templateUrl: './show-prod.component.html',
  styleUrls: ['./show-prod.component.css']
})
export class ShowProdComponent implements OnInit {

  constructor(private service:InventoryServiceService) {
    this.ModalTitle ="";
   }

productList:any=[];

ModalTitle : string;
ActivateAddEditProdComp : boolean = false;
prod:any;

ProductIdFilter:string = "";
ProductNameFilter:string = "";
ProductListWithoutFilter: any = [];

  ngOnInit(): void {
    this.refreshProductList();
  }

  addClick(){
    this.prod={
      ProductId:0,
      ProductName:"",
      Description:"",
      Price:0,
      DateOfAdding:"",
      PhotoFileName:"anonymous.png"
    }
    this.ModalTitle="Add Product";
    this.ActivateAddEditProdComp=true;
  }

  closeClick(){
    this.ActivateAddEditProdComp=false;
    this.refreshProductList();
  }

  editClick(item){
    this.prod =item;
    this.ModalTitle="Edit Product";
    this.ActivateAddEditProdComp=true;

  }

  deleteClick(item){

    if(confirm('Are you sure??')){
      this.service.deleteProduct(item.ProductId).subscribe( data=>{
        alert(data.toString());
        this.refreshProductList();
      }
        )
    }
  }

  refreshProductList(){
    this.service.getProductList().subscribe(data=>{
      this.productList = data;
      this.ProductListWithoutFilter = data;
    });
  }

FilterFn(){
  var ProductIdFilter = this.ProductIdFilter;
  var ProductNameFilter = this.ProductNameFilter;

  this.productList = this.ProductListWithoutFilter.filter(function (el){
    return el.ProductId.toString().toLowerCase().includes(
      ProductIdFilter.toString().trim().toLowerCase()
    ) &&
    el.ProductName.toString().toLowerCase().includes(
      ProductNameFilter.toString().trim().toLowerCase()
    )

  });

  }

  sortResult(prop,asc){
    this.productList = this.ProductListWithoutFilter.sort(function(a,b){
      if(asc){
        return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 : 0);
      }
      else{
        return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 : 0);
      }
    })


  }

}
