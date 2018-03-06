import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Input, Output, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss']
})
export class PaginationComponent implements OnInit {
	 private _totalPages:number;
   private _currentPage:number =1;
//	@Input() currentPage:number=1;
	@Input() numberOfRecPerPage:number=20;
	@Output() pageChange:EventEmitter<number> = new EventEmitter<number>();
	private _pages:Observable<number[]>;

	get pages():Observable<number[]>
	{
		return this._pages;
	}

	get totalPages():number {
		return this._totalPages;
	}

	@Input('totalPages')
	set totalPages(value:number)
	{
		this._totalPages = value;
		this.getPageRange();
	}

  get currentPage():number {
    return this._currentPage;
  }

  @Input('currentPage')
  set currentPage(value:number)
  {
    this._currentPage = value;
    this.getPageRange();
  }

  constructor() {
	console.log("constructed and the value is " + this.totalPages);   
  }

  ngOnChanges(){
  	this.getPageRange();
  }
  getPageRange()
  {
/*  	let items =[];
  	for (var i = 0; i < this.totalPages; ++i) {
  		items.push(i);
  	}
  	return items;*/
  	this._pages = Observable.range(0,this.totalPages)
  	.map(t=>t)
  	.toArray();
  }
  ngOnInit() {
  	console.log("ngoninit " + this.totalPages);
  }

  selectPage(nextPage:number, event)
  {
  	console.log('clicked for ..' + nextPage);
  	event.preventDefault();
//  	if (this.pageChange != null || this.pageChange != undefined)
      this.currentPage = nextPage;
  		this.pageChange.emit(nextPage);
  		console.log('event propagated..');
  }
  first()
  {
    this.currentPage = 1; 
    this.pageChange.emit(this.currentPage);
  }
  last()
  {
    this.currentPage = this.totalPages; 
    this.pageChange.emit(this.currentPage);
  }
  next()
  {
    if (this.currentPage+1 <= this.totalPages)
    {
       this.currentPage++;
     this.pageChange.emit(this.currentPage); 
     }
  }
  previous()
  {
    if (this.currentPage -1 >=1 )
    {
      this.currentPage--;
      this.pageChange.emit(this.currentPage);
    }
  }
  go()
  {
    if (this.currentPage >=1 && this.currentPage <= this.totalPages)
    {
      this.pageChange.emit(this.currentPage);
    }
  }

}
