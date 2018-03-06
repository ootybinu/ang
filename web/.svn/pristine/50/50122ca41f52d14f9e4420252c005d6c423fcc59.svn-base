import { Injectable } from '@angular/core';
import { URLSearchParams } from '@angular/http';
import { HttpClientService } from './http-client.service';

@Injectable()
export class AuthenticateService {

  constructor(private httpClient:HttpClientService) {


   }
   authenticateUser(user:string, password:string)
   {
   		// let data = new URLSearchParams();
   		// data.append('username', user);
   		// data.append('password', password);
   		let data = {'username' : user, 'password' : password}
   		return this.httpClient.post('security/',data).map(t=>t);
   }

}
