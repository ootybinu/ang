import { Component, OnInit , Input, Output, EventEmitter} from '@angular/core';

@Component({
  selector: 'app-table-helper',
  templateUrl: './table-helper.component.html',
  styleUrls: ['./table-helper.component.scss']
})
export class TableHelperComponent implements OnInit {

	@Input() ShowChartIcon:boolean;
  @Input() ShowSearchIcon:boolean = true;
  @Input() ShowExportIcon:boolean = true;
  @Input() filterText:String; 
  @Output() ShowSearch:EventEmitter<void>  = new EventEmitter<void>();
	@Output() ShowExport:EventEmitter<string>  = new EventEmitter<string>();
	@Output() ShowGraph:EventEmitter<boolean>  = new EventEmitter<boolean>();
  private toggleChart:boolean=true;
  constructor() { }

  ngOnInit() {
  }

  showSearch(event)
  {
    event.preventDefault();
  	this.ShowSearch.emit();

  }
  showExport(event, exportTo:string)
  {
    event.preventDefault();
  	this.ShowExport.emit(exportTo);
  	
  }

  showGraph(event)
  {
    this.toggleChart = ! this.toggleChart;
    event.preventDefault();
  	this.ShowGraph.emit(this.toggleChart);
  	
  }

}
