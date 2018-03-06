import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { HttpClientService } from './http-client.service';

@Injectable()
export class DashboardService {

  constructor(private httpClient:HttpClientService) { }

  getConsumptionData(userid):Observable<any>
  {
  	return this.httpClient.post('Dashboard/GetConsumptionData/',userid)
  	.map(t=>t);
  } 

	getDivisionWise(criteria):Observable<any>
  {
  	return this.httpClient.post('Dashboard/GetDivisionWise/',criteria)
  	.map(t=>t);
  } 

	getOemWise(criteria):Observable<any>
  {
  	return this.httpClient.post('Dashboard/GetOemWise/',criteria)
  	.map(t=>t);
  }

  getMessageData(criteria):Observable<any>
  {
  	return this.httpClient.post('Dashboard/GetMessageData/',criteria)
  	.map(t=>t);
  }
}
