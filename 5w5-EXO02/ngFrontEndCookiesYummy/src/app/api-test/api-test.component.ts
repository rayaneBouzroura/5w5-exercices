import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-api-test',
  template: `
    <button (click)="register()">Register</button>
    <button (click)="login()">Login</button>
    <button (click)="logout()">Logout</button>
    <button (click)="getPrivateData()">Get Private Data</button>
    <button (click)="getPublicData()">Get Public Data</button>

  `
})
export class ApiTestComponent {
  registerDto = {
    username: 'testeur',
    email: 'test@test',
    password: 'Passw0rd!',
    confirmPassword: 'Passw0rd!'
  }
  loginDto = {
    username : 'test',
    password : 'Passw0rd!'
  }
  Url = 'https://localhost:7170/api/User/';


  constructor (private http : HttpClient) {}

  async getPublicData(): Promise<String[]>{
    console.log("Debut appelle API pour getPublicData");
    try {
      const response = await lastValueFrom(this.http.get<String[]>('https://localhost:7170/api/User/PublicData'));
      console.log("Response:", response);
      return response ?? [];
    } catch (error) {
      console.error("Error:", error);
      return Promise.reject(error); // rethrow the error
    } finally {
      console.log("Fin appelle API pour public Data" );
    }
  }

  async register(){

    let options = { withCredentials: true };
    //console log the link
    console.log(this.Url + 'Register');
    let result = await lastValueFrom(this.http.post<any>(this.Url + 'Register', this.registerDto, options));
    console.log("Response:", result);

  }

  //private req
  async getPrivateData(): Promise<String[]>{

    let options = { withCredentials: true };
    let result = await lastValueFrom(this.http.get<String[]>('https://localhost:7170/api/User/PrivateData', options));
    console.log("Response:", result);
    return result ?? [];
  }

  //now we login
  async login(){
    let options = { withCredentials: true };
    let result = await lastValueFrom(this.http.post<any>(this.Url + 'Login', this.loginDto, options));
    console.log("Response:", result);
  }


  async logout(){
    let options = { withCredentials: true };
    let result = await lastValueFrom(this.http.post<any>(this.Url + 'Logout', null, options));
    console.log("Response:", result);
  }


}
