import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { ReportItem } from '../models/repors-item.component';
import { AccountantItem } from '../models/accountant-item';
import { CompanyItem } from '../models/company-item';

 
@Injectable({
  providedIn: 'root'
})
export class ReportService {
  private url = environment.apiUrl + 'api/reports/';

  constructor(private http: HttpClient) { }

  getReports(): Observable<Array<ReportItem>> {
    return this.http.get<Array<ReportItem>>(this.url);
  }

  getReport(reportid: number): Observable<ReportItem> {
    return this.http.get<ReportItem>(`${this.url}${reportid}`);
  }

  getAccountants(): Observable<Array<AccountantItem>> {
    return this.http.get<Array<AccountantItem>>(environment.apiUrl + 'api/accountant/');
  }

  getComapnys(): Observable<Array<CompanyItem>> {
    return this.http.get<Array<CompanyItem>>(environment.apiUrl + 'api/companys/');
  }

  addReport(report: ReportItem): Observable<ReportItem> {
    return this.http.post<ReportItem>(`${this.url}`, report);
  }

  updateReport(report: ReportItem): Observable<Object> {
    return this.http.put<Object>(`${this.url}${report.id}`, report);
  }

  deleteReport(reportid: number): Observable<Object> {
    return this.http.delete<Object>(`${this.url}${reportid}`);
  }
}
