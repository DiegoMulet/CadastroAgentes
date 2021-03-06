import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

baseURL = 'http://localhost:63761/api/auth/';
jwtHelper = new JwtHelperService();
decodedToken: any;

constructor(private http: HttpClient) { }

login(model: any) {
  return this.http
    .post(`${this.baseURL}entrar`, model).pipe(
      map((Response: any) => {
        const user = Response;

        if (user) {
          localStorage.setItem('token', user.accessToken);
          this.decodedToken = this.jwtHelper.decodeToken(user.accessToken);
          sessionStorage.setItem('username', this.decodedToken.unique_name);
        }
      })
    );

}

register(model: any) {
  return this.http.post(`${this.baseURL}nova-conta`, model);
}

loggedIn() {
  const token = localStorage.getItem('token');
  return !this.jwtHelper.isTokenExpired(token);
}

}
