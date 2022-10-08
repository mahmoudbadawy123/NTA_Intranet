import {CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';
import {A11yModule} from '@angular/cdk/a11y';
import {CdkAccordionModule} from '@angular/cdk/accordion';
import {ClipboardModule} from '@angular/cdk/clipboard';
import {DragDropModule} from '@angular/cdk/drag-drop';
import {PortalModule} from '@angular/cdk/portal';
import {ScrollingModule} from '@angular/cdk/scrolling';
import {CdkStepperModule} from '@angular/cdk/stepper';
import {CdkTableModule} from '@angular/cdk/table';
import {CdkTreeModule} from '@angular/cdk/tree';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatBadgeModule} from '@angular/material/badge';
import {MatBottomSheetModule} from '@angular/material/bottom-sheet';
import {MatButtonModule} from '@angular/material/button';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatCardModule} from '@angular/material/card';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatChipsModule} from '@angular/material/chips';
import {MatStepperModule} from '@angular/material/stepper';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatDialogModule} from '@angular/material/dialog';
import {MatDividerModule} from '@angular/material/divider';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import {MatListModule} from '@angular/material/list';
import {MatMenuModule} from '@angular/material/menu';
import { MatNativeDateModule, MatRippleModule} from '@angular/material/core';
import {MatPaginatorIntl, MatPaginatorModule} from '@angular/material/paginator';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatRadioModule} from '@angular/material/radio';
import {MatSelectModule} from '@angular/material/select';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatSliderModule} from '@angular/material/slider';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatSortModule} from '@angular/material/sort';
import {MatTableModule} from '@angular/material/table';
import {MatTabsModule} from '@angular/material/tabs';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatTreeModule} from '@angular/material/tree';
import {OverlayModule} from '@angular/cdk/overlay';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { ApiService } from './Shared-Services/http/Api.service';
import { NgxSpinnerModule } from "ngx-spinner";
import { PageNotFoundComponent } from './Shared-Components/PageNotFound/PageNotFound.component';
import { ContentHeaderComponent } from './Shared-Components/content-header/content-header.component';

import { NgxMatDatetimePickerModule, NgxMatTimepickerModule } from '@angular-material-components/datetime-picker';
import { NgxMatMomentModule } from '@angular-material-components/moment-adapter';
import { ConfirmDialogComponent } from './Shared-Components/confirm-dialog/confirm-dialog.component';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';



var Modules : any[] = [
  
     CommonModule,
     RouterModule,
     MatAutocompleteModule,
     MatButtonToggleModule,
     MatCardModule,
     MatCheckboxModule,
     MatChipsModule,
     MatDialogModule,
     MatExpansionModule,
     MatGridListModule,
     MatIconModule,
     MatListModule,
     MatMenuModule,
     MatPaginatorModule,
     MatProgressBarModule,
     MatProgressSpinnerModule,
     MatRadioModule,
     MatSelectModule,
     MatSidenavModule,
     MatSliderModule,
     MatSlideToggleModule,
     MatSnackBarModule,
     MatTableModule,
     MatTabsModule,
     MatToolbarModule,
     MatTooltipModule,
     MatRippleModule,
     MatDatepickerModule,
     MatNativeDateModule,
     MatFormFieldModule,
     MatSortModule,
     MatInputModule,
     MatButtonModule,
     ReactiveFormsModule,
     FormsModule,
     A11yModule,
     CdkAccordionModule,
     CdkTableModule,
     OverlayModule,
     PortalModule,
     ScrollingModule,
     MatDividerModule,
     ClipboardModule,
     CdkTreeModule,
     DragDropModule,
     MatBadgeModule,
     MatBottomSheetModule,
     MatTreeModule,
     CdkStepperModule,
     MatStepperModule,
     ToastrModule.forRoot() ,
     NgxSpinnerModule,

    //  https://www.npmjs.com/package/@angular-material-components/datetime-picker
    //  https://stackblitz.com/edit/demo-ngx-mat-datetime-picker?file=src%2Fapp%2Fapp.module.ts
     NgxMatDatetimePickerModule,
     NgxMatTimepickerModule,
     NgxMatMomentModule,
     CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory,
    }),

  
 ]
 let  providers: any[] = [
  ApiService,
  NgxMatMomentModule,
   
]
let entryComponents: any[]= [
  PageNotFoundComponent,
  ContentHeaderComponent,
  ConfirmDialogComponent,
]
 let Components : any[]= [
   ...entryComponents,

]




@NgModule({
  imports: [
    ...Modules,

  ],
  exports: [
   ...Modules,
   ...Components,
  ]
  ,
  providers: [
    ...providers
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  declarations: [	
    ...Components,
      // TruncatePipe
   ]
  ,
  entryComponents: [
    ...entryComponents 
  ],

})
export class SharedModule { }


