import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { HttpClientService } from './http-client.service';
import { PagedData} from '../../models/common/pageddata';
import { PagedResponse} from '../../models/common/pagedresponse';

@Injectable()
export class GprsdataService {

  constructor(private httpClient:HttpClientService) {}

  	getGprsData(ondate):Observable<any>{
  		return this.httpClient.post('GprsData/', ondate)
  			.map(t=>t);
  	}

  	getGprsHistory(id):Observable<any>{
  		return this.httpClient.post('GprsHistory/', id)
  			.map(t=>t);
  	}

  	getGprsDetail(id):Observable<any>{
  		return this.httpClient.post('GprsDetail/', id)
  			.map(t=>t);
  	}


}
