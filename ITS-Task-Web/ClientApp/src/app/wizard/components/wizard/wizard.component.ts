import { Component, OnInit } from '@angular/core';
import { Step } from 'src/app/shared/models/Step';
import { StepService } from 'src/app/shared/services/step.service';
import { Item } from 'src/app/shared/models/Item';
import { ItemService } from 'src/app/shared/services/item.service';

@Component({
  selector: 'app-wizard',
  templateUrl: './wizard.component.html',
  styleUrls: ['./wizard.component.css']
})
export class WizardComponent implements OnInit {
steps:Step[];
items:Item[];
selectedItems:Item[];
selectedStepId:number;
selectedItemId:number;
curser:number;
createStepDisplayed:boolean=false;
createItemDisplayed:boolean=false;

  constructor(private stepService:StepService,private itemService:ItemService) { }

  ngOnInit() {
    this.stepService.getAll().subscribe(res=>{
      this.steps=res;
      this.itemService.getAll().subscribe(itemres=>{
        this.items=itemres;

        if(this.steps && this.steps.length!=0){
          this.selectedItems=this.items.filter(e=>e.stepId==this.steps[0].id);
          this.selectedStepId=this.steps[0].id;
          this.curser=0;
        }
      },err=>{
        console.log(err.error);
      });
    },
    err=>{console.log(err.error)}
      );
  }

  deleteItem(item:Item){
    this.items=this.items.filter(e=>e!==item);
    this.selectedItems=this.selectedItems.filter(e=>e!==item);
}

deleteStep(step:Step){

  this.items=this.items.filter(e=>e.stepId!=step.id);
  this.selectedItems=this.selectedItems.filter(e=>e.stepId!=step.id);
  this.steps=this.steps.filter(e=>e!==step);
}

manipulateStepComp(value:boolean){
  this.createStepDisplayed=false;
  this.stepService.getAll().subscribe(res=>{this.steps=res;})
}

manipulateitemComp(value:boolean){
  this.createItemDisplayed=false;
  this.selectedItemId=undefined;
  this.itemService.getAll().subscribe(res=>{
    this.items=res;
    this.selectedItems=this.items.filter(e=>e.stepId==this.selectedStepId);
  },
  err=>{console.log(err.error)}
  );
}

selectItemtoUpdate(itemId:number){
  this.selectedItemId=itemId;
  this.createItemDisplayed=true;
}

moveStep(count:number){
    if((this.curser==this.steps.length-1 && count==1) || (this.curser==0 && count==-1)){
      this.curser=0;
    }else{
      this.curser=this.curser+count;
    }
    console.log(this.curser);
    this.selectedStepId=this.steps[this.curser].id;
    this.createItemDisplayed=false;
    this.selectedItems=this.items.filter(e=>e.stepId==this.steps[this.curser].id);
}

}
