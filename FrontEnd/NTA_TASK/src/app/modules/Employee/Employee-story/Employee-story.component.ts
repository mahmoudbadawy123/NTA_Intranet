import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BaseComponent } from '../../Shared/core/base.component';
import { ApiService } from '../../Shared/Shared-Services/http/Api.service';

@Component({
  selector: 'app-Employee-story',
  templateUrl: './Employee-story.component.html',
  styleUrls: ['./Employee-story.component.css']
})
export class EmployeeStoryComponent extends BaseComponent
implements OnInit {

  ControllerRoute:string = "Storys";
  row: Array<any> = [];
  public showSearch: boolean = false;
  public searchText!: string;

  constructor(private router: Router,
    private dialog: MatDialog,
    private api: ApiService,
    private spinner :NgxSpinnerService,
    private alert: ToastrService,) { super();
}


  ngOnInit() {
    this.GetData();
  }


 

 

Data :any;
GetData() {
      this.api.post(`${this.ControllerRoute}/GetAllForEmp`, this.page).subscribe(
        (res: any) => {
          this.Data = res.data;
          this.page = res.page;
          this.spinner.hide();
        },
        (error) => {
          this.spinner.hide();
        }
      );
  }

  getServerData(event: any) {
    //debugger
      this.page.pageNumber = event.pageIndex;
      this.page.size = event.pageSize;
      this.GetData();
    
    }

}
