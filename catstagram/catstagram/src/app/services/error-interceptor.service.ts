import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptorService implements HttpInterceptor {

  constructor(private toastrService: ToastrService) { }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      retry(1),
      catchError((err) => {
        let message = ""
        if (err.status == 401){
          message = "Token has expired or you should be logged in"
        }
        else if (err.status == 404)
        {
          message = "404"
        }
        else if (err.status == 400){
          message = "400"
        }
        else
        {
          message = "Unexpected Error"
        }
        this.toastrService.error(message);
        return throwError(err)
      })
    );
  }
}
