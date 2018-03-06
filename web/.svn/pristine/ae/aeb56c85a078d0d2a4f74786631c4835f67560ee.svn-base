import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { HttpClientService } from './http-client.service';
import { PagedData} from '../../models/common/pageddata';
import { PagedResponse} from '../../models/common/pagedresponse';
import { UserConsumption } from '../../models/realtime/user-consumption';
import { UserConsumptionInput } from '../../models/realtime/user-consumption-input';
import { UserConsumptionHistory , UserConsumptionHistoryInput } from '../../models/realtime/user-consumption-history';
@Injectable()
export class RealtimeService {
	realtimeData:UserConsumption[]=[];
  	queryinput:PagedData<UserConsumptionInput>;

  	constructor(private httpClient:HttpClientService) { }
	
	private frameInput(){

		let query = new PagedData<UserConsumptionInput>();
		query.PageNumber =1;
		query.NumberOfRecords=10;

		let crit=  new UserConsumptionInput();
		crit.UserId=2;
		crit.RoleId=4;
		crit.OEM='S';
		crit.Designation='EE(SW)'; 
		query.Data = crit;
		return query;
	}

//	getRealTimeData(criteria:PagedData<UserConsumptionInput>):Observable<PagedResponse<UserConsumption>>{
	getRealTimeData(criteria:PagedData<UserConsumptionInput>):Observable<any>{
		return this.httpClient.post('UnitConsumption/GetConsumptionData/', criteria)
		.map(t=>t);
	}

	getRealTimeSearchData(criteria:UserConsumptionInput):Observable<any>{
		return this.httpClient.post('UnitConsumptionSearch/', criteria)
			.map(t=>t);

	}

	getRealtimeChartData(request:UserConsumptionInput):Observable<any> {
		return this.httpClient.post('UnitConsumptionGraph',request)
		.map(t=>t);
	}

	getRealtimeHistory(request:PagedData<UserConsumptionHistoryInput>):Observable<any>{
		return this.httpClient.post('UnitConsumptionHistory',request)
			.map(t=>t);
	}
	getRealtimeHistoryChart(request:UserConsumptionHistoryInput):Observable<any> {
		return this.httpClient.post('UnitConsumptionHistoryGraph',request)
		.map(t=>t);
	}
	getRejectedMessages(criteria):Observable<any>{
		return this.httpClient.post('UnitConsumption/GetRejectedMessages/', criteria)
		.map(t=>t);
	}

}
