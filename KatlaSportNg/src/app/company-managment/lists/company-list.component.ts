import { Component, OnInit } from '@angular/core';
import { CompanyItem } from '../models/company-item';
import { CompanyService } from '../services/company-service';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.css']
})
export class CompanyListComponent implements OnInit {

  companys: CompanyItem[];

  constructor(private companyService: CompanyService) { }

  ngOnInit() {
    this.getCompanys();
  }

  getCompanys() {
    this.companyService.getCompanys().subscribe(h => this.companys = h);
  }

  onDelete(companyId: number) {
    this.companyService.deleteCompany(companyId).subscribe(p => this.getCompanys());   
  }
}
