import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CompanyService } from '../services/company-service';
import { CompanyItem } from '../models/company-item';

@Component({
  selector: 'app-company-form',
  templateUrl: './company-form.component.html',
  styleUrls: ['./company-form.component.css']
})
export class CompanyFormComponent implements OnInit {

  company = new CompanyItem(0, "", "", "", "");
  existed = false;
  companyslist: CompanyItem[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private companyService: CompanyService

  ) { }

  ngOnInit() {
    this.companyService.getCompanys().subscribe(c => this.companyslist = c);
    this.route.params.subscribe(p => {
      if (p['id'] === undefined) return;
      this.companyService.getCompany(p['id']).subscribe(h => this.company = h);
      this.existed = true;
    });
  }

  navigateToCompanys() {
    this.router.navigate(['/companys']);
  }

  onCancel() {
    this.navigateToCompanys();
  }
  
  onSubmit() {
    if (this.existed) {
      this.companyService.updateCompany(this.company).subscribe(c => this.navigateToCompanys());
    } else {
      this.companyService.addCompany(this.company).subscribe(c => this.navigateToCompanys());
    }
  }
}
