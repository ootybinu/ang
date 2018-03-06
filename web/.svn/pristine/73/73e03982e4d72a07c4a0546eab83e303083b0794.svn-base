import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { HttpClientService } from './http-client.service';

@Injectable()
export class BillingService {

  constructor(private httpClient:HttpClientService) { }
  generateBill(data){
	  	return this.httpClient.post('Bill/Generate/',data)
  	.map(t=>t);
  }
  generateBillBGwise(data){
      return this.httpClient.post('Bill/GenerateBillBGWise/',data)
    .map(t=>t);
  }

  getPlaceList(obj){
      return this.httpClient.post('Common/GetPlaceList/',obj)
    .map(t=>t);
  }

  getMasterValues(obj){
      return this.httpClient.post('Common/GetMasterValues/',obj)
    .map(t=>t);
  }
  getBills(criteria)
  {
  	return this.httpClient.post('bill/GetBills/', criteria)
  	.map(t=>t);
  }
  getBill(criteria)
  {
    return this.httpClient.post('bill/GetBill/', criteria)
    .map(t=>t);
  }
  getBillsforPrint(criteria)
  {
    return this.httpClient.post('bill/GetBillsForPrint/', criteria)
    .map(t=>t);
  }
  getBillingGroups(){
      return this.httpClient.post('Common/GetBillingGroups/')
    .map(t=>t);
  }
  getBGdetails(obj){
      return this.httpClient.post('Bill/GetBillGroupDetails/',obj)
    .map(t=>t);
  }
  addBG(obj){
      return this.httpClient.post('Bill/AddBillGroupDetail/',obj)
    .map(t=>t);
  }
  getBGMaster(obj){
      return this.httpClient.post('Bill/GetBillGroupMaster/',obj)
    .map(t=>t);
  }
  updateBGM(obj){
      return this.httpClient.post('Bill/UpdateBillGroupMaster/',obj)
    .map(t=>t);
  }
  deleteBGM(obj){
      return this.httpClient.post('Bill/DeleteBillGroupMaster/',obj)
    .map(t=>t);
  }
  getBGList(obj){
      return this.httpClient.post('Bill/GetBillGroupList/',obj)
    .map(t=>t);
  }
  getBillGroup(obj){
      return this.httpClient.post('Bill/GetBillGroup/',obj)
    .map(t=>t);
  }
  updateBGitem (obj){
      return this.httpClient.post('Bill/UpdateBillGroupItem/',obj)
    .map(t=>t);
  }
}
