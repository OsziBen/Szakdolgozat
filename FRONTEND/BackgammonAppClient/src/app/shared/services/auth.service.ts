import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TOKEN_KEY } from '../constants';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  createUser(formData: any){
    formData.role = "Admin";  // TEMP!

    return this.http.post(environment.apiBaseURL + '/Account/signup', formData)
  }

  signIn(formData: any){
    return this.http.post(environment.apiBaseURL + '/Auth/signin', formData)
  }

  isLoggedIn(){
    return this.getToken() != null ? true : false;
  }

  saveToken(token: string){
    localStorage.setItem(TOKEN_KEY, token);
  }

  getToken(){
    return localStorage.getItem(TOKEN_KEY);
  }

  deleteToken(){
    localStorage.removeItem(TOKEN_KEY);
  }

  getClaims(){
    return JSON.parse(window.atob(this.getToken()!.split('.')[1]));
  }
}
