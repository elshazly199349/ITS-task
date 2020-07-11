import { Component, OnInit, Input } from '@angular/core';
import { Step } from 'src/app/shared/models/Step';
import { StepService } from 'src/app/shared/services/step.service';

@Component({
  selector: 'app-update-step',
  templateUrl: './update-step.component.html',
  styleUrls: ['./update-step.component.css']
})
export class UpdateStepComponent implements OnInit {
@Input('step')step:Step;
errorMessage:string;
  constructor(private stepService:StepService) { }

  ngOnInit() {
    this.step={
      id:1,
      name:"step 1"
    }
  }

  updateStep(step:Step){
    if(step && step.id!=0){
      this.stepService.updateStep(step).subscribe(res=>{},err=>{
        this.errorMessage=err.error;
      })
    }
  }

  closeErrorDiv(){
    this.errorMessage=undefined;
  }

}
