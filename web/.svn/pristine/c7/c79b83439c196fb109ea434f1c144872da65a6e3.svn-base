import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { HttpClientService } from './http-client.service';
import { PagedData} from '../../models/common/pageddata';
import { PagedResponse} from '../../models/common/pagedresponse';

@Injectable()
export class UnitSummaryService {

  constructor(private httpClient:HttpClientService) { }
	
	getInitialLists()
	{
		return this.httpClient.post('UnitSummary/GetInitialLists','')
		.map(t=>t);
	}

	getSubList(criteria) :Observable<any>{
  		return this.httpClient.post('UnitreportSearchSubItem/', criteria)
  		.map(t=>t);
  	}

  	getAll(criteria):Observable<any>{
		return this.httpClient.post('UnitSummary/GetAll/', criteria)
		.map(t=>t);
	}

	getDetail(id):Observable<any>{
		return this.httpClient.post('UnitSummary/GetDetail/', id)
		.map(t=>t);
	}

	update(updateunit):Observable<any>	{
		return this.httpClient.post('UnitSummary/UpdateUnit/', updateunit)
		.map(t=>t);
	}

}
