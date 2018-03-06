import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { HttpClientService } from './http-client.service';

@Injectable()
export class OrganizationService {

  constructor(private httpClient:HttpClientService) { }
    
	getOrgMembers(criteria):Observable<any>{
		return this.httpClient.post('Organization/GetOrgMembers/', criteria)
		.map(t=>t);
		}

	update(org):Observable<any>	{
		return this.httpClient.post('Organization/Update/', org)
		.map(t=>t);
	}
	add(org):Observable<any>	{
		return this.httpClient.post('Organization/Add/', org)
		.map(t=>t);
	}
		delete(org):Observable<any>	{
		return this.httpClient.post('Organization/DeleteOrg/', org)
		.map(t=>t);
	}
}
