import { AfterViewChecked, Component, DoCheck, OnInit } from '@angular/core';
import {
  ChangeDetectionStrategy,
  ViewChild,
  TemplateRef,
} from '@angular/core';
import {
  startOfDay,
  endOfDay,
  subDays,
  addDays,
  endOfMonth,
  isSameDay,
  isSameMonth,
  addHours,
} from 'date-fns';
import { Subject } from 'rxjs';
import {
  CalendarEvent,
  CalendarEventAction,
  CalendarEventTimesChangedEvent,
  CalendarView,
} from 'angular-calendar';
import { EventColor } from 'calendar-utils';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { ConfirmDialogComponent } from '../../Shared/Shared-Components/confirm-dialog/confirm-dialog.component';
import { ApiService } from '../../Shared/Shared-Services/http/Api.service';
import { AddAdminStoryComponent } from '../Admin-story/Add-Admin-Story/Add-Admin-Story.component';
import { UpdateAdminStoryComponent } from '../Admin-story/Update-Admin-Story/Update-Admin-Story.component';
import { AddAdminCalenderComponent } from './Add-Admin-Calender/Add-Admin-Calender.component';
import { UpdateAdminCalenderComponent } from './Update-Admin-Calender/Update-Admin-Calender.component';



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
  selector: 'app-Admin-Calender',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './Admin-Calender.component.html',
  styleUrls: ['./Admin-Calender.component.css']
})


export class AdminCalenderComponent implements OnInit {
  ControllerRoute:string = "CalenderEvents";

  constructor(private router: Router,
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
      label: '<div class="btn btn-primary Edit">Edit</div>',
      a11yLabel: 'Edit',
      onClick: ({ event }: { event: CalendarEvent }): void => {
        this.handleEvent('Edited', event);
      },
    },
    {
      label: '<div class="btn btn-primary Delete">Delete</div>',
      a11yLabel: 'Delete',
      onClick: ({ event }: { event: CalendarEvent }): void => {
        this.handleEvent('Deleted', event);
      },
    },
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

  

  handleEvent(action: string, event: CalendarEvent): void {
    if(action == "Edited"){
      this.showEdit(event);
    }
    else if (action == "Deleted"){
      this.Delete(event);
    }
    this.refresh.next();
  }

  

 

  closeOpenMonthViewDay() {
    this.activeDayIsOpen = false;
  }




  
Data :Array<any> = [];
GetData() {
  this.events = [];
    this.api.get( `${this.ControllerRoute}/GetAll`).subscribe(
      (res: any) => {
        this.Data = res["data"];
        this.spinner.hide();
        this.Data?.forEach(element => {
          this.events.push( 
            {
              id: element,
              title: element["eventName"],
              start: startOfDay(new Date(element["eventDateTime"])),
              end: endOfDay(new Date(element["eventDateTime"])),
              color: colors['red'],
              actions: this.actions,
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
  let dialogRef = this.dialog.open(AddAdminCalenderComponent, {
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
  let dialogRef = this.dialog.open(UpdateAdminCalenderComponent, {
    width: '1000px',
    height: '60vh',
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
          console.log(error);
          this.alert.error(error);
        }
      );
    }
  });
}


}