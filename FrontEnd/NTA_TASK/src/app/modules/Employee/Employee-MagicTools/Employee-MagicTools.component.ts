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
export class EmployeeMagicToolsComponent 
extends BaseComponent
implements OnInit {
  ControllerRoute: string = 'RelatedSystems';
  row:any;
  public showSearch: boolean = false;
  public searchText!: string;

  constructor(
    private router: Router,
    private dialog: MatDialog,
    private api: ApiService,
    private spinner: NgxSpinnerService,
    private alert: ToastrService
  ) {
    super();
  }

  ngOnInit() {
    this.GetData();
  }

  Data: any;
  GetData() {
    this.api.post(`${this.ControllerRoute}/GetAllForEmp` , this.page).subscribe(
      (res: any) => {
        this.Data = res?.data;
        console.log(this.Data);
        this.row = res?.page;
        console.log(this.row);
        this.spinner.hide();
        if (this.row) {
  
            this.page = this.row;
        }
      },
      (error) => {
        this.spinner.hide();
      }
    );
  }

  RedirectToSysten(Obj: any) {
    console.log(Obj);
  }


  getServerData(event: any) {
    //debugger
      this.page.pageNumber = event.pageIndex;
      this.page.size = event.pageSize;
      this.GetData();
    
    }

}
