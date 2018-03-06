import { Component, OnInit , ViewChild} from '@angular/core';
import { CommonService} from '../../shared/common.service';
import { PaymentService } from '../../shared/payment.service';
import { TitleComponent } from '../../common/tools/title/title.component';
import {KeyValue}  from '../../../models/common/common';
import { PagedData} from '../../../models/common/pageddata';
import { PagedResponse} from '../../../models/common/pagedresponse';
import { PaginationComponent } from '../../common/tools/pagination/pagination.component'; 
import { BilldetailComponent } from './../../billing/viewbill/billdetail/billdetail.component'
import { PaymentdetailComponent } from './../paymentdetail/paymentdetail.component'
@Component({
  selector: 'app-paymententry',
  templateUrl: './paymententry.component.html',
  styleUrls: ['./paymententry.component.scss']
})
export class PaymententryComponent implements OnInit {
	billNumber:number;
	selectedBill;
	modeOfPay:string;
	chequeNo:string;
	bankName :string;
	branchName:string
	bankAddress:string;
	amount :number;
	paymentvm;
    showAdd=false; 
    @ViewChild(PaymentdetailComponent) child;	

  constructor(private commonService:CommonService, private dataService:PaymentService) { }

  ngOnInit() {
  }
	
	// getBill()
	// {
	// 	this.dataService.getBill(this.billNumber).subscribe(res=> {
	// 		this.selectedBill = res;
	// 		this.getPaymentDetails();
	// 	}, 
	// 	err=> {
	// 		console.log('Error occured '+ err);
	// 		this.commonService.showError(err);	
	// 	}, 
	// 	()=>{ });
	// }  
	// getPaymentDetails()
	// {
	// 	this.dataService.getPaymentDetails(this.billNumber).subscribe(res=> {
	// 		this.paymentvm = res;
	// 	}, 
	// 	err=> {
	// 		console.log('Error occured '+ err);
	// 		this.commonService.showError(err);	
	// 	}, 
	// 	()=>{ });
	// }
    save()
    {
    	let obj = {
    		billNo : this.billNumber, 
    		chequeNo : this.chequeNo, 
    		modeOfPay : this.modeOfPay,
    		bankName: this.bankName, 
    		branchName :this.branchName, 
    		bankAddress :this.bankAddress, 
    		amount : this.amount
    	};
    	this.dataService.payment(obj).subscribe(res=> {
    		let  result = 	JSON.parse(res);
			if (result.msg=="Success"){
                this.commonService.showSuccess("Payment Saved")  ;
	    		this.child.getBill();
				this.selectedBill = res;
	        }
	          else
                this.commonService.showError(result.msg) ; 

		}, 
		err=> {
			console.log('Error occured '+ err);
			this.commonService.showError(err);	
		}, 
		()=>{ });

    }
    billNoChanged(billno)
    {
    	this.billNumber = billno;
    	this.showAdd=true;

    	console.log('bill changed and the number is ' + billno);
    }
    clear()
    {
    	this.showAdd=false;
    }

}
