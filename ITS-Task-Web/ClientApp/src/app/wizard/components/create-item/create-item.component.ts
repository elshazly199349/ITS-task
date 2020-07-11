import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Item } from 'src/app/shared/models/Item';
import { ItemService } from 'src/app/shared/services/item.service';

@Component({
  selector: 'app-create-item',
  templateUrl: './create-item.component.html',
  styleUrls: ['./create-item.component.css']
})
export class CreateItemComponent implements OnInit {
  
item={} as Item;
errorMessage:string;
@Input('stepId')stepId:number;
@Input('itemId')itemId:number;

@Output() manipulateitemComp: EventEmitter<boolean> = new EventEmitter();

  constructor(private itemService:ItemService) {}

  ngOnInit() {
    if(this.itemId && this.itemId!=0){
      this.itemService.getById(this.itemId).subscribe(
        res=>{this.item=res}
        ,err=>{console.log(err.error)});
    }else{
      this.item.stepId=this.stepId;
    }
  }

  saveItem(item:Item){
    if(this.itemId && this.itemId!=0){
      item.id=this.itemId;
      this.itemService.updateItem(item).subscribe(res=>{
        this.manipulateitemComp.emit(true);
      },err=>{console.log(err.error)});

    }else{
      this.itemService.createItem(item).subscribe(res=>{
        this.manipulateitemComp.emit(true);
      },error=>{
        this.errorMessage=error.error;
      });
    }
  }

  closeErrorDiv(){
    this.errorMessage=undefined;
    this.item.description="";
    this.item.title="";
  }
}
