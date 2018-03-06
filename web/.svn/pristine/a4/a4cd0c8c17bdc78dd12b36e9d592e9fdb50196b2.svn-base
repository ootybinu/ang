import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { HttpClientService } from './http-client.service';
import { PagedData} from '../../models/common/pageddata';
import { PagedResponse} from '../../models/common/pagedresponse';
import { revenueInput} from '../../models/revenue/revenue';


@Injectable()
export class RevenueService {

  constructor(private httpClient:HttpClientService) {  }

  getDivisions(divisionkey):Observable<any>
  {
  	return this.httpClient.post('Common/OrganizationList/',divisionkey)
  	.map(t=>t);
  } 

  getRevenueData(input:PagedData<revenueInput>):Observable<any>
  {
  	return this.httpClient.post('Revenue/',input)
  	.map(t=>t);
  }

}
