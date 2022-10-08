import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Page } from 'src/app/ViewModel/Page';
import { BaseComponent } from '../../Shared/core/base.component';
import { ConfirmDialogComponent } from '../../Shared/Shared-Components/confirm-dialog/confirm-dialog.component';
import { ApiService } from '../../Shared/Shared-Services/http/Api.service';
import { AddAdminStoryComponent } from './Add-Admin-Story/Add-Admin-Story.component';
import { UpdateAdminStoryComponent } from './Update-Admin-Story/Update-Admin-Story.component';

@Component({
  selector: 'app-Admin-story',
  templateUrl: './Admin-story.component.html',
  styleUrls: ['./Admin-story.component.css']
})
export class AdminStoryComponent  extends BaseComponent
implements OnInit
{


ControllerRoute:string = "Storys";
row: Array<any> = [];

public displayedColumns = [
  'id',
  'header',
  'body',
  'publishDateTime',
  'insertUserName',
  'updateUserName',
  'updateUserDate',
  'Edit',
  'Delete',
];

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

getServerData(event: any) {
this.page.pageNumber = event.pageIndex;
this.page.size = event.pageSize;
this.GetData();

}
onSort(sortInfo: any) {
  this.page.pageNumber = 0;
  this.page.orderBy = sortInfo.active + sortInfo.direction;
  this.GetData();
}
applyFilter(filterValue: KeyboardEvent) {
  this.page = new Page(); 
  const target = filterValue.target as HTMLTextAreaElement;
  this.page.filter = target.value;
  this.GetData();
}
onSelect() {
  this.GetData();
}



Data :any;
GetData() {
    this.api.post( `${this.ControllerRoute}/GetAll`, this.page).subscribe(
      (res: any) => {
        this.Data = res;
        this.spinner.hide();
        console.log(this.Data);
        if (this.Data) {
          this.row = this.Data.data;
          if (this.row.length > 0) {
            this.page = this.Data.page;
          }
        }
      },
      (error) => {
        this.spinner.hide();
      }
    );
}


showAdd() {
  let dialogRef = this.dialog.open(AddAdminStoryComponent, {
    width: '1000px',
    height: '60vh'
  });
  dialogRef.afterClosed()
    .subscribe(data => {
      if (data) {
        this.GetData();
      }
    });
}

showEdit(item: any) {
  let dialogRef = this.dialog.open(UpdateAdminStoryComponent, {
    width: '1000px',
    height: '60vh',
    data: item
  });
  dialogRef.afterClosed()
    .subscribe(data => {
      if (data) {
        this.GetData();
      }
    });


}

 Form :any = {};
 Delete(item: any) {
  const confirmDialog = this.dialog.open(ConfirmDialogComponent, {
    data: {
      title: 'Confirm Remove Item',
      message: 'Are you sure, you want to remove  : ' + item.labelName
    }
  });
  confirmDialog.afterClosed().subscribe(result => {
    if (result === true) {
      this.Form["Id"] =item.id; 
      this.api.post(`${this.ControllerRoute}/Delete`, item).subscribe(
        (res: any) => {
  
          this.alert.success("Deleting Item Done Succesfully");
          this.GetData();
        },
        (error) => {
          this.alert.error(error);
        }
      );
    }
  });


  

}



}