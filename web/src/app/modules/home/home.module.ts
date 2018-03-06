import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';

const routes:Routes=[{path:'', component:HomeComponent}]
@NgModule({
  imports: [
  	RouterModule.forChild(routes),
    CommonModule
  ],
  declarations: [HomeComponent]
})
export class HomeModule { }
