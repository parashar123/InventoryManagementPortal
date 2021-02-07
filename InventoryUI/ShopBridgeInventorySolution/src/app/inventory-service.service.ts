import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InventoryServiceService {
  readonly APIUrl="http://localhost:62766/api";
  readonly PhotoUrl = "http://localhost:62766/Photos/"
  

  constructor(private http:HttpClient) { }

  getProductList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/product');
  }

  addProduct(val:any){
    return this.http.post(this.APIUrl+ '/Product', val)
  }

  updateProduct(val:any){
    return this.http.put(this.APIUrl+ '/Product', val)
  }

  deleteProduct(val:any){
    return this.http.delete(this.APIUrl+ '/Product/'+ val)
  }

  UploadPhoto(val:any){
    return this.http.post(this.APIUrl+'/Product/SaveFile',val)
  }

  getAllProductName():Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+'/Product/GetAllProductNames')
  }
}
