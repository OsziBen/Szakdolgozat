import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }
  baseURL = 'http://localhost:5125/api';

  createUser(formData: any){
    formData.role = "Admin";  // TEMP!

    return this.http.post(this.baseURL + '/signup', formData)
  }

  signIn(formData: any){
    return this.http.post(this.baseURL + '/signin', formData)
  }  
}
