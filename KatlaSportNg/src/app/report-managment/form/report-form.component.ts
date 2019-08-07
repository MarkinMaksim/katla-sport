import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ReportService } from '../services/report.service';
import { ReportItem } from '../models/repors-item.component';
import { AccountantItem } from '../models/accountant-item';
import { CompanyItem } from '../models/company-item';


@Component({
  selector: 'app-report-form',
  templateUrl: './report-form.component.html',
  styleUrls: ['./report-form.component.css']
})
export class ReportFormComponent implements OnInit {

  report = new ReportItem(0, 0, 0);
  existed = false;
  accountantsList: AccountantItem[];
  companyslist: CompanyItem[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private reportService: ReportService

  ) { }

  ngOnInit() {
    this.reportService.getAccountants().subscribe(c => this.accountantsList = c);
    this.route.params.subscribe(p => {
      if (p['id'] === undefined) return;
      this.reportService.getReport(p['id']).subscribe(h => this.report = h);
      this.existed = true;
    });
    this.reportService.getComapnys().subscribe(c => this.companyslist = c);
    console.log(this.companyslist);
  }

  navigateToAccountants() {
    this.router.navigate(['/reports']);
  }

  onCancel() {
    this.navigateToAccountants();
  }
  
  onSubmit() {
    if (this.existed) {
      this.reportService.updateReport(this.report).subscribe(c => this.navigateToAccountants());
    } else {
      this.reportService.addReport(this.report).subscribe(c => this.navigateToAccountants());
    }
  }
}
