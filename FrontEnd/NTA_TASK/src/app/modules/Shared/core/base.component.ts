
import { Component, DoCheck } from "@angular/core";
import { ThemePalette } from "@angular/material/core";
import { Page } from "src/app/ViewModel/Page";
@Component({
    template: ''
  })
export class BaseComponent implements DoCheck {
    public page = new Page();
    public paginatorEvent: any;
    public rows = [];

    public date!: moment.Moment;
  public disabled = false;
  public showSpinners = true;
  public showSeconds = true;
  public touchUi = false;
  public enableMeridian = true;
  public minDate!: moment.Moment;
  public maxDate!: moment.Moment;
  public stepHour = 1;
  public stepMinute = 1;
  public stepSecond = 1;
  public color: ThemePalette = 'primary';
  

    ngDoCheck() {

    }
    constructor() {
        this.page.filter = '';
        this.page.pageNumber = 0;
        this.page.size = 5;
        this.page.totalElements = 0;
    }
} 