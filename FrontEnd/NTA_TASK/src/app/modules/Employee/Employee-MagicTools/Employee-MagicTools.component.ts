import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BaseComponent } from '../../Shared/core/base.component';
import { ApiService } from '../../Shared/Shared-Services/http/Api.service';

@Component({
  selector: 'app-Employee-MagicTools',
  templateUrl: './Employee-MagicTools.component.html',
  styleUrls: ['./Employee-MagicTools.component.css'],
})
export class EmployeeMagicToolsComponent implements OnInit {
  ControllerRoute: string = 'Systems';
  row: Array<any> = [];
  public showSearch: boolean = false;
  public searchText!: string;

  constructor(
    private router: Router,
    private dialog: MatDialog,
    private api: ApiService,
    private spinner: NgxSpinnerService,
    private alert: ToastrService
  ) {}

  ngOnInit() {
    this.GetData();
  }

  Data: any;
  GetData() {
    this.api.get(`${this.ControllerRoute}/GetAllForEmp`).subscribe(
      (res: any) => {
        this.Data = res.data;

        this.spinner.hide();
      },
      (error) => {
        this.spinner.hide();
      }
    );
  }

  RedirectToSysten(Obj: any) {
    console.log(Obj);
  }
}
