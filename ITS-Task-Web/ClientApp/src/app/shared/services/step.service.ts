import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Step } from '../models/Step';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StepService {

  constructor(private httpClient:HttpClient) { }

  getAll():Observable<Step[]>{
    return this.httpClient.get<Step[]>(environment.apiUrl+"/Step");
  }

  getById(stepId:number):Observable<Step>{
    return this.httpClient.get<Step>(environment.apiUrl+"/Step/GetById/"+stepId)
  }

  createStep(step:Step):Observable<Step>{
    return this.httpClient.post<Step>(environment.apiUrl+"/Step",step);
  }

  updateStep(step:Step):Observable<Step>{
    return this.httpClient.put<Step>(environment.apiUrl+"/Step",step);
  }

  deleteStep(stepId:number):Observable<any>{
    return this.httpClient.delete<any>(environment.apiUrl+"/Step/Delete/"+stepId);
  }
}
