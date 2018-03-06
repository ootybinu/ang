import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { HttpClientService } from './http-client.service';

@Injectable()
export class TariffService {
	 constructor(private httpClient:HttpClientService) { }

	getPlaceList(obj){
      return this.httpClient.post('Common/GetPlaceList/',obj)
    .map(t=>t);
  	}

	generate(obj){
      return this.httpClient.post('Tariff/Generate/',obj)
    .map(t=>t);
  	}  	
  
  getData(obj){
      return this.httpClient.post('Tariff/GetTariffConfig/',obj)
    .map(t=>t);
  	}

  getMeterType(obj){
      return this.httpClient.post('Common/GetMasterValues/',obj)
    .map(t=>t);
    }

  update(obj){
      return this.httpClient.post('Tariff/Update/',obj)
    .map(t=>t);
    } 
    delete(obj){
      return this.httpClient.post('Tariff/Delete/',obj)
    .map(t=>t);
    } 
}
