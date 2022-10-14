import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CalendarView, CalendarEventAction, CalendarEvent } from 'angular-calendar';
import { isSameMonth, isSameDay, startOfDay, endOfDay } from 'date-fns';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { AddAdminMeetingsComponent } from '../../admin/Admin-Meetings/Add-Admin-Meetings/Add-Admin-Meetings.component';
import { UpdateAdminMeetingsComponent } from '../../admin/Admin-Meetings/Update-Admin-Meetings/Update-Admin-Meetings.component';
import { ConfirmDialogComponent } from '../../Shared/Shared-Components/confirm-dialog/confirm-dialog.component';
import { ApiService } from '../../Shared/Shared-Services/http/Api.service';
import { EventColor } from 'calendar-utils';
import { ShowMeetingsInfoComponent } from './Show-Meetings-info/Show-Meetings-info.component';

const colors: Record<string, EventColor> = {
  red: {
    primary: '#ad2121',
    secondary: '#FAE3E3',
  },
  blue: {
    primary: '#1e90ff',
    secondary: '#D1E8FF',
  },
  yellow: {
    primary: '#e3bc08',
    secondary: '#FDF1BA',
  },
};
@Component({
  selector: 'app-Employee-Meetings',
  templateUrl: './Employee-Meetings.component.html',
  styleUrls: ['./Employee-Meetings.component.css']
})
export class EmployeeMeetingsComponent implements OnInit {

  ControllerRoute:string = "Meetings";

  constructor(
    private dialog: MatDialog,
    private api: ApiService,
    private spinner :NgxSpinnerService,
    private alert: ToastrService,) { 
      
    }

  ngOnInit() {
    this.GetData();
  }

  @ViewChild('modalContent', { static: true })
  modalContent!: TemplateRef<any>;
  view: CalendarView = CalendarView.Month;
  CalendarView = CalendarView;
  viewDate: Date = new Date();
  actions: CalendarEventAction[] = [
    {
      label: '<div class="btn btn-primary Edit" >Edit</div>',
      a11yLabel: 'Edit',
      onClick: ({ event }: { event: CalendarEvent }): void => {
        this.handleEvent('Edit', event);
      },
    },
    {
      label: '<div class="btn btn-primary Delete">Delete</div>',
      a11yLabel: 'Delete',
      onClick: ({ event }: { event: CalendarEvent }): void => {
        this.handleEvent('Delete', event);
      },
    },
  ];


  ShowOnlyactions: CalendarEventAction[] = [
    {
      label: '<div class="btn btn-primary Show" >Show</div>',
      a11yLabel: 'Show',
      onClick: ({ event }: { event: CalendarEvent }): void => {
        this.handleEvent('Show', event);
      },
    }
  ];




  refresh = new Subject<void>();
  events: CalendarEvent[] = [];
  activeDayIsOpen: boolean = false;
  dayClicked({ date, events }: { date: Date; events: CalendarEvent[] }): void {
    if (isSameMonth(date, this.viewDate)) {
      if (
        (isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) ||
        events.length === 0
      ) {
        this.activeDayIsOpen = false;
      } else {
        this.activeDayIsOpen = true;
      }
      this.viewDate = date;
    }
  }

  
  // showeditDelete = true;
  eventData:any = {};
  InsertUser:any;
  InsertUserHere:any;
  handleEvent(action: string, event: CalendarEvent): void {
   debugger;
//     console.log(event.id);
     this.eventData = event.id;
  this.InsertUserHere = this.eventData?.["insertUserId"];
//  console.log(this.InsertUser);
    // if()
    
    if(this.CurrentUser == this.InsertUserHere) {
      if(action == "Edit"){
        this.showEdit(event);
      }
      else if (action == "Delete"){
        this.Delete(event);
      }
    
    }else {
      if(action == "Show"){
        this.ShowData(event);
      }
      else {
        this.alert.warning("Can not Do any Operations in this Event as it is Owner For another User");
      }
    }
    this.refresh.next();
  }

  

 

  closeOpenMonthViewDay() {
    this.activeDayIsOpen = false;
  }




  
Data :Array<any> = [];
CurrentUser :any ;
GetData() {
  this.events = [];
    this.api.get( `${this.ControllerRoute}/GetAllForEmp`).subscribe(
      (res: any) => {
        debugger;
        console.log(res);
        this.Data = res["data"];
        this.CurrentUser = res["currentUser"];
        this.spinner.hide();
        this.Data?.forEach(element => {
          debugger;
          var Action = null;
          this.InsertUser = element.insertUserId;
          if(this.CurrentUser == this.InsertUser) {

            Action = this.actions;
          }
          else {
            Action = this.ShowOnlyactions;
          }


          this.events.push( 
            {
              id: element,
              title: element["meatingName"],
              start: startOfDay(new Date(element["meatingDateTime"])),
              end: endOfDay(new Date(element["meatingDateTime"])),
              color: colors['red'],
              actions: Action,
              allDay: true,
              draggable: false,
              resizable: {
                beforeStart: true,
                afterEnd: true,
              },
            },
          );
       
        });

        // https://github.com/mattlewis92/angular-calendar/issues/204
        // that solve the Events Not Displaying Unless I Click on Calendar 
        this.refresh.next();

      },
      (error) => {
        this.spinner.hide();
      }
    );
}


showAdd() {
  let dialogRef = this.dialog.open(AddAdminMeetingsComponent, {
    width: '1000px',
    height: '70vh'
  });
  dialogRef.afterClosed()
    .subscribe(data => {
      if (data) {
        this.GetData();
      }
    });
}

showEdit(item: any) {
  let dialogRef = this.dialog.open(UpdateAdminMeetingsComponent, {
    width: '1000px',
    height: '70vh',
    data: item.id
  });
  dialogRef.afterClosed()
    .subscribe(data => {
      if (data) {
        this.GetData();
      }
    });
}

ShowData(item: any){
  let dialogRef = this.dialog.open(ShowMeetingsInfoComponent, {
    width: '1000px',
    height: '70vh',
    data: item.id
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
      message: 'Are you sure, you want to remove  : ' + item.id.eventName
    }
  });
  confirmDialog.afterClosed().subscribe(result => {
    if (result === true) {
      this.api.post(`${this.ControllerRoute}/Delete`,item.id).subscribe(
        (res: any) => {
          this.alert.success("Deleting Item Done Succesfully");
          this.GetData();
          this.closeOpenMonthViewDay();
        },
        (error) => {
          this.alert.error(error);
        }
      );
    }
  });
}


}