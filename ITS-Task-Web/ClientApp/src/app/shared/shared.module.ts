import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemComponent } from './components/item/item.component';
import { RouterModule } from '@angular/router';
import { ItemService } from './services/item.service';
import { StepService } from './services/step.service';
import { StepComponent } from './components/step/step.component';

@NgModule({
  declarations: [ItemComponent, StepComponent],
  providers:[StepService,ItemService],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:'app-item',component:ItemComponent},
      {path:'app-step',component:StepComponent},

  ])
  ],exports:[
    CommonModule,
    ItemComponent,
    StepComponent
  ]
})
export class SharedModule { }
