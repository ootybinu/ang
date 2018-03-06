import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { HttpClientService } from './http-client.service';
import { PagedData} from '../../models/common/pageddata';
import { PagedResponse} from '../../models/common/pagedresponse';
@Injectable()
export class UserService {
  constructor(private httpClient:HttpClientService) { }

    getAllUsers(criteria):Observable<any>{
		return this.httpClient.post('AllUser/', criteria)
		.map(t=>t);
		}

    getDetail(criteria):Observable<any>{
		return this.httpClient.post('User/GetUser/', criteria)
		.map(t=>t);
		}
	update(updateuser):Observable<any>	{
		return this.httpClient.post('UpdateUser/', updateuser)
		.map(t=>t);
	}
	getRoles():Observable<any>	{
		return this.httpClient.post('UserRoles/')
		.map(t=>t);	
	}
	updatePassword(user):Observable<any>	{
		return this.httpClient.post('UpdateUserPassword/',user)
		.map(t=>t);	
	}	
	getPlaceList(obj){
      return this.httpClient.post('Common/GetPlaceList/',obj)
    .map(t=>t);
  	}
  	getOrganization():Observable<any>{
		return this.httpClient.post('User/GetOrganization/' )
		.map(t=>t);
		}
		
}
