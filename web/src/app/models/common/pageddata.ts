export class PagedData<t>
{
	PageNumber?:number;
	NumberOfRecords?:number;
	Data:t;
	SortBy:string;
	SortAsc:boolean;
}