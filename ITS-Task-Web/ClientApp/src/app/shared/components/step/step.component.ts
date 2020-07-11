import { Component, OnInit,Output, Input,EventEmitter } from '@angular/core';
import { StepService } from '../../services/step.service';
import { Step } from '../../models/Step';
import { Item } from '../../models/Item';
import { ItemService } from '../../services/item.service';

@Component({
  selector: 'app-step',
  templateUrl: './step.component.html',
  styleUrls: ['./step.component.css']
})
export class StepComponent implements OnInit {
@Input('step')step:Step;
@Output() delete: EventEmitter<Step> = new EventEmitter();

  constructor(private stepService:StepService,private itemService:ItemService) { }


  ngOnInit() {}

  deleteStep(){
    this.stepService.deleteStep(this.step.id).subscribe(res=>{
      this.delete.emit(this.step);
    },err=>{
      console.log(err.error);
    });
  }
}
