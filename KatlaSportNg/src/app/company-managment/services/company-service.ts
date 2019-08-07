import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { CompanyItem } from '../models/company-item';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  private url = environment.apiUrl + 'api/companys/';

  constructor(private http: HttpClient) { }

  getCompanys(): Observable<Array<CompanyItem>> {
    return this.http.get<Array<CompanyItem>>(this.url);
  }

  getCompany(companyid: number): Observable<CompanyItem> {
    return this.http.get<CompanyItem>(`${this.url}${companyid}`);
  }

  addCompany(company: CompanyItem): Observable<CompanyItem> {
    return this.http.post<CompanyItem>(`${this.url}`, company);
  }

  updateCompany(company: CompanyItem): Observable<Object> {
    return this.http.put<Object>(`${this.url}${company.id}`, company);
  }

  deleteCompany(companyid: number): Observable<Object> {
    return this.http.delete<Object>(`${this.url}${companyid}`);
  }
}
