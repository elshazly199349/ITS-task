import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Item } from '../../models/Item';
import { ItemService } from '../../services/item.service';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {
@Input('item') item:Item;
@Output() delete: EventEmitter<Item> = new EventEmitter();

  constructor(private itemService:ItemService) { }

  ngOnInit() {}

  deleteItem(){
    this.itemService.DeleteItem(this.item.id).subscribe(res=>{
      this.delete.emit(this.item);
    });
  }

}