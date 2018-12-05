import { Component, OnInit } from '@angular/core';
import { DutchArtService } from '../../shared/services/dutch-art.service';
import { Product } from '../../shared/services/product.model';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {
  Products: Product[] = [];

  constructor(private service: DutchArtService) { }

  ngOnInit() {
    this.GetProductsList();
  }

  GetProductsList() {
    this.service.getData().subscribe((data: any) => {
      this.Products = data.products
    })
  }
}
