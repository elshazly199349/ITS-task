import { Injectable } from '@angular/core';
import { Item } from '../models/Item';
import { HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  constructor(private httpClient:HttpClient) { }

getById(id:number):Observable<Item>{
  return this.httpClient.get<Item>(environment.apiUrl+"/Item/GetById/"+id);
}

getByStepId(stepId:number):Observable<Item[]>{
  return this.httpClient.get<Item[]>(environment.apiUrl+"/Item/GetByStepId/"+stepId);
}

createItem(item:Item):Observable<Item>{
  return this.httpClient.post<Item>(environment.apiUrl+"/Item",item);
}

updateItem(item:Item):Observable<Item>{
  return this.httpClient.put<Item>(environment.apiUrl+"/Item",item);
}

DeleteItem(itemId:number):Observable<any>{
  return this.httpClient.delete<any>(environment.apiUrl+"/Item/Delete/"+itemId);
}

getAll():Observable<Item[]>{
  return this.httpClient.get<Item[]>(environment.apiUrl+"/item");
}
}