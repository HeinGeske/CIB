import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResonseMopdel } from 'src/app/models/apiresponse.model';
import { PhonebookModel } from 'src/app/models/phonebook.model';

@Injectable({
  providedIn: 'root'
})
export class PhonebookService {

  constructor(private http: HttpClient) { }
  getEntries() : Observable<ApiResonseMopdel<PhonebookModel>> 
  {
    return this.http.get<ApiResonseMopdel<PhonebookModel>>("http://localhost:64357/api/Phonebook/GetEntries");
  }
}
