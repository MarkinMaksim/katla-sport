import { Component, OnInit } from '@angular/core';
import { ReportItem } from '../models/repors-item.component';
import { ReportService } from '../services/report.service';

@Component({
  selector: 'app-report-list',
  templateUrl: './report-list.component.html',
  styleUrls: ['./report-list.component.css']
})
export class ReportListComponent implements OnInit {

  reports: ReportItem[];

  constructor(private reportService: ReportService) { }

  ngOnInit() {
    this.getReports();
  }

  getReports() {
    this.reportService.getReports().subscribe(h => this.reports = h);
  }

  onDelete(reportId: number) {
    this.reportService.deleteReport(reportId).subscribe(p => this.getReports());   
  }
}
