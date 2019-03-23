import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from "@angular/common/http";
import { Observable } from "rxjs";
import { TOKEN_KEY } from "./token.service";

@Injectable()
export class AppendAuthHeader implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const modified = req.clone({
            setHeaders: {
                'Authorization': `Bearer ${sessionStorage.getItem(TOKEN_KEY)}`
            }
        });
        return next.handle(modified);
    }
}
