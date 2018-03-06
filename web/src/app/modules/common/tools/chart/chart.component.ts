import { Component,Input, OnInit } from '@angular/core';
import { NgxChartsModule } from '@swimlane/ngx-charts';
//import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonService } from '../../../shared/common.service';
@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss']
})
export class ChartComponent implements OnInit {
	_data:any;
	_data2:any=[]; 
	_alternateData;
	@Input('data') 
	set data (value){
		this._data=value;
		this._data2.length=0;
		this._data2.push({"name":"Data", "series":value});
	}
	get data() {return this._data;};

	@Input ('seriesData')
	set seriesData (value) {
		this._data = value;
		this._data2 = value;
	};

	@Input ('alternateData')
	set alternateData (value) {
		this._alternateData = value;
	};
	@Input() chartType:String;
	@Input() chart_options:{};
	@Input() xAxisLabel:string;
	@Input() yAxisLabel:string;

	showXAxis = true;
	showYAxis = true;
	gradient = false;
	showLegend = true;
	showXAxisLabel = true;
	showYAxisLabel = true;

	colorScheme = {  };
constructor(private commonService:CommonService){
	this.colorScheme = commonService.getColors();
}

  ngOnInit() {
  	
  }

}
