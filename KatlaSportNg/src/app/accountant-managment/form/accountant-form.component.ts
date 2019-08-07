import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountantService } from '../services/accountant.service';
import { AccountantFormItem } from '../models/accountant-form-item';
import { AccountantItem } from '../models/accountant-item'

@Component({
  selector: 'app-accountant-form',
  templateUrl: './accountant-form.component.html',
  styleUrls: ['./accountant-form.component.css']
})
export class AccountantFormComponent implements OnInit {

  file: File = null;
  accountant = new AccountantItem(0, "", "", 0, null, "");
  existed = false;
  accountanslist: AccountantItem[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private accountantService: AccountantService

  ) { }

  ngOnInit() {
    this.accountantService.getAccountants().subscribe(c => this.accountanslist = c);
    this.route.params.subscribe(p => {
      if (p['id'] === undefined) return;
      this.accountantService.getAccountant(p['id']).subscribe(h => this.accountant = h);
      this.existed = true;
    });
  }

  onFileChange(event) {
      this.file = event.target.files[0];
      console.log(this.file);
  }

  navigateToAccountants() {
    this.router.navigate(['/accountants']);
  }

  onCancel() {
    this.navigateToAccountants();
  }
  
  onSubmit() {
    if (this.existed) {
      this.accountantService.updateAccountant(this.accountant, this.file).subscribe(c => this.navigateToAccountants());
    } else {
      this.accountantService.addAccountant(this.accountant, this.file).subscribe(c => this.navigateToAccountants());
    }
  }
}
