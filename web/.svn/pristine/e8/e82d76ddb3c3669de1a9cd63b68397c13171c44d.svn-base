import { Injectable } from '@angular/core';
import { URLSearchParams } from '@angular/http';
import { HttpClientService } from './http-client.service';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class PaymentService {

  constructor(private httpClient:HttpClientService) { }
  getBill(data){
	  	return this.httpClient.post('bill/GetBill/',data)
  	.map(t=>t);
  }
 	payment(data){
	  	return this.httpClient.post('payment/AddPayment/',data)
  	.map(t=>t);
  }
  getPaymentDetails (data){
	  	return this.httpClient.post('payment/GetPaymentDetails/',data)
  	.map(t=>t);
  }
  cancelPayment (data){
	  	return this.httpClient.post('payment/CancelPayment/',data)
  	.map(t=>t);
  }
  getBilledData (data){
	  	return this.httpClient.post('payment/GetAuthenticationData/',data)
  	.map(t=>t);
  }
  authenticate (data){
	  	return this.httpClient.post('payment/Authenticate/',data)
  	.map(t=>t);
  }
    getPlaceList(obj){
      return this.httpClient.post('Common/GetPlaceList/',obj)
    .map(t=>t);
  }
  getBGList(obj){
      return this.httpClient.post('Bill/GetBillGroupList/',obj)
    .map(t=>t);
  }
  processPayment(obj){
      return this.httpClient.post('payment/process/',obj)
    .map(t=>t);
  }

   
}
