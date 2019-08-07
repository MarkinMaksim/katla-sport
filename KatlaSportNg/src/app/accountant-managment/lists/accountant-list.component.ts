import { Component, OnInit } from '@angular/core';
import { AccountantItem } from '../models/accountant-item';
import { AccountantService } from '../services/accountant.service';

@Component({
  selector: 'app-accountant-list',
  templateUrl: './accountant-list.component.html',
  styleUrls: ['./accountant-list.component.css']
})
export class AccountantListComponent implements OnInit {

  accountants: AccountantItem[];

  constructor(private accountantService: AccountantService) { }

  ngOnInit() {
    this.getAccountants();
  }

  getAccountants() {
    this.accountantService.getAccountants().subscribe(h => this.accountants = h);
  }

  onDelete(accountantId: number) {
    this.accountantService.deleteAccountant(accountantId).subscribe(p => this.getAccountants());   
  }
}
