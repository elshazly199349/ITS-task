import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { StepService } from 'src/app/shared/services/step.service';
import { Step } from 'src/app/shared/models/Step';

@Component({
  selector: 'app-create-step',
  templateUrl: './create-step.component.html',
  styleUrls: ['./create-step.component.css']
})
export class CreateStepComponent implements OnInit {
step={} as Step;
errorMessage:string;
@Output() manipulateStepComp: EventEmitter<boolean> = new EventEmitter();

  constructor(private stepService:StepService) { }

  ngOnInit() {
  }

  saveStep(step:Step){
    this.stepService.createStep(step).subscribe(res=>{
      this.manipulateStepComp.emit(false);
    },error=>{
      this.errorMessage=error.error;
    });    
  }

  closeErrorDiv(){
    this.errorMessage=undefined;
    this.step.name="";
  }
}
