import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { HttpClientService } from './http-client.service';
import { PagedData} from '../../models/common/pageddata';
import { PagedResponse} from '../../models/common/pagedresponse';

@Injectable()
export class RoleService {

  constructor(private httpClient:HttpClientService) { }

	getAll(criteria):Observable<any>{
		return this.httpClient.post('AllRole/', criteria)
		.map(t=>t);
	}
	getDetail(criteria):Observable<any>{
		return this.httpClient.post('Role/', criteria)
		.map(t=>t);
	}

	update(role):Observable<any>	{
		return this.httpClient.post('UpdateRole/', role)
		.map(t=>t);
	}


}
