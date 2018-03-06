import { Component, OnInit } from '@angular/core';
import { ActivatedRoute} from '@angular/router'

@Component({
  selector: 'app-missing',
  templateUrl: './missing.component.html',
  styleUrls: ['./missing.component.scss']
})
export class MissingComponent implements OnInit {
	sessionExpired:boolean=false;
message:string="Not a valid page.";
  constructor(private route:ActivatedRoute) { }

  ngOnInit() {
  	let msg = this.route.snapshot.params['msg'];
  	if (msg!=undefined)
  	{
  		if (msg=="Session Expired")
  			this.sessionExpired = true;
  		  		this.message=msg;

  	}
  	}

  }

}
