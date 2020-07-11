import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WizardComponent } from './components/wizard/wizard.component';
import { CreateItemComponent } from './components/create-item/create-item.component';
import { FormsModule } from '@angular/forms';
import { CreateStepComponent } from './components/create-step/create-step.component';
import { UpdateItemComponent } from './components/update-item/update-item.component';
import { UpdateStepComponent } from './components/update-step/update-step.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [WizardComponent,WizardComponent, CreateItemComponent, CreateStepComponent, UpdateItemComponent, UpdateStepComponent],
  imports: [
    CommonModule,FormsModule,SharedModule
  ],exports:[WizardComponent]
})
export class WizardModule { }
