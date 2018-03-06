import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { HttpClientService } from './http-client.service';
import { PagedData} from '../../models/common/pageddata';
import { PagedResponse} from '../../models/common/pagedresponse';

@Injectable()
export class TamperdetectionService {

  constructor(private httpClient:HttpClientService) { }

	getList(criteria):Observable<any>
	{
		return this.httpClient.post('TamperDetection/GetList/',criteria)
		.map(t=>t);
	}

	getUnitList(criteria):Observable<any>
	{
		return this.httpClient.post('TamperDetection/GetUnitList/',criteria)
		.map(t=>t);
	}
	getData(criteria):Observable<any>
	{
		return this.httpClient.post('TamperDetection/GetData/',criteria)
		.map(t=>t);
	}
}
