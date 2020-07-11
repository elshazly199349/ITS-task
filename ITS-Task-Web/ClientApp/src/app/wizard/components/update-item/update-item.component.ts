import { Component, OnInit, Input } from '@angular/core';
import { ItemService } from 'src/app/shared/services/item.service';
import { Item } from 'src/app/shared/models/Item';

@Component({
  selector: 'app-update-item',
  templateUrl: './update-item.component.html',
  styleUrls: ['./update-item.component.css']
})
export class UpdateItemComponent implements OnInit {
@Input('item')item:Item;
errorMessage:string;
  constructor(private itemService:ItemService) { }

  ngOnInit() {
    this.item={
      id:1,
      title:"item 11",
      description:"item 11",
      stepId:1
    };
  }

  updateItem(item:Item){
    if(item && item.id!=0){
      this.itemService.updateItem(item).subscribe(res=>{},error=>{
        this.errorMessage=error.error;
      });
    }else{
      this.errorMessage="item is not recogized";
    }
  }

  closeErrorDiv(){
    this.errorMessage=undefined;
  }
}
