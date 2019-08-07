import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { AccountantItem } from '../models/accountant-item';

@Injectable({
  providedIn: 'root'
})
export class AccountantService {
  private url = environment.apiUrl + 'api/accountant/';

  constructor(private http: HttpClient) { }

  getAccountants(): Observable<Array<AccountantItem>> {
    return this.http.get<Array<AccountantItem>>(this.url);
  }

  getAccountant(accountantid: number): Observable<AccountantItem> {
    return this.http.get<AccountantItem>(`${this.url}${accountantid}`);
  }

  addAccountant(accountant: AccountantItem, file: File): Observable<AccountantItem> {
      console.log(file);
    const formdata = new FormData();
    formdata.append('Image', file);
    formdata.append('data',JSON.stringify(accountant));
    return this.http.post<AccountantItem>(`${this.url}`, formdata);
  }

  updateAccountant(accountant: AccountantItem, file: File): Observable<Object> {
    const formdata = new FormData();
    console.log(file);
    formdata.append('Image', file);
    formdata.append('data',JSON.stringify(accountant));
    return this.http.put<Object>(`${this.url}${accountant.id}`, formdata);
  }

  deleteAccountant(accountantid: number): Observable<Object> {
    return this.http.delete<Object>(`${this.url}${accountantid}`);
  }
}
