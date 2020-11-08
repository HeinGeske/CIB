import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddEntryModel } from 'src/app/models/addEntry.model';
import { ApiResonseMopdel } from 'src/app/models/apiresponse.model';
import { EntryModel } from 'src/app/models/entry.model';
import { SearchEntriesModel } from 'src/app/models/searchEntries.model';

@Injectable({
  providedIn: 'root'
})
export class EntryService {
  private baseUrl: string = "http://localhost:64357/api/Entry";
  constructor(private http: HttpClient) { }

  searchEntries(model:SearchEntriesModel): Observable<ApiResonseMopdel<EntryModel[]>>{
    return this.http.post<ApiResonseMopdel<EntryModel[]>>(`${this.baseUrl}/SearchEntries`,model);
  }
  addEntry(model:AddEntryModel): Observable<ApiResonseMopdel<number>>{
    return this.http.post<ApiResonseMopdel<number>>(`${this.baseUrl}/AddEntry`,model);
  }
}
