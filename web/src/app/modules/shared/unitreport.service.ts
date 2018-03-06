import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { HttpClientService } from './http-client.service';
import { PagedData} from '../../models/common/pageddata';
import { PagedResponse} from '../../models/common/pagedresponse';
import { GenericRequest } from '../../models/GenericRequest' ;

@Injectable()
export class UnitreportService {

  constructor(private httpClient:HttpClientService) { }

  getInitialSearchLists(criteria:GenericRequest) :Observable<any>{
  	return this.httpClient.post('UnitReportSearch/', criteria)
  	.map(t=>t);
  }

  getSubList(criteria) :Observable<any>{
  	return this.httpClient.post('UnitreportSearchSubItem/', criteria)
  	.map(t=>t);
  }
  getUnitReport(search):Observable<any>{
  	return this.httpClient.post('UnitReport/', search)
  	.map(t=>t);
  }

}
