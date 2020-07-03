import { Injectable } from "@angular/core";
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from "@angular/common/http";
import { Observable } from "rxjs";
import { StorageService } from "../services/storage/storage.service";
import { AuthService } from "src/app/modules/auth/services/auth/auth.service";

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor(public storage: StorageService, private auth: AuthService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    const currentUser = this.auth.currentUserValue;

    if (currentUser) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer: ${currentUser.token}`,
        },
      });
    }

    return next.handle(request);
  }
}
