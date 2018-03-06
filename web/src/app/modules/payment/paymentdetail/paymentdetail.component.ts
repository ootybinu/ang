import { Component, OnInit } from '@angular/core';
import { Input, Output, EventEmitter } from '@angular/core';
import { NgClass } from '@angular/common';
import { CommonService} from '../../shared/common.service';
import { PaymentService } from '../../shared/payment.service';
import { TitleComponent } from '../../common/tools/title/title.component';
import {KeyValue}  from '../../../models/common/common';
import { PagedData} from '../../../models/common/pageddata';
import { PagedResponse} from '../../../models/common/pagedresponse';
import { PaginationComponent } from '../../common/tools/pagination/pagination.component'; 
import { BilldetailComponent } from '../../common/tools/billdetail/billdetail.component'

@Component({
  selector: 'app-paymentdetail',
  templateUrl: './paymentdetail.component.html',
  styleUrls: ['./paymentdetail.component.scss']
})
export class PaymentdetailComponent implements OnInit {
	billNumber:number;
	selectedBill;
	modeOfPay:string;
	chequeNo:string;
	bankName :string;
	branchName:string
	bankAddress:string;
	amount :number;
	paymentvm;
	billStatus='';
	@Input() ShowCancel:boolean=false;
	@Output() BillNoChange:EventEmitter<number> = new EventEmitter<number>(); 
	@Output() Clear:EventEmitter<void> = new EventEmitter<void>();


  constructor(private commonService:CommonService, private dataService:PaymentService) { }

  ngOnInit() {
  }
	
	getBill()
	{
		this.dataService.getBill(this.billNumber).subscribe(res=> {
			this.selectedBill = res;
			if (this.selectedBill != undefined && this.selectedBill != null )
			{
				if (this.selectedBill.billGroupDetail != undefined && this.selectedBill.billGroupDetail)
				{
					let bgd = this.selectedBill.billGroupDetail;
					this.billStatus = bgd.status;
				}
				//event.preventDefault();
				if (this.billStatus!='Closed')
					this.BillNoChange.emit(this.billNumber);
			this.getPaymentDetails();
			}else 
			{
				this.commonService.showError("Not a valid Bill Number.");
			}
		}, 
		err=> {
			console.log('Error occured '+ err);
			this.commonService.showError(err);	
		}, 
		()=>{ });
	}  
	getPaymentDetails()
	{
		this.dataService.getPaymentDetails(this.billNumber).subscribe(res=> {
			this.paymentvm = res;


		}, 
		err=> {
			console.log('Error occured '+ err);
			this.commonService.showError(err);	
		}, 
		()=>{ });
	}

	cancelPayment (paymentid)
	{
		this.dataService.cancelPayment(paymentid).subscribe(res=> {
			//this.paymentvm = res;
			let  result = 	JSON.parse(res);
	 		 if (result.msg=="Success")
                this.commonService.showSuccess("Payment Cancelled")  ;
	          else
                this.commonService.showError(result.msg) ; 
		this.getBill();		

		}, 
		err=> {
			console.log('Error occured '+ err);
			this.commonService.showError(err);	
		}, 
		()=>{ });
	}
	clear()
	{
		this.billNumber=undefined;
		this.selectedBill=null;
		this.Clear.emit() ;
	}

}
