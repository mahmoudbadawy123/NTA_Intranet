import { ErrorHandler, Inject, Injector, NgZone, Injectable } from "@angular/core";
import { ErrorBadInput, ErrorConflict, ErrorNoContent, ErrorAmbiguous, ErrorNotFound, ErrorUnauthorized, ErrorExpectationFailed } from "./errors-types";
import { AppError } from "./app-error";
import { ToastrService } from "ngx-toastr";
import { Router } from "@angular/router";

@Injectable()
export class AppErrorHandler implements ErrorHandler {
  router!: Router;

  constructor(@Inject(Injector) private injector: Injector, private zone: NgZone) {

  }
  private get alert(): ToastrService {
    return this.injector.get(ToastrService);
  }


  handleError(error: AppError) {

    if (error instanceof ErrorConflict)
      this.alert.error('خطأ العنصر متعارض مع عناصر اخري');
    else if (error instanceof ErrorBadInput)
      this.alert.error('خطأ فى المدخلات');
    else if (error instanceof ErrorNotFound)
      this.alert.error('خطأ العنصر غير موجود');
    else if (error instanceof ErrorAmbiguous)
      this.alert.error('خطأ العنصر موجود من قبل');
    else if (error instanceof ErrorNoContent)
      this.alert.error('خطأ العنصر فارغ');
    else if (error instanceof ErrorUnauthorized) {
      this.alert.error('خطأ ليس لديك صلاحية');
    }
    else if (error instanceof ErrorExpectationFailed) {
      this.router = this.injector.get(Router);
      this.zone.run(() => this.router.navigate(["/login"]))
    }
  }
}