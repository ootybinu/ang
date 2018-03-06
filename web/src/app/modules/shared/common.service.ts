import { Injectable } from '@angular/core';
//let jsPDF = require('jspdf');
//require('jspdf-autotable');
//import * as jsPDF from 'jspdf''jspdf-autotable';
//import * from 'jspdf-autotable';
import { GenericRequest } from '../../models/GenericRequest';
import { User } from '../../models/common/user';
import { MessengerService } from '../shared/messenger.service';
import { KeyValuePair } from '../../models/common/common';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
declare let jsPDF;
@Injectable()
export class CommonService {
  LocalStore;
  constructor(private messenger:MessengerService, private toastr:ToastsManager ) { 
    this.PDFFontSize=10;
  }


  PDFFontSize:number;
  ExportOld(exportTo:string, fileName:string, content:string)
  {
  	if (exportTo=='excel')
  		this.exportExcelold(fileName, content);
  	if (exportTo=='pdf')
  		this.exportPdfold(fileName, content);

  }

  Export(exportTo:string, fileName:string, cols:string[], rows:any[] , header:string='', filter:string='' )
  {
    if (exportTo=='excel')
      this.exportExcel(fileName, cols,rows, header, filter);
    if (exportTo=='pdf')
      this.exportPdf(fileName, cols, rows, header, filter);

  }
  getColors(){
    return   {
     // domain: ['#5AA454', '#A10A28', '#C7B42C', '#AAAAAA']
     domain:['#1569C7', '#151B54', '#2B65EC', '#38ACEC', '#617C58', '#FFFF00','#565051', '#737CA1', '#6960EC', '#38ACEC', '#617C58', '#2B1B17','#8BB381', '#FFF380']
    };
  }

  getWeekNames(){
    return ["Sunday", "Monday","Tuesday","Wednesday", "Thursday","Friday","Saturday"];
  }
  getMonthNames()
  {
    return ["January","February","March","April","May","June","July","August","September", "October","November","December"];
  }
  getCurrentUser():User{
 //     let user =  new GenericRequest();
      let user = this.getObjectFromStore<User>("user");
      return user;
      // user.UserId = 2; 
      // user.RoleId=4;
      // user.OEM='S';
      // user.Designation='EE(SW)'; 
      // return user;
  }

  getTotalPages(records:number, recPerpage:number)
  {
    let r = records % recPerpage;
    let total = parseInt( (records/recPerpage).toFixed(0));
    if (r>0 && r<=4)
      total++;
    return total;
  }
  getObjectFromStore<t>(key:string):t
  {
    let res:t;
    let str =  sessionStorage.getItem(key);
    res = JSON.parse(str);
    return res;
  }
  getValueFromStore(key:string):string{
    return sessionStorage.getItem(key);
  }
  putObjectIntoStore<t>(key:string, value:any)
  {
    sessionStorage.setItem(key,JSON.stringify(value));
  }
  putValueIntoStore (key:string, value:any)
  {
    sessionStorage.setItem(key,value);
  }
  removeValueFromStore(key:string)
  {
    sessionStorage.removeItem(key);
  }

  showError(message:string)
  {
    this.toastr.error(message,"Exception");
    // let kv:KeyValuePair<string> = new KeyValuePair<string>();
    // kv.key="Exception";
    // kv.value = message;
    // this.messenger.publish(kv);
  }
  showSuccess(message:string, title:string="Success"){
    this.toastr.success(message,title) ;
  }
  publish(message:string)
  {
    let kv:KeyValuePair<string> = new KeyValuePair<string>();
    kv.key=message;
    kv.value = message;
    this.messenger.publish(kv);
  }

  private exportExcel(fileName:string, cols:string[], rows:any[], head:string='', filter:string="")
  {
    let content:string="";
    if (head != '')
      content ="<table><tr><td>" + head + "</td></tr></table>";
    if (filter != '')
      content+= "<table><tr><td> Filter:" + filter + "</td></tr></table>";
    content+="<table> <tr> ";
    let header="";
    let body ="";
    for (var i = 0; i < cols.length; ++i) {
        header+="<td> " + cols[i] + "</td>";
    }
    header+="</tr>";
    for (var j = 0; j < rows.length; ++j) {
      body+="<tr> ";
      for (var i = 0; i < rows[j].length; ++i) {
        body += "<td> " + rows[j][i] + "</td>";
      }
      body+="</tr>";
    }
    content+= header + body + "</table>";

  	let a = document.createElement('a')	;
  	a.href='data:application/vd.ms-excel' + ',' + content;
  	a.download =fileName+'.xls';
  	a.click(); 
  }
  private exportExcelold(fileName:string, content:string)
  {
    let a = document.createElement('a')  ;
    a.href='data:application/vd.ms-excel' + ',' + content;
    a.download =fileName+'.xls';
    a.click(); 
  }
  private exportPdf(fileName:string, cols:string[], rows:any[], header:string='', filter:string='')
  {
    let doc = new jsPDF('l','pt');
    let head = function(data){
        doc.setFontSize(16);
        doc.setTextColor(40);
        doc.setFontStyle('normal');
        let headtext='';
        if (header != '')
          headtext=header;
        if (filter != '')
          headtext+= '  filter:' + filter;
        if (headtext!='')  
        doc.text(headtext, data.settings.margin.left, 50 );
     } ;
    doc.autoTable(cols, rows,{
        startY: 80,//doc.autoTableEndPosY()+20,
        styles: {
          overflow: 'linebreak',
          fontSize: this.PDFFontSize,
          rowHeight:1,
          columnWidth: 'wrap',
          cellPadding: 3,
          valign: 'middle',
          tableWidth: 'auto',
          lineWidth: 0,
         
        }, beforePageContent: head,
        columnStyles: {
          1: {columnWidth: 'auto'}
        }
    }
    );

    doc.save(fileName+'.pdf');
  }

  private exportPdfold(fileName:string, content:string)
  {
  	// let doc = new this.jsPDF('l','pt');
  	// doc.setFontSize(8);
  	// doc.fromHTML(content);
  	// doc.save(fileName+'.pdf');

  }
}

