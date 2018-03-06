export class userrow{
	employeeid:number;
	loginname:string;
	name:string;
	rrnumber:string;
	email:string;
	mobilenumber:string;

}
export class employee{
	employeeid :number ;
	firstname :string ;
	midname :string ;
	lastname :string ;
	logintype :number ;
	photograph :string ;
	dateofbirth? :Date ;
	maritalstatus?:number ;
	sex :number ;
	isapproved :number ;
	datecreated? :Date ;
	usercreated :number ;
	datelastmodified? :Date ;
	userlastmodified :number ;
	rrnumber :string ;
	address :string ;
	mobilenumber :string ;
	message :string ;
	email :string ;
	oem :string ;
	heads :string ;
	designation :string ;
	divisionid?:number;
	subdivisionid?:number;
}
export class empMeta{

	loginname :string ;
	password :string ;
	roles :number ;
	active :boolean ;
	loginfailedcount:number;
	firstlogininnew:boolean;
	defaultrole?:number;
}
export class userFull {
	emp:employee;
	emplog:empMeta;

}