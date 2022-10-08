import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { CalendarView, CalendarEventAction, CalendarEvent } from 'angular-calendar';
import { EventColor } from 'calendar-utils';
import { isSameMonth, isSameDay, startOfDay, endOfDay } from 'date-fns';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { ApiService } from '../../Shared/Shared-Services/http/Api.service';
import { ShowDataCalenderComponent } from './Show-Data-Calender/Show-Data-Calender.component';


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
  selector: 'app-Employee-Calender',
  templateUrl: './Employee-Calender.component.html',
  styleUrls: ['./Employee-Calender.component.css']
})
export class EmployeeCalenderComponent implements OnInit {
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
      label: '<div class="btn btn-primary Delete">Show</div>',
      a11yLabel: 'Delete',
      onClick: ({ event }: { event: CalendarEvent }): void => {
        this.handleEvent('ShowDataOnly', event);
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
     if (action == "ShowDataOnly"){
      this.ShowDataOnly(event);
    }
    this.refresh.next();
  }

  

 

  closeOpenMonthViewDay() {
    this.activeDayIsOpen = false;
  }




  
Data :Array<any> = [];
GetData() {
  this.events = [];
    this.api.get( `${this.ControllerRoute}/GetAllForEmp`).subscribe(
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

ShowDataOnly(item: any) {
  let dialogRef = this.dialog.open(ShowDataCalenderComponent, {
    width: '1000px',
    height: '40vh',
    data: item.id
  });
  dialogRef.afterClosed()
    .subscribe(data => {
      if (data) {
        this.GetData();
      }
    });
}


}