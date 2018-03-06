import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './login.component';
 import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
const routes:Routes=[{path:'', component:LoginComponent}];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(routes),
    NgbModule.forRoot()
  ],
  declarations: [LoginComponent]
})
export class LoginModule { }
