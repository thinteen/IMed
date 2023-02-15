import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of, throwError } from 'rxjs';
import { IAdminAccount } from '../interface/adminAccount.interface';
import { SharedService } from './shared.service';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationService {

  constructor(private router: Router, private service: SharedService) { }

  adminAccount!: IAdminAccount;

  setToken(token: string) {
    localStorage.setItem('token', token);
  }

  getToken() {
    return localStorage.getItem('token');
  }

  isLogged() {
    return this.getToken() !== null;
  }

  login(adminData: {login: string, password: string}): Observable<string | boolean>{
    if (adminData.login !== "") 
    {
      this.service.getAdminAccountPasswordByLogin(adminData.login).subscribe((data: IAdminAccount) => {
        this.adminAccount = data;
      });
    }

    if (this.adminAccount.password == adminData.password)
    {
      this.setToken('token');
      return of(true);
    }

    return throwError(() => new Error('Неверный пароль'));
  }

  logOut() {
    this.router.navigate(['login']);
  }
}