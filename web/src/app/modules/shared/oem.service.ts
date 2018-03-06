import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { HttpClientService } from './http-client.service';
import { PagedData} from '../../models/common/pageddata';
import { PagedResponse} from '../../models/common/pagedresponse';

@Injectable()
export class OemService {

  constructor(private httpClient:HttpClientService) { }

  	getAll(criteria):Observable<any>{
		return this.httpClient.post('Oem/GetAll/', criteria)
		.map(t=>t);
	}
	save(oem):Observable<any>	{
		return this.httpClient.post('Oem/Save/', oem)
		.map(t=>t);
	}
	getOemEffiency():Observable<any>{
		return this.httpClient.post('Oem/GetOemEffiency/')
		.map(t=>t);
	}
	getOemEfficiencyDetails(oem):Observable<any>{
		return this.httpClient.post('Oem/GetOemEfficiencyDetail/',oem)
		.map(t=>t);
	}
}
